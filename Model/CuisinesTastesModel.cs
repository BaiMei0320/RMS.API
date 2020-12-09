using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CuisinesTastesModel
    {
        public int CuisinesTastesID  { get; set; }//菜品类别主键id
        public int CuisinesID		 { get; set; }//菜品id
        public int TastesID          { get; set; }//类别id
    }
}
