﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IDAL
{
    public interface IDenLukehuDAL
    {
        //客户 Members  登录 注册
        #region
        string MembersPass(string account);
        MembersModel MembersLogin(string account,string password);
        int MembersZhuChe(MembersModel model);
        #endregion 
    }
}
