using BLL.IBLL;
using DAL.IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.WBLL
{
    public class DenLuBLL : IDenLuBLL
    {
        //依赖注入
        private IDenLuDAL _idal;
        public DenLuBLL(IDenLuDAL dal)
        {
            _idal = dal;
        }
        //店家 Merchants  登录注册
        #region
        public MerchantsModel MerchantsLogin(string account, string password)
        {
            return _idal.MerchantsLogin(account,password);
        }

        public string MerchantsPass(string account)
        {
            return _idal.MerchantsPass(account);
        }

        public int MerchantsZhuChe(MerchantsModel model)
        {
            return _idal.MerchantsZhuChe(model);
        }
        #endregion
    }
}
