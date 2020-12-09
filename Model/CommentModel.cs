using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CommentModel
    {
        public int    CommentID		   { get; set; }//评论主键id
        public int    CuisinesID	   { get; set; }//菜品id
        public int    CommentState	   { get; set; }//等级 0 差 1星
        public string CuisinesComment  { get; set; }//评论
    }
}
