using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class OneTeceiptsModel
    {
        public int      OneTeceiptsID	 { get; set; }//订单主表主键id
        public int      MembersMessageID { get; set; }//会员id
        public string   OneTeceiptsCode  { get; set; }//订单编号
        public DateTime OneTeceiptsTime  { get; set; }//订单时间 
        public int      OneTeceiptsState { get; set; }//订单状态
        public string   Gids             { get; set; }
        public string   Nums             { get; set; }
    }
}
