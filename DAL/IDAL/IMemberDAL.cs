using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IDAL
{
    public interface IMemberDAL
    {
        //会员信息管理 Members
        #region
        int MembersAdd(MembersModel model);   //添加客户
        int MembersMessageAdd(MembersMessageModel model);   //添加会员详细信息
        List<MembersModel> MembersShow();     //显示
        int MembersShan(string ids);          //删除
        MembersModel MembersFan(int id);      //反填    
        int MembersUpdate(MembersModel model);//修改会员
        int MembersMessageUpdate(MembersMessageModel model);//修改会员信息
        #endregion
    }
}
