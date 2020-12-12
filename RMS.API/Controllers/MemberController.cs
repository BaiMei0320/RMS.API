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
    [Route("Members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        JWTHelper jwt = new JWTHelper();
        public IWebHostEnvironment _iwebh;
        private IMemberBLL _ibll;
        public MemberController(IMemberBLL ibll, IWebHostEnvironment iwebh)
        {
            _ibll = ibll;
            _iwebh = iwebh;
        }

        //客户 会员
        #region
        //添加客户
        [Route("MembersAdd")]
        [HttpPost]
        public int MembersAdd(MembersModel model)
        {
            return _ibll.MembersAdd(model);
        }
        [Route("MembersMessageAdd")]
        [HttpPost]
        //添加商品
        public int MembersMessageAdd(string ff = "")
        {
            MembersMessageModel model = JsonConvert.DeserializeObject<MembersMessageModel>(ff);
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    var wort = _iwebh.ContentRootPath;
                    var filename = Path.Combine(wort, "wwwroot/img/", item.FileName);
                    model.MembersMessageURL = "/img/" + item.FileName;
                    using (var s = new FileStream(filename, FileMode.Create))
                    {
                        item.CopyTo(s);
                    }
                }
            }
            return _ibll.MembersMessageAdd(model);
        }

        //反填客户
        [Route("MembersFan")]
        [HttpGet]
        public MembersModel MembersFan(int id)
        {
            return _ibll.MembersFan(id);
        }
        //修改客户
        [Route("MembersUpdate")]
        [HttpGet]
        public int MembersUpdate(MembersModel model)
        {
            return _ibll.MembersUpdate(model);
        }
        //修改会员信息
        [Route("MembersMessageUpdate")]
        [HttpGet]
        public int MembersMessageUpdate(string ff = "")
        {
            MembersMessageModel model = JsonConvert.DeserializeObject<MembersMessageModel>(ff);
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    var wort = _iwebh.ContentRootPath;
                    var filename = Path.Combine(wort, "wwwroot/img/", item.FileName);
                    model.MembersMessageURL = "/img/" + item.FileName;
                    using (var s = new FileStream(filename, FileMode.Create))
                    {
                        item.CopyTo(s);
                    }
                }
            }
            return _ibll.MembersMessageUpdate(model);
        }

        //显示客户信息
        [Route("MembersShow")]
        [HttpGet]
        public List<MembersModel> MembersShow()
        {
            return _ibll.MembersShow();
        }
        //删除商品
        [Route("MembersShan")]
        [HttpGet]
        public int MembersShan(string ids)
        {
            return _ibll.MembersShan(ids);
        }
        #endregion

    }
}