using System;
using System.Collections.Generic;
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
    [Route("Orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrdersBLL _orderBll;
        public OrderController(IOrdersBLL orderBll)
        {
            _orderBll = orderBll;
        }

        //订单管理
        #region
        //添加选购清单
        [Route("OneTeceiptsAdd")]
        [HttpPost]
        public int OneTeceiptsAdd(string ff = "")
        {
            try
            {
                OneTeceiptsModel model = JsonConvert.DeserializeObject<OneTeceiptsModel>(ff);
                _orderBll.OneTeceiptsAdd(model);
                var gids = model.Gids;
                var nums = model.Nums;
                var arr = gids.Split(',');
                var arr2 = nums.Split(',');
                //循环添加选购详细
                for (int i = 0; i < arr.Length; i++)
                {
                    //实例化选购详细
                    TwoTeceiptsModel model1 = new TwoTeceiptsModel();
                    //model1.SelectOrderDeitCode = model.SelectOrderCode;
                    model1.OneTeceiptsID = Convert.ToInt32(arr[i]);
                    model1.TwoTeceiptsNum = Convert.ToInt32(arr2[i]);
                    _orderBll.TwoTeceiptsAdd(model1);
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //显示购物清单
        [Route("OneTeceiptsShoe")]
        [HttpGet]
        public List<OneTeceiptsModel> OneTeceiptsShoe()
        {
            return _orderBll.OneTeceiptsShoe();
        }

        //显示购物清单详细
        [Route("TwoTeceiptsShoe")]
        [HttpGet]
        public List<TwoTeceiptsModel> TwoTeceiptsShoe(string code)
        {
            return _orderBll.TwoTeceiptsShoe(code);
        }
        //删除商品
        [Route("OneTeceiptsDelete")]
        [HttpGet]
        public int OneTeceiptsDelete(string ids)
        {
            return _orderBll.OneTeceiptsDelete(ids);
        }
        #endregion

    }
}