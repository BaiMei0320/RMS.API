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
	MembersAddressID	 int,       			   --会员ID
	MembersSite	         varchar(100),			   --会员地址
	MembersMoney	     Money      			   --会员余额
 )
 insert into Members values
 ('AS369','武则天','15315405669','123456','0351694','中国理工大学','9965')
,('AS370','杨玉环','15343405669','123456','0351695','中国建设大学','5326')
,('AS371','南无PT','14358405669','123456','0351696','中国医疗大学','1226')
,('AS372','花和尚','15315454388','123456','0351697','中国科技大学','2356')
,('AS373','林教头','13453405669','123456','0351698','中国战略大学','1246')
,('AS374','孙三娘','15874305659','123456','0351699','中国军工大学','5566')
,('AS375','武大郎','13315453549','123456','0351710','中国研发大学','1526')
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
 ('1','','武则天','武则天VIP9')
,('2','','杨玉环','杨玉环VIP8')
,('3','','南无PT','南无PTVIP4')
,('4','','花和尚','花和尚VIP3')
,('5','','林教头','林教头VIP5')
,('6','','孙三娘','孙三娘VIP7')
,('7','','武大郎','武大郎VIP1')
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

insert into Merchants values
 ('XL013','13615462150','13615462150','123456','365512')
,('DG014','13615462151','13615462151','123456','454365')
,('JD015','13615462152','13615462152','123456','999385')
,('RL016','13615462153','13615462153','123456','565665')
,('LC017','13615462154','13615462154','123456','184365')
,('XC018','13615462155','13615462155','123456','124365')
,('PS019','13615462156','13615462156','123456','394365')
--商家信息表
create table MerchantsMessage
(
	MerchantsMessageID            int primary key identity, --商家信息主键id
	MerchantsID                   int,                      --商家外键id
	MerchantsMessageURL           varchar(MAX),			    --图片路径
	MerchantsMessageName          varchar(50),				--商家用户名
	MerchantsMessageSign	      varchar(200)				--商家个签
)

insert into MerchantsMessage values
 ('1','#','香辣','香辣用心做菜创造美好')
,('2','#','蛋糕','蛋糕用心做菜创造美好')
,('3','#','经典','经典用心做菜创造美好')
,('4','#','日料','日料用心做菜创造美好')
,('5','#','凉菜','凉菜用心做菜创造美好')
,('6','#','西餐','西餐用心做菜创造美好')
,('7','#','披萨','披萨用心做菜创造美好')
--商家类型表
create table MerchantsTypes
(
	MerchantsTypesID            int primary key identity, --商家类型主键id
	MerchantsTypesName          varchar(50)				  --商家类型
)
insert into MerchantsTypes values
 ('经典')
,('日料')
,('西餐')
--商家类型关联表
create table MerchantsRelevance
(
	MerchantsRelevanceID            int primary key identity, --商家类型关系主键id
	MerchantsTypesID                int,					  --商家类型id
	MerchantsID						int						  --商家信息id
)
insert into MerchantsRelevance values
 ('1','1')
,('3','2')
,('1','3')
,('2','4')
,('1','5')
,('3','6')
,('3','7')
select * from Merchants m join MerchantsMessage mm on m.MerchantsID=mm.MerchantsID
join MerchantsRelevance mr on mr.MerchantsID=mm.MerchantsMessageID
join MerchantsTypes mt on mt.MerchantsTypesID=mr.MerchantsTypesID where m.MerchantsID=1

--关注表
create table Attentions
(
	AttentionsID            int primary key identity,         --商家主键id
	MerchantsMessageID      int,						      --商家信息主键id
	MembersMessageID		int						          --会员信息主键id
)
insert into Attentions values
 ('1','1')
,('3','2')
,('1','3')
,('2','4')
,('1','5')
,('3','6')
,('3','7')
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
insert into Cuisines values
 ('1','#','香辣兔腿','300','20','香辣兔腿香辣特供')
