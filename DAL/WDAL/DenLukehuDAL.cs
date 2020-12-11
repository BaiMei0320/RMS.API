using DAL.IDAL;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;
using Newtonsoft.Json;

namespace DAL.WDAL
{
    public class DenLukehuDAL: IDenLukehuDAL
    {
        public static IConfiguration _configuration;
        public string connstr;
        public DenLukehuDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public string conStr { get { return _configuration.GetConnectionString("a"); } set { } }
        //实例化jwt
        JWTHelper helper = new JWTHelper();


        //客户 Members  登录注册
        #region
        //密码解密
        public string MembersPass(string account)
        {
            string sql = $"select * from Members where MembersAccount ='{account}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {

                MembersModel model = connection.Query<MembersModel>(sql).ToList().FirstOrDefault();
                //解密密码
                string code = helper.GetPayload(model.MembersPassword);
                JwtModel jwt = JsonConvert.DeserializeObject<JwtModel>(code);
                string str = jwt.userpass;
                return str;
            }
        }
        //登录
        public MembersModel MembersLogin(string account, string password)
        {
            string sqlstr = $"select MembersPassword  from Members where MembersAccount ='{account}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connstr = connection.ExecuteScalar(sqlstr).ToString();
            }
            string sql = $"select * from Members where MembersAccount='{account}'and MembersPassword='{password}'";
            using (SqlConnection connection1 = new SqlConnection(conStr))
            {
                return connection1.Query<MembersModel>(sql).ToList().FirstOrDefault();
            }
        }
        //注册
        public int MembersZhuChe(MembersModel model)
        {
            //密码加密
            //定义一个字典
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("userpass", model.MembersPassword);
            //调用加密方法
            var str = helper.GetToken(pairs, 10000);
            string sql = $"insert into Members values('{model.MembersAccount}','{str}','{model.MembersID}')";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        #endregion
    }
}
