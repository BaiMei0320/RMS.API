using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IDAL
{
    public interface IDenLuDAL
    {
        //店家 Merchants  登录 注册
        #region
        string MerchantsPass(string account);
        MerchantsModel MerchantsLogin(string account,string password);
        int MerchantsZhuChe(MerchantsModel model);
        #endregion
    }
}
