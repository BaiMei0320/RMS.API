using DAL.IDAL;
using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.WDAL
{
    public class MemberDAL: IMemberDAL
    {
        public static IConfiguration _configuration;
        public string connstr;
        public MemberDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public string conStr { get { return _configuration.GetConnectionString("a"); } set { } }
        //实例化DBhelper
        DBHelper dBHelper = new DBHelper(_configuration);


        //会员信息管理 Members
        #region

        //添加客户
        public int MembersAdd(MembersModel model)
        {
            string sql = $"insert into Members values('{model.MembersAccount}','{model.MembersWeChat}','{model.MembersNumber}','{model.MembersPassword}','{model.MembersAddressID}','{model.MembersSite}','{model.MembersMoney}')";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }

        //添加会员详情
        public int MembersMessageAdd(MembersMessageModel model)
        {
            string sql = $"insert into MembersMessage values('{model.MembersID}','{model.MembersMessageURL}','{model.MembersMessageName}','{model.MembersMessageSign}')";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }

        //显示
        public List<MembersModel> MembersShow()
        {
            string sql = $"select * from Members m join MembersMessage mm on mm.MembersMessageID=m.MembersID";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<MembersModel>(sql).ToList();
            }
        }

        //删除
        public int MembersShan(string ids)
        {
            string sql = $"delete from Members where MembersID in ({ids})";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }

        //反填  
        public MembersModel MembersFan(int id)
        {
            string sql = $"select * from Members m join MembersMessage mm on mm.MembersMessageID = m.MembersID where m.MembersID = {id}";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<MembersModel>(sql).ToList().FirstOrDefault();
            }
        }

        //修改客户
        public int MembersUpdate(MembersModel model)
        {
            string sql = $"update Members set  ='{model.MembersNumber}', ='{model.MembersPassword}', ='{model.MembersSite}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //修改会员信息
        public int MembersMessageUpdate(MembersMessageModel model)
        {
            string sql = $"update MembersMessage set  ='{model.MembersMessageURL}', ='{model.MembersMessageName}', ='{model.MembersMessageSign}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }

        #endregion
    }
}
