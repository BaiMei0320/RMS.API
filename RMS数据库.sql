 create database RMS
 GO
 USE RMS
 --�ͻ���
 create table Members
 (
	MembersID            int primary key identity, --��Ա����id
	MembersAccount       varchar(100),			   --��Ա�˻�
	MembersWeChat        varchar(100),			   --��Ա΢�ź�
	MembersNumber        varchar(100),			   --��Ա�ֻ���
	MembersPassword      varchar(100),			   --��Ա����
	MembersAddressID	 int,       			   --��ԱID
	MembersSite	         varchar(100),			   --��Ա��ַ
	MembersMoney	     Money      			   --��Ա���
 )
 insert into Members values
 ('AS369','������','15315405669','123456','0351694','�й�����ѧ','9965')
,('AS370','����','15343405669','123456','0351695','�й������ѧ','5326')
,('AS371','����PT','14358405669','123456','0351696','�й�ҽ�ƴ�ѧ','1226')
,('AS372','������','15315454388','123456','0351697','�й��Ƽ���ѧ','2356')
,('AS373','�ֽ�ͷ','13453405669','123456','0351698','�й�ս�Դ�ѧ','1246')
,('AS374','������','15874305659','123456','0351699','�й�������ѧ','5566')
,('AS375','�����','13315453549','123456','0351710','�й��з���ѧ','1526')
 --��Ա��Ϣ��
  create table MembersMessage
(
	MembersMessageID      int primary key identity, --��Ա��Ϣ����id
	MembersID             int,						--��Ա���id
	MembersMessageURL     varchar(MAX),			    --ͼƬ·��
	MembersMessageName    varchar(50),				--��Ա�û���
	MembersMessageSign	  varchar(200)				--��Ա��ǩ
)
insert into MembersMessage values
 ('1','','������','������VIP9')
,('2','','����','����VIP8')
,('3','','����PT','����PTVIP4')
,('4','','������','������VIP3')
,('5','','�ֽ�ͷ','�ֽ�ͷVIP5')
,('6','','������','������VIP7')
,('7','','�����','�����VIP1')
--�̼ұ�
create table Merchants
(
	MerchantsID            int primary key identity,   --�̼�����id
	MerchantsAccount       varchar(100),			   --�̼��˻�
	MerchantsWeChat        varchar(100),			   --�̼�΢�ź�
	MerchantsNumber        varchar(100),			   --�̼��ֻ���
	MerchantsPassword      varchar(100),			   --�̼�����
	MerchantsMoney	       Money      			       --�̼����
)

insert into Merchants values
 ('XL013','13615462150','13615462150','123456','365512')
,('DG014','13615462151','13615462151','123456','454365')
,('JD015','13615462152','13615462152','123456','999385')
,('RL016','13615462153','13615462153','123456','565665')
,('LC017','13615462154','13615462154','123456','184365')
,('XC018','13615462155','13615462155','123456','124365')
,('PS019','13615462156','13615462156','123456','394365')
--�̼���Ϣ��
create table MerchantsMessage
(
	MerchantsMessageID            int primary key identity, --�̼���Ϣ����id
	MerchantsID                   int,                      --�̼����id
	MerchantsMessageURL           varchar(MAX),			    --ͼƬ·��
	MerchantsMessageName          varchar(50),				--�̼��û���
	MerchantsMessageSign	      varchar(200)				--�̼Ҹ�ǩ
)

insert into MerchantsMessage values
 ('1','#','����','�����������˴�������')
,('2','#','����','�����������˴�������')
,('3','#','����','�����������˴�������')
,('4','#','����','�����������˴�������')
,('5','#','����','�����������˴�������')
,('6','#','����','�����������˴�������')
,('7','#','����','�����������˴�������')
--�̼����ͱ�
create table MerchantsTypes
(
	MerchantsTypesID            int primary key identity, --�̼���������id
	MerchantsTypesName          varchar(50)				  --�̼�����
)
insert into MerchantsTypes values
 ('����')
