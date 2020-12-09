using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TwoTeceiptsModel
    {
        public int TwoTeceiptsID	 { get; set; }//订单主表主键id
        public int OneTeceiptsID	 { get; set; }//主表id
        public int CuisinesID        { get; set; }//菜品id
        public int TwoTeceiptsNum	 { get; set; }//数量
        public int TwoTeceiptsState  { get; set; }//0 未操作  1已入库
    }
}
