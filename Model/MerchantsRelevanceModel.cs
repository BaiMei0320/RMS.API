using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MerchantsRelevanceModel
    {
        public int MerchantsRelevanceID { get; set; }//商家类型关系主键id
        public int MerchantsTypesID     { get; set; }//商家类型id
        public int MerchantsID          { get; set; }//商家信息id
    }
}
