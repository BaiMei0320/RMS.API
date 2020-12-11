using DAL.IDAL;
using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.WDAL
{
    public class HotelDAL: IHotelDAL
    {
        public static IConfiguration _configuration;
        public string connstr;
        public HotelDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public string conStr { get { return _configuration.GetConnectionString("a"); } set { } }
        //实例化DBhelper
        DBHelper dBHelper = new DBHelper(_configuration);


        //商店管理
        #region

        public MerchantsModel MerchantsFan(int id)
        {
            string sql = $"select * from Merchants m join MerchantsMessage mm on m.MerchantsID=mm.MerchantsID join MerchantsRelevance mr on mr.MerchantsID = mm.MerchantsMessageID join MerchantsTypes mt on mt.MerchantsTypesID = mr.MerchantsTypesID where m.MerchantsID = {id}";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<MerchantsModel>(sql).ToList().FirstOrDefault();
            }
        }
        //修改
        public int MerchantsUpdate(MerchantsMessageModel model)
        {
            string sql = $"update MerchantsMessage set MerchantsMessageURL ='{model.MerchantsMessageURL}',MerchantsMessageName ='{model.MerchantsMessageName}',MerchantsMessageSign ='{model.MerchantsMessageSign}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示
        public List<MerchantsModel> MerchantsShow()
        {
            string sql = $"select * from Merchants m join MerchantsMessage mm on m.MerchantsID=mm.MerchantsID join MerchantsRelevance mr on mr.MerchantsID = mm.MerchantsMessageID join MerchantsTypes mt on mt.MerchantsTypesID = mr.MerchantsTypesID";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<MerchantsModel>(sql).ToList();
            }
        }

        #endregion


    }
}
