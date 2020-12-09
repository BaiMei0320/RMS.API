 create database RMS
 GO
 USE RMS
 --客户表
 create table Members
 (
	MembersID            int primary key identity, --会员主键id
	MembersAccount       varchar(100),			   --会员账户
	MembersWeChat        varchar(100),			   --会员微信号
	MembersNumber        varchar(100),			   --会员手机号
	MembersPassword      varchar(100),			   --会员密码
	MembersAddressID	 int,       			                   --会员ID
	MembersSite	         varchar(100),			   --会员地址
	MembersMoney	     Money      			   --会员余额
 )
 insert into Members values
 ('AS369','LI仙女','15315405669','1314520','LI11','北京海淀区中国理工大学','9965489')
,('','','','','','','')

 --会员信息表
  create table MembersMessage
(
	MembersMessageID      int primary key identity, --会员信息主键id
	MembersID             int,						--会员外键id
	MembersMessageURL     varchar(MAX),			    --图片路径
	MembersMessageName    varchar(50),				--会员用户名
	MembersMessageSign	  varchar(200)				--会员个签
)
insert into MembersMessage values
 ('','','','')
,('','','','')
--商家表
create table Merchants
(
	MerchantsID            int primary key identity,   --商家主键id
	MerchantsAccount       varchar(100),			   --商家账户
	MerchantsWeChat        varchar(100),			   --商家微信号
	MerchantsNumber        varchar(100),			   --商家手机号
	MerchantsPassword      varchar(100),			   --商家密码
	MerchantsMoney	       Money      			       --商家余额
)
insert into Merchants values('','','','','')
--商家信息表
create table MerchantsMessage
(
	MerchantsMessageID            int primary key identity, --商家信息主键id
	MerchantsID                   int,                      --商家外键id
	MerchantsMessageURL           varchar(MAX),			    --图片路径
	MerchantsMessageName          varchar(50),				--商家用户名
	MerchantsMessageSign	      varchar(200)				--商家个签
)
insert into MerchantsMessage values('','','','')
--商家类型表
create table MerchantsTypes
(
	MerchantsTypesID            int primary key identity, --商家类型主键id
	MerchantsTypesName          varchar(50)				  --商家类型
)
insert into MerchantsTypes values('')
--商家类型关联表
create table MerchantsRelevance
(
	MerchantsRelevanceID            int primary key identity, --商家类型关系主键id
	MerchantsTypesID                int,					  --商家类型id
	MerchantsID						int						  --商家信息id
)
insert into MerchantsRelevance values('','')
--关注表
create table Attentions
(
	AttentionsID            int primary key identity,         --商家主键id
	MerchantsMessageID      int,						      --商家信息主键id
	MembersMessageID		int						          --会员信息主键id
)
insert into Attentions values('','')
--菜品表
create table Cuisines
(
	CuisinesID					  int primary key identity,         --菜品ID主键id
	MerchantsMessageID            int,								--商家信息主键id
	CuisinesURL					  varchar(MAX),			            --图片路径
	CuisinesName				  varchar(50),				        --菜品名
	CuisinesNum					  int,								--菜品销量
	CuisinesPrice                 money,                            --菜品单价
	CuisinesSign				  varchar(200)				        --菜品个签
)		
insert into Cuisines values('','','','','','')					
--类别表
create table Category
(
	CategoryID					  int primary key identity,         --类别主键id
	CategoryName				  varchar(50)				        --类别名
)	
insert into Category values('披萨'),('蛋糕'),('经典'),('日料'),('卤菜'),('西餐'),('香辣')
--菜品类别表		
create table CuisinesCategory
(
	CuisinesCategoryID			  int primary key identity,         --菜品类别主键id
	CuisinesID					  int,								--菜品id
	CategoryID					  int				                --类别id
)
insert into CuisinesCategory values('','')
--口味表
create table Tastes
(
	TastesID					  int primary key identity,         --口味主键id
	TastesName				      varchar(50)				        --口味名
)
insert into Tastes values('不辣'),('微辣'),('中辣'),('特辣'),('变态辣')
--菜品口味表		
create table CuisinesTastes
(
	CuisinesTastesID			  int primary key identity,         --菜品类别主键id
	CuisinesID					  int,								--菜品id
	TastesID     				  int				                --类别id
)
insert into CuisinesTastes values('','')
--评论表
create table Comment
(
	CommentID			  int primary key identity,         --评论主键id
	CuisinesID			  int,								--菜品id
	CommentState		  int,								--等级 0 差 1星 2星 3星 4星 5星
	CuisinesComment       varchar(100),						--评论
)
insert into Comment values('','','')	
--订单主表
create table OneTeceipts
(
	OneTeceiptsID		    int primary key identity,             --订单主表主键id
	MembersMessageID        int,								  --会员id
	OneTeceiptsCode         varchar(30),						  --订单编号
    OneTeceiptsTime         datetime,							  --订单时间 
	OneTeceiptsState        int                                   --订单状态    --0未完成    1完成
)
insert into OneTeceipts values('','','','')	
--订单副表
create table TwoTeceipts
(
	TwoTeceiptsID		    int primary key identity,             --订单主表主键id
	OneTeceiptsID	        int,								  --主表id
	CuisinesID              int,								  --菜品id
    TwoTeceiptsNum			int,							      --数量
	TwoTeceiptsState        int                                   --0 未操作  1已入库  2已退货
)
insert into TwoTeceipts values('','','','')	
--充值记录表
create table PayRecord
(
	PayRecordID		    int primary key identity,             --充值记录主键id
	MembersMessageID    int,								  --会员信息id
	PayRecord           varchar(max)						  --记录
)
insert into PayRecord values('','')
--积分记录表
create table IntegralRecord
(
	IntegralRecordID		    int primary key identity,             --积分记录主键id
	MembersMessageID            int,								  --会员信息id
	IntegralRecords             varchar(max)						  --记录
)
insert into IntegralRecord values('','')