using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MerchantsModel
    {
        public int     MerchantsID       { get; set; }//商家主键id
        public string  MerchantsAccount  { get; set; }//商家账户
        public string  MerchantsWeChat   { get; set; }//商家微信号
        public string  MerchantsNumber   { get; set; }//商家手机号
        public string  MerchantsPassword { get; set; }//商家密码
        public Decimal MerchantsMoney    { get; set; }//商家余额
    }
}
