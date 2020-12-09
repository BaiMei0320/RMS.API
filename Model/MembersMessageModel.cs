using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MembersMessageModel
    {
        public int    MembersMessageID   { get; set; }//会员信息主键id
        public int    MembersID          { get; set; }//会员外键id
        public string MembersMessageURL  { get; set; }//图片路径
        public string MembersMessageName { get; set; }//会员用户名
        public string MembersMessageSign { get; set; }//会员个签
    }
}
