using DAL.IDAL;
using Microsoft.Extensions.Configuration;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace DAL.WDAL
{
    public class DenLuDAL: IDenLuDAL
    {
        public static IConfiguration _configuration;
        public string connstr;
        public DenLuDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public string conStr { get { return _configuration.GetConnectionString("a"); } set { } }
        //实例化jwt
        JWTHelper helper = new JWTHelper();



        //店家 Merchants  登录注册
        #region
        public string MerchantsPass(string account)
        {
            string sql = $"select * from Merchants where MerchantsAccount='{account}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {

                MerchantsModel model = connection.Query<MerchantsModel>(sql).ToList().FirstOrDefault();
                //解密密码  对象引用未设置为对象的实例。
                string code = helper.GetPayload(model.MerchantsPassword);
                JwtModel jwt = JsonConvert.DeserializeObject<JwtModel>(code);
                string str = jwt.userpass;
                return str;
            }
        }
        //登录1
        public MerchantsModel MerchantsLogin(string account, string password)
        {
            string sqlstr = $"select MerchantsPassword from Merchants where MerchantsAccount ='{account}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connstr = connection.ExecuteScalar(sqlstr).ToString();
            }
            string sql = $"select * from Merchants where MerchantsAccount ='{account}'and MerchantsPassword='{password}'";
            using (SqlConnection connection1 = new SqlConnection(conStr))
            {
                return connection1.Query<MerchantsModel>(sql).ToList().FirstOrDefault();
            }
        }

        public int MerchantsZhuChe(MerchantsModel model)
        {
            //密码加密
            //定义一个字典
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("userpass", model.MerchantsPassword);
            //调用加密方法
            var str = helper.GetToken(pairs, 10000);
            string sql = $"insert into Merchants values('{model.MerchantsAccount}','{str}','{model.MerchantsID}')";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        #endregion
    }
}
