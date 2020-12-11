using BLL.IBLL;
using DAL.IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.WBLL
{
    public class HotelBLL : IHotelBLL
    {
        //依赖注入
        private IHotelDAL _idal;
        public HotelBLL(IHotelDAL dal)
        {
            _idal = dal;
        }
        //商店管理
        #region
        public MerchantsModel MerchantsFan(int id)
        {
            return _idal.MerchantsFan(id);
        }

        public List<MerchantsModel> MerchantsShow()
        {
            return _idal.MerchantsShow();
        }

        public int MerchantsUpdate(MerchantsMessageModel model)
        {
            return _idal.MerchantsUpdate(model);
        }
        #endregion
    }
}
