using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PayRecordModel
    {
        public int    PayRecordID		{ get; set; }//充值记录主键id
        public int    MembersMessageID  { get; set; }//会员信息id
        public string PayRecord         { get; set; }//记录
    }
}
