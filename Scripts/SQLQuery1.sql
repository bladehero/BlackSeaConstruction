if not exists (select name from master.dbo.sysdatabases where name = 'BlackSeaConstructionDatabase')
  create database BlackSeaConstructionDatabase;
go

use BlackSeaConstructionDatabase;
go

if not exists (select 1 
               from sys.tables t 
               where t.name='News' 
               and t.schema_id = schema_id('dbo'))
  create table [dbo].[News]
  (
    Id int not null primary key identity,
    Header varchar(64) not null,
    [Description] varchar(256) null,
    [Image] varchar(512) null,
    Link varchar(max) not null,
    DateCreated datetime not null default(getdate()),
    DateModified datetime not null default(getdate()),
    IsDeleted bit not null default(0)
  );
go

if not exists (select 1 
               from sys.tables t 
               where t.name='ServiceTypes' 
               and t.schema_id = schema_id('dbo'))
  create table [dbo].[ServiceTypes]
  (
    Id int not null primary key identity,
    [TypeName] varchar(128) not null,
    DateCreated datetime not null default(getdate()),
    DateModified datetime not null default(getdate()),
    IsDeleted bit not null default(0)
  );
go

if not exists (select 1 
               from sys.tables t 
               where t.name='Services' 
               and t.schema_id = schema_id('dbo'))
  create table [dbo].[Services]
  (
    Id int not null primary key identity,
    ServiceName varchar(128) not null,
    [Description] varchar(512) null,
    TypeId int not null foreign key references [dbo].[ServiceTypes](Id),
    DateCreated datetime not null default(getdate()),
    DateModified datetime not null default(getdate()),
    IsDeleted bit not null default(0)
  );
go

if not exists (select 1 
               from sys.tables t 
               where t.name='ServiceImages' 
               and t.schema_id = schema_id('dbo'))
  create table [dbo].[ServiceImages]
  (
    Id int not null primary key identity,
    ServiceId int not null foreign key references [dbo].[Services](Id),
    [Image] varchar(512) not null,
    DateCreated datetime not null default(getdate()),
    DateModified datetime not null default(getdate()),
    IsDeleted bit not null default(0)
  );
go

if not exists (select 1 
               from sys.tables t 
               where t.name='Projects' 
               and t.schema_id = schema_id('dbo'))
  create table [dbo].[Projects]
  (
    Id int not null primary key identity,
    ProjectName varchar(64) not null,
    [Description] varchar(max) null,
    DateCreated datetime not null default(getdate()),
    DateModified datetime not null default(getdate()),
    IsDeleted bit not null default(0)
  );
go

if not exists (select 1 
               from sys.tables t 
               where t.name='ProjectSections' 
               and t.schema_id = schema_id('dbo'))
  create table [dbo].[ProjectSections]
  (
    Id int not null primary key identity,
    SectionName varchar(128) null,
    [Description] varchar(512) null,
    ProjectId int not null foreign key references [dbo].[Projects](Id),
    DateCreated datetime not null default(getdate()),
    DateModified datetime not null default(getdate()),
    IsDeleted bit not null default(0)
  );
go

if not exists (select 1 
               from sys.tables t 
               where t.name='ProjectSectionImages' 
               and t.schema_id = schema_id('dbo'))
  create table [dbo].[ProjectSectionImages]
  (
    Id int not null primary key identity,
    SectionId int not null foreign key references [dbo].[ProjectSections](Id),
    [Image] varchar(512) not null,
    DateCreated datetime not null default(getdate()),
    DateModified datetime not null default(getdate()),
    IsDeleted bit not null default(0)
  );
go

if not exists (select 1 
               from sys.tables t 
               where t.name='Messages' 
               and t.schema_id = schema_id('dbo'))
  create table [dbo].[Messages]
  (
    Id int not null primary key identity,
    [FirstName] nvarchar(100) null, 
    [LastName] nvarchar(100) null, 
    [Email] nvarchar(100) not null, 
    [Phone] char(10) null, 
    [Subject] nvarchar(128) null,
    [Text] nvarchar(2048) not null,
    [Status] char(1) not null default('P') check([Status] in ('P', 'C', 'R')), -- P - pending, C - completed, R - rejected
    DateCreated datetime not null default(getdate()),
    DateModified datetime not null default(getdate()),
    IsDeleted bit not null default(0)
  );
go

merge dbo.News trg
using 
(
  select n.Header
       , n.[Description]
       , n.[Image]
       , n.Link
  from 
  (
    values ('Header', 'Description', null, 'http://facebook.com')
         , ('Header1', 'Description1', null, 'http://google.com')
  ) n(Header, [Description], [Image], Link)
) as src
on (trg.Header = src.Header)
when not matched by target then  
  insert (Header, Description, Image, Link)
  values (src.Header, src.[Description], src.[Image], src.Link)
  ;
go

