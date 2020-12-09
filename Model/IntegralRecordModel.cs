using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class IntegralRecordModel
    {
        public int    IntegralRecordID   { get; set; }//积分记录主键id
        public int    MembersMessageID   { get; set; }//会员信息id
        public string IntegralRecords    { get; set; }//记录
    }
}
