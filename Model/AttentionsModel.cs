using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class AttentionsModel
    {
        public int AttentionsID         { get; set; }//商家主键id
        public int MerchantsMessageID   { get; set; }//商家信息主键id
        public int MembersMessageID     { get; set; }//会员信息主键id
    }
}
