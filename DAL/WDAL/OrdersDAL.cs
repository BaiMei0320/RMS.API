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
    public class OrdersDAL: IOrdersDAL
    {
        public static IConfiguration _configuration;
        public string connstr;
        public OrdersDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public string conStr { get { return _configuration.GetConnectionString("a"); } set { } }
        //实例化DBhelper
        DBHelper dBHelper = new DBHelper(_configuration);


        //订单管理
        #region
        //添加订单主
        public int OneTeceiptsAdd(OneTeceiptsModel model)
        {
            string sql = $"insert into OneTeceipts values('{model.MembersMessageID}','{model.OneTeceiptsCode}','{model.OneTeceiptsTime}','{model.OneTeceiptsState}')";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //添加订单从
        public int TwoTeceiptsAdd(TwoTeceiptsModel model)
        {
            string sql = $"insert into TwoTeceipts values('{model.OneTeceiptsID}','{model.CuisinesID}','{model.TwoTeceiptsNum}','{model.TwoTeceiptsState}')";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //删除订单
        public int OneTeceiptsDelete(string ids)
        {
            string sql = $"delete from OneTeceipts where OneTeceiptsID in ({ids})";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示订单信息
        public List<OneTeceiptsModel> OneTeceiptsShoe()
        {
            string sql = $"select * from OneTeceipts ";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<OneTeceiptsModel>(sql).ToList();
            }
        }
        //显示订单详细信息
        public List<TwoTeceiptsModel> TwoTeceiptsShoe(string code)
        {
            string sql = $"select * from OneTeceipts ot join Members m on ot.MembersMessageID=m.MembersID join MembersMessage mm on mm.MembersID = m.MembersID join TwoTeceipts tt on tt.OneTeceiptsID = ot.OneTeceiptsID join Cuisines c on c.CuisinesID = tt.CuisinesID";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<TwoTeceiptsModel>(sql).ToList();
            }
        }
        #endregion
    }
}
