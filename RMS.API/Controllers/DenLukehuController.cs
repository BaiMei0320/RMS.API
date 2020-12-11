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
    [Route("DenLukehu")]
    [ApiController]
    public class DenLukehuController : ControllerBase
    {
        string a = "";
        private IDenLukehuBLL _ibll;
        public DenLukehuController(IDenLukehuBLL ibll)
        {
            _ibll = ibll;
        }
        //接收手机号进行发送
        [Route("PhoneToUrl1")]
        [HttpGet]
        public string PhoneToUrl1(string phone = "")
        {

            Random random = new Random();
            a = random.Next().ToString().Substring(0, 4);

            string url = $"http://utf8.api.smschinese.cn/?Uid=wukeya&Key=d41d8cd98f00b204e980&smsMob={phone}&smsText=验证码:{a}";
            GetHtmlFromUrl1(url);
            return a;
        }
        //发送短信
        [Route("GetHtmlFromUrl1")]
        [HttpGet]
        public string GetHtmlFromUrl1(string url)
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
        //顾客 登录 注册
        #region
        [Route("MembersLogin")]
        [HttpGet]

        public MembersModel MembersLogin(string name, string pass = "")
        {
            //解密密码
            string str = _ibll.MembersPass(name);
            //登录
            if (pass == str)
            {
                MembersModel model = _ibll.MembersLogin(name, str);
                return model;
            }
            return null;
        }
        [Route("MembersZhuChe")]
        [HttpPost]
        public IActionResult MembersZhuChe(string ff = "")
        {
            MembersModel model = JsonConvert.DeserializeObject<MembersModel>(ff);
            int i = _ibll.MembersZhuChe(model);
            return Ok(i);
        }
        #endregion
    }
}