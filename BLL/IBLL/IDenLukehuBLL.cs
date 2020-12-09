using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IBLL
{
    public interface IDenLukehuBLL
    {
        //客户 Members  登录 注册
        #region
        string MembersPass(string Account);
        MembersModel MembersLogin(string Account);
        int MembersZhuChe(MembersModel Model);
        #endregion 
    }
}
