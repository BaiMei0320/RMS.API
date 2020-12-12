using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.IBLL;
using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;

namespace RMS.API.Controllers
{
    [Route("Hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        JWTHelper jwt = new JWTHelper();
        public IWebHostEnvironment _iwebh;
        private IHotelBLL _ibll;
        public HotelController(IHotelBLL ibll, IWebHostEnvironment iwebh)
        {
            _ibll = ibll;
            _iwebh = iwebh;
        }
        //商店管理 Merchants
        #region

        //反填商店 
        [Route("MerchantsFan")]
        [HttpGet]
        public MerchantsModel MerchantsFan(int id)
        {
            return _ibll.MerchantsFan(id);
        }

        //修改商店
        [Route("MerchantsUpdate")]
        [HttpGet]
        public int MerchantsUpdate(string ff = "")
        {
            MerchantsMessageModel model = JsonConvert.DeserializeObject<MerchantsMessageModel>(ff);
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    var wort = _iwebh.ContentRootPath;
                    var filename = Path.Combine(wort, "wwwroot/img/", item.FileName);
                    model.MerchantsMessageURL = "/img/" + item.FileName;
                    using (var s = new FileStream(filename, FileMode.Create))
                    {
                        item.CopyTo(s);
                    }
                }
            }
            return _ibll.MerchantsUpdate(model);
        }

        //显示商店
        [Route("MerchantsShow")]
        [HttpGet]
        public List<MerchantsModel> MerchantsShow()
        {
            return _ibll.MerchantsShow();
        }
        #endregion
    }
}