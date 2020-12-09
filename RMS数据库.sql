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
	MembersAddressID	 int,       			                   --��ԱID
	MembersSite	         varchar(100),			   --��Ա��ַ
	MembersMoney	     Money      			   --��Ա���
 )
 insert into Members values
 ('AS369','LI��Ů','15315405669','1314520','LI11','�����������й�����ѧ','9965489')
,('','','','','','','')

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
 ('','','','')
,('','','','')
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
insert into Merchants values('','','','','')
--�̼���Ϣ��
create table MerchantsMessage
(
	MerchantsMessageID            int primary key identity, --�̼���Ϣ����id
	MerchantsID                   int,                      --�̼����id
	MerchantsMessageURL           varchar(MAX),			    --ͼƬ·��
	MerchantsMessageName          varchar(50),				--�̼��û���
	MerchantsMessageSign	      varchar(200)				--�̼Ҹ�ǩ
)
insert into MerchantsMessage values('','','','')
--�̼����ͱ�
create table MerchantsTypes
(
	MerchantsTypesID            int primary key identity, --�̼���������id
	MerchantsTypesName          varchar(50)				  --�̼�����
)
insert into MerchantsTypes values('')
--�̼����͹�����
create table MerchantsRelevance
(
	MerchantsRelevanceID            int primary key identity, --�̼����͹�ϵ����id
	MerchantsTypesID                int,					  --�̼�����id
	MerchantsID						int						  --�̼���Ϣid
)
insert into MerchantsRelevance values('','')
--��ע��
create table Attentions
(
	AttentionsID            int primary key identity,         --�̼�����id
	MerchantsMessageID      int,						      --�̼���Ϣ����id
	MembersMessageID		int						          --��Ա��Ϣ����id
)
insert into Attentions values('','')
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
insert into Cuisines values('','','','','','')					
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
insert into CuisinesCategory values('','')
--��ζ��
create table Tastes
(
	TastesID					  int primary key identity,         --��ζ����id
	TastesName				      varchar(50)				        --��ζ��
)
insert into Tastes values('����'),('΢��'),('����'),('����'),('��̬��')
--��Ʒ��ζ��		
create table CuisinesTastes
(
	CuisinesTastesID			  int primary key identity,         --��Ʒ�������id
	CuisinesID					  int,								--��Ʒid
	TastesID     				  int				                --���id
)
insert into CuisinesTastes values('','')
--���۱�
create table Comment
(
	CommentID			  int primary key identity,         --��������id
	CuisinesID			  int,								--��Ʒid
	CommentState		  int,								--�ȼ� 0 �� 1�� 2�� 3�� 4�� 5��
	CuisinesComment       varchar(100),						--����
)
insert into Comment values('','','')	
--��������
create table OneTeceipts
(
	OneTeceiptsID		    int primary key identity,             --������������id
	MembersMessageID        int,								  --��Աid
	OneTeceiptsCode         varchar(30),						  --�������
    OneTeceiptsTime         datetime,							  --����ʱ�� 
	OneTeceiptsState        int                                   --����״̬    --0δ���    1���
)
insert into OneTeceipts values('','','','')	
--��������
create table TwoTeceipts
(
	TwoTeceiptsID		    int primary key identity,             --������������id
	OneTeceiptsID	        int,								  --����id
	CuisinesID              int,								  --��Ʒid
    TwoTeceiptsNum			int,							      --����
	TwoTeceiptsState        int                                   --0 δ����  1�����  2���˻�
)
insert into TwoTeceipts values('','','','')	
--��ֵ��¼��
create table PayRecord
(
	PayRecordID		    int primary key identity,             --��ֵ��¼����id
	MembersMessageID    int,								  --��Ա��Ϣid
	PayRecord           varchar(max)						  --��¼
)
insert into PayRecord values('','')
--���ּ�¼��
create table IntegralRecord
(
	IntegralRecordID		    int primary key identity,             --���ּ�¼����id
	MembersMessageID            int,								  --��Ա��Ϣid
	IntegralRecords             varchar(max)						  --��¼
)
insert into IntegralRecord values('','')