,('����')
,('����')
--�̼����͹�����
create table MerchantsRelevance
(
	MerchantsRelevanceID            int primary key identity, --�̼����͹�ϵ����id
	MerchantsTypesID                int,					  --�̼�����id
	MerchantsID						int						  --�̼���Ϣid
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

--��ע��
create table Attentions
(
	AttentionsID            int primary key identity,         --�̼�����id
	MerchantsMessageID      int,						      --�̼���Ϣ����id
	MembersMessageID		int						          --��Ա��Ϣ����id
)
insert into Attentions values
 ('1','1')
,('3','2')
,('1','3')
,('2','4')
,('1','5')
,('3','6')
,('3','7')
--��Ʒ��
create table Cuisines
(
	CuisinesID					  int primary key identity,         --��ƷID����id
	MerchantsMessageID            int,								--�̼���Ϣ����id
	CuisinesURL					  varchar(MAX),			            --ͼƬ·��
	CuisinesName				  varchar(50),				        --��Ʒ��
	CuisinesNum					  int,								--��Ʒ����
	CuisinesPrice                 money,                            --��Ʒ����
	CuisinesSign				  varchar(200)				        --��Ʒ��ǩ
)		
insert into Cuisines values
 ('1','#','��������','300','20','�������������ع�')
,('2','#','��ݮ����','100','50','��ݮ������ʱ����')
,('3','#','���̼�60','200','60','���̼��ؼ��Ż�')
,('4','#','��˾ƴ��','100','20','��˾ƴ���ؼ��Ż�')
,('5','#','�ݽ���צ','500','20','�ݽ���צ�ؼ��Ż�')
,('6','#','����ƴ��','300','30','����ƴ���ؼ��Ż�')
,('7','#','ţ������','100','40','ţ�������ؼ��Ż�')						
--����
create table Category
(
	CategoryID					  int primary key identity,         --�������id
	CategoryName				  varchar(50)				        --�����
)	
insert into Category values('����'),('����'),('����'),('����'),('±��'),('����'),('����')
--��Ʒ����		
create table CuisinesCategory
(
	CuisinesCategoryID			  int primary key identity,         --��Ʒ�������id
	CuisinesID					  int,								--��Ʒid
	CategoryID					  int				                --���id
)
insert into CuisinesCategory values
 ('1','1')
,('2','2')
,('3','3')
,('4','4')
,('5','5')
,('6','6')
,('7','7')
--��ζ��
create table Tastes
(
	TastesID					  int primary key identity,         --��ζ����id
	TastesName				      varchar(50)				        --��ζ��
)
insert into Tastes values('����'),('΢��'),('����'),('����'),('��̬��'),('΢��'),('����')
select * from Tastes
--��Ʒ��ζ��		
create table CuisinesTastes
(
	CuisinesTastesID			  int primary key identity,         --��Ʒ�������id
	CuisinesID					  int,								--��Ʒid
	TastesID     				  int				                --��ζid
)
insert into CuisinesTastes values
 ('1','4')
,('2','6')
,('3','3')
,('4','2')
,('5','3')
,('6','6')
,('7','5')
--���۱�
create table Comment
(
	CommentID			  int primary key identity,         --��������id
	CuisinesID			  int,								--��Ʒid
	CommentState		  int,								--�ȼ� 0 �� 1�� 2�� 3�� 4�� 5��
	CuisinesComment       varchar(100),						--����
)
insert into Comment values
 ('1','5','�ǳ��ó�')
,('2','5','�ǳ��ó�')
,('3','5','�ǳ��ó�')
,('4','5','�ǳ��ó�')
,('5','5','�ǳ��ó�')
,('6','5','�ǳ��ó�')
,('7','5','�ǳ��ó�')
--��������
create table OneTeceipts
(
	OneTeceiptsID		    int primary key identity,             --������������id
	MembersMessageID        int,								  --��Աid
	OneTeceiptsCode         varchar(30),						  --�������
    OneTeceiptsTime         datetime,							  --����ʱ�� 
	OneTeceiptsState        int                                   --����״̬    --0δ���    1���
)
insert into OneTeceipts values
 ('1','XL453','2020-12-06','0')
,('2','DG245','2020-12-06','0')
,('3','JD183','2020-12-06','0')
,('4','RL254','2020-12-06','0')
,('5','LC556','2020-12-06','0')
,('6','XC667','2020-12-06','0')
,('7','PS385','2020-12-06','0')
--��������
create table TwoTeceipts
(
	TwoTeceiptsID		    int primary key identity,             --������������id
	OneTeceiptsID	        int,								  --����id
	CuisinesID              int,								  --��Ʒid
    TwoTeceiptsNum			int,							      --����
	TwoTeceiptsState        int                                   --0 δ����  1�����  2���˻�
)
insert into TwoTeceipts values
 ('1','1','10','0')
,('2','2','10','0')
,('3','3','10','0')
,('4','4','10','0')
,('5','5','10','0')
,('6','6','10','0')
,('7','7','10','0')
--��ֵ��¼��
create table PayRecord
(
	PayRecordID		    int primary key identity,             --��ֵ��¼����id
	MembersMessageID    int,								  --��Ա��Ϣid
	PayRecord           varchar(max)						  --��¼
)
insert into PayRecord values
 ('1','500')
,('2','500')
,('3','500')
,('4','500')
,('5','500')
,('6','500')
,('7','500')
--���ּ�¼��
create table IntegralRecord
(
	IntegralRecordID		    int primary key identity,             --���ּ�¼����id
	MembersMessageID            int,								  --��Ա��Ϣid
	IntegralRecords             varchar(max)						  --��¼
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