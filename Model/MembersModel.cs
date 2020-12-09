using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MembersModel
    {
        public int     MembersID        { get; set; }//会员主键id
        public string  MembersAccount   { get; set; }//会员账户
        public string  MembersWeChat    { get; set; }//会员微信号
        public string  MembersNumber    { get; set; }//会员手机号
        public string  MembersPassword  { get; set; }//会员密码
        public int     MembersAddressID { get; set; }//会员ID
        public string  MembersSite      { get; set; }//会员地址
        public Decimal MembersMoney     { get; set; }//会员余额
    }
}
