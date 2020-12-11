using BLL.IBLL;
using DAL.IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.WBLL
{
    public class DenLukehuBLL : IDenLukehuBLL
    {
        //依赖注入
        private IDenLukehuDAL _idal;
        public DenLukehuBLL(IDenLukehuDAL dal)
        {
            _idal = dal;
        }
        //客户 Members  登录注册
        #region
        public MembersModel MembersLogin(string account, string password)
        {
            return _idal.MembersLogin(account, password);
        }

        public string MembersPass(string account)
        {
            return _idal.MembersPass(account);
        }

        public int MembersZhuChe(MembersModel model)
        {
            return _idal.MembersZhuChe(model);
        }
        #endregion
    }
}
