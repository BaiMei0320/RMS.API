using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CuisinesCategoryModel
    {
        public int CuisinesCategoryID	 { get; set; }//菜品类别主键id
        public int CuisinesID			 { get; set; }//菜品id
        public int CategoryID            { get; set; }//类别id
    }
}
