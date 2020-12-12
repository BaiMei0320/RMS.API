using BLL.IBLL;
using DAL.IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.WBLL
{
    public class MemberBLL: IMemberBLL
    {
        //依赖注入
        private IMemberDAL _idal;
        public MemberBLL(IMemberDAL dal)
        {
            _idal = dal;
        }

        //会员信息管理 Members
        #region

        //添加客户
        public int MembersAdd(MembersModel model)
        {
            return _idal.MembersAdd(model);
        }

        //添加会员详情
        public int MembersMessageAdd(MembersMessageModel model)
        {
            return _idal.MembersMessageAdd(model);
        }

        //显示
        public List<MembersModel> MembersShow()
        {
            return _idal.MembersShow();
        }

        //反填
        public MembersModel MembersFan(int id)
        {
            return _idal.MembersFan(id);
        }

        //修改
        public int MembersUpdate(MembersModel model)
        {
            return _idal.MembersUpdate(model);
        }

        //删除
        public int MembersShan(string ids)
        {
            return _idal.MembersShan(ids);
        }

        public int MembersMessageUpdate(MembersMessageModel model)
        {
            return _idal.MembersMessageUpdate(model);
        }

        #endregion
    }
}
