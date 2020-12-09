using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CuisinesModel
    {
        public int     CuisinesID			 { get; set; }//菜品ID主键id
        public int     MerchantsMessageID    { get; set; }//商家信息主键id
        public string  CuisinesURL		     { get; set; }//图片路径
        public string  CuisinesName		     { get; set; }//菜品名
        public int     CuisinesNum			 { get; set; }//菜品销量
        public Decimal CuisinesPrice         { get; set; }//菜品单价 
        public string  CuisinesSign          { get; set; }//菜品个签
    }
}
