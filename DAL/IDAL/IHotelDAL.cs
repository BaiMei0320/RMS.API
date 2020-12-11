﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IDAL
{
    public interface IHotelDAL
    {

        //商店管理 Merchants
        #region
        MerchantsModel MerchantsFan(int id);//反填
        int MerchantsUpdate(MerchantsMessageModel model);//修改商品
        List<MerchantsModel> MerchantsShow();//显示
        #endregion
    }
}
