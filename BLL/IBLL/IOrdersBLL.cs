using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IBLL
{
    public interface IOrdersBLL
    {
        //订单管理
        #region
        int OneTeceiptsAdd(OneTeceiptsModel model);         //添加订单主表
        int TwoTeceiptsAdd(TwoTeceiptsModel model);         //添加订单从表
        int OneTeceiptsDelete(string ids);                  //删除订单
        List<OneTeceiptsModel> OneTeceiptsShoe();//显示订单信息
        List<TwoTeceiptsModel> TwoTeceiptsShoe(string code);//显示订单详细信息
        #endregion
    }
}
