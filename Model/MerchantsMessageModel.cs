using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MerchantsMessageModel
    {
        public int    MerchantsMessageID   { get; set; }//商家信息主键id
        public int    MerchantsID          { get; set; }//商家外键id
        public string MerchantsMessageURL  { get; set; }//图片路径
        public string MerchantsMessageName { get; set; }//商家用户名
        public string MerchantsMessageSign { get; set; }//商家个签
    }
}
