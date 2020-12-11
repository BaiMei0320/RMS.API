using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BLL.IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;

namespace RMS.API.Controllers
{
    [Route("DenLu")]
    [ApiController]
    public class DenLuController : ControllerBase
    {
        string a = "";
        private IDenLuBLL _ibll;
        public DenLuController(IDenLuBLL ibll) 
        {
            _ibll = ibll;
        }
        //接收手机号进行发送
        [Route("PhoneToUrl")]
        [HttpGet]
        public string PhoneToUrl(string phone = "")
        {

            Random random = new Random();
            a = random.Next().ToString().Substring(0, 4);

            string url = $"http://utf8.api.smschinese.cn/?Uid=wukeya&Key=d41d8cd98f00b204e980&smsMob={phone}&smsText=验证码:{a}";
            GetHtmlFromUrl(url);
            return a;
        }
        //发送短信
        [Route("GetHtmlFromUrl")]
        [HttpGet]
        public string GetHtmlFromUrl(string url)
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }
        //店家 登录 注册
        #region
        [Route("MerchantsLogin")]
        [HttpGet]

        public MerchantsModel MerchantsLogin(string name, string pass = "")
        {
            //解密密码
            string str = _ibll.MerchantsPass(name);
            //登录
            if (pass == str)
            {
                MerchantsModel model = _ibll.MerchantsLogin(name,str);
                return model;
            }
            return null;
        }
        [Route("MerchantsZhuChe")]
        [HttpPost]
        public IActionResult MerchantsZhuChe(string ff = "")
        {
            MerchantsModel model = JsonConvert.DeserializeObject<MerchantsModel>(ff);
            int i = _ibll.MerchantsZhuChe(model);
            return Ok(i);
        }
        #endregion
    }
}