,('2','#','草莓蛋糕','100','50','草莓蛋糕限时抢购')
,('3','#','大盘鸡60','200','60','大盘鸡特价优惠')
,('4','#','寿司拼盘','100','20','寿司拼盘特价优惠')
,('5','#','泡椒凤爪','500','20','泡椒凤爪特价优惠')
,('6','#','豪华拼盘','300','30','豪华拼盘特价优惠')
,('7','#','牛肉披萨','100','40','牛肉披萨特价优惠')						
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
insert into CuisinesCategory values
 ('1','1')
,('2','2')
,('3','3')
,('4','4')
,('5','5')
,('6','6')
,('7','7')
--口味表
create table Tastes
(
	TastesID					  int primary key identity,         --口味主键id
	TastesName				      varchar(50)				        --口味名
)
insert into Tastes values('不辣'),('微辣'),('中辣'),('特辣'),('变态辣'),('微甜'),('中甜')
select * from Tastes
--菜品口味表		
create table CuisinesTastes
(
	CuisinesTastesID			  int primary key identity,         --菜品类别主键id
	CuisinesID					  int,								--菜品id
	TastesID     				  int				                --口味id
)
insert into CuisinesTastes values
 ('1','4')
,('2','6')
,('3','3')
,('4','2')
,('5','3')
,('6','6')
,('7','5')
--评论表
create table Comment
(
	CommentID			  int primary key identity,         --评论主键id
	CuisinesID			  int,								--菜品id
	CommentState		  int,								--等级 0 差 1星 2星 3星 4星 5星
	CuisinesComment       varchar(100),						--评论
)
insert into Comment values
 ('1','5','非常好吃')
,('2','5','非常好吃')
,('3','5','非常好吃')
,('4','5','非常好吃')
,('5','5','非常好吃')
,('6','5','非常好吃')
,('7','5','非常好吃')
--订单主表
create table OneTeceipts
(
	OneTeceiptsID		    int primary key identity,             --订单主表主键id
	MembersMessageID        int,								  --会员id
	OneTeceiptsCode         varchar(30),						  --订单编号
    OneTeceiptsTime         datetime,							  --订单时间 
	OneTeceiptsState        int                                   --订单状态    --0未完成    1完成
)
insert into OneTeceipts values
 ('1','XL453','2020-12-06','0')
,('2','DG245','2020-12-06','0')
,('3','JD183','2020-12-06','0')
,('4','RL254','2020-12-06','0')
,('5','LC556','2020-12-06','0')
,('6','XC667','2020-12-06','0')
,('7','PS385','2020-12-06','0')
--订单副表
create table TwoTeceipts
(
	TwoTeceiptsID		    int primary key identity,             --订单主表主键id
	OneTeceiptsID	        int,								  --主表id
	CuisinesID              int,								  --菜品id
    TwoTeceiptsNum			int,							      --数量
	TwoTeceiptsState        int                                   --0 未操作  1已入库  2已退货
)
insert into TwoTeceipts values
 ('1','1','10','0')
,('2','2','10','0')
,('3','3','10','0')
,('4','4','10','0')
,('5','5','10','0')
,('6','6','10','0')
,('7','7','10','0')
--充值记录表
create table PayRecord
(
	PayRecordID		    int primary key identity,             --充值记录主键id
	MembersMessageID    int,								  --会员信息id
	PayRecord           varchar(max)						  --记录
)
insert into PayRecord values
 ('1','500')
,('2','500')
,('3','500')
,('4','500')
,('5','500')
,('6','500')
,('7','500')
--积分记录表
create table IntegralRecord
(
	IntegralRecordID		    int primary key identity,             --积分记录主键id
	MembersMessageID            int,								  --会员信息id
	IntegralRecords             varchar(max)						  --记录
)
insert into IntegralRecord values
 ('1','500')
,('2','500')
,('3','500')
,('4','500')
,('5','500')
,('6','500')
,('7','500')

select * from OneTeceipts ot join Members m on ot.MembersMessageID=m.MembersID
join MembersMessage mm on mm.MembersID=m.MembersID
join TwoTeceipts tt on tt.OneTeceiptsID=ot.OneTeceiptsID
join Cuisines c on c.CuisinesID=tt.CuisinesID