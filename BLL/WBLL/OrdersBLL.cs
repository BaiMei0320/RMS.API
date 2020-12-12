using BLL.IBLL;
using DAL.IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.WBLL
{
    public class OrdersBLL: IOrdersBLL
    {
        //依赖注入
        private IOrdersDAL _idal;
        public OrdersBLL(IOrdersDAL dal)
        {
            _idal = dal;
        }

        //订单管理
        #region
        public int OneTeceiptsAdd(OneTeceiptsModel model)
        {
            return _idal.OneTeceiptsAdd(model);
        }

        public int OneTeceiptsDelete(string ids)
        {
            return _idal.OneTeceiptsDelete(ids);
        }

        public int TwoTeceiptsAdd(TwoTeceiptsModel model)
        {
            return _idal.TwoTeceiptsAdd(model);
        }

        public List<OneTeceiptsModel> OneTeceiptsShoe()
        {
            return _idal.OneTeceiptsShoe();
        }

        public List<TwoTeceiptsModel> TwoTeceiptsShoe(string code)
        {
            return _idal.TwoTeceiptsShoe(code);
        }

        #endregion

    }
}
