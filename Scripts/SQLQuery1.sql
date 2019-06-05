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
    [Description] varchar(2048) null,
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

merge dbo.ServiceTypes trg
using 
(
  select s.TypeName
  from 
  (
    values ('New Construction')
         , ('Renovations')
  ) s(TypeName)
) as src
on (trg.TypeName = src.TypeName)
when not matched by target then  
  insert (TypeName)
  values (src.TypeName)
  ;
go

merge dbo.[Services] trg
using 
(
  select s.TypeId
       , s.ServiceName
       , s.[Description]
  from 
  (
    values (1, 'General Contracting/Project Management', 'You have finally decided to build your dream home, a cottage, or even maybe expend your current living space by building an addition or simply re-plan your home to create an open concept layout, but you do not know where to start or what to do first?! Well, we got a good news for you, we can take your worry away and take care of all aspects and any questions or problems that might arise during this construction project. from having customs drawing to selecting your tiles and kitchen cabinets, we can do it all. All you have to do is to sit back and relax. Let us do what we do best, BUILD!')
         , (1, 'Licensed Architectural Drawings', 'Have an idea? Maybe a thought how you would like your dream home to look like?! Well, our licensed architect and designer can help you to transfer your ideas on paper, making sure it''s up-to-date with current by-laws and building codes.')
         , (1, 'Structural Wood Framing', 'Our team of exceptional carpenters will build your home, garage, deck, or anything your heart and soul desires from wood according to building codes and local by-laws the best way possible.')
         , (1, 'Foundation Forming', 'It all starts from foundation. Forming and placing proper foundation is the key to have proper frame with straight walls, leveled floors and square corners. BSCO''s team of carpenters will make sure your foundation is "dead-on" and is according to all BC Building standards.')
         , (2, 'General Contracting/Project Management', '')
         , (2, 'Structural Wood Framing', '')
         , (2, 'Demolition', 'Need your old house demolished? Or maybe just a part of it? Maybe your old deck replaced, or create an open concept feeling in your home? BSCO''s team will apply their knowledge and experience to do just that if all it needs to be done, demolish old and prepare it for new to be build.')
  
  ) s(TypeId, ServiceName, [Description])
) as src
on (trg.ServiceName = src.ServiceName)
when not matched by target then  
  insert (TypeId, ServiceName, [Description])
  values (src.TypeId, src.ServiceName, src.[Description])
  ;
go

merge [dbo].[Projects] trg
using 
(
  select p.ProjectName
       , p.[Description]
  from 
  (
    values ('Capilano Road Residence', 'Before, process and after')
         , ('White Rock, BC', null)
         , ('Fire Restoration Surrey,BC', null)
         , ('Port Coquitlam, BC', null)
         , ('Burnaby, BC', 'Townhouses frame + exterior finish')
         , ('Granville Ave Residence', null)
         , ('W20th Residence', null)
         , ('Surrey (Commercial)', null)
         , ('Highland Blvd Residence', null)
         , ('Cambridge Drive Residence', null)
  ) p(ProjectName, [Description])
) as src
on (trg.ProjectName = src.ProjectName)
when not matched by target then  
  insert (ProjectName, [Description])
  values (src.ProjectName, src.[Description])
  ;
go

merge dbo.[ProjectSections] trg
using 
(
  select p.ProjectId
       , p.SectionName 
  from 
  (
    values (1, null)
         , (2, null)
         , (3, 'Before')
         , (3, 'After')
         , (4, null)
         , (5, null)
         , (6, 'Before')
         , (6, 'After')
         , (7, null)
         , (8, 'Building #1')
         , (8, 'Building #2')
         , (8, 'Building #3')
         , (9, null)
         , (10, null)
  ) p(ProjectId, SectionName)
) as src
on (trg.SectionName = src.SectionName)
when not matched by target then  
  insert (SectionName, ProjectId)
  values (src.SectionName, src.ProjectId)
  ;
go

merge dbo.[ProjectSectionImages] trg
using 
(
  select p.SectionId
       , p.[Image]
  from 
  (
    values (1, '22-p.jpg')
         , (1, '23-p.jpg')
         , (1, '24-p.jpg')
         , (1, '58-p.jpg')
         , (2, '30-p.jpg')
         , (2, '31-p.jpg')
         , (2, '32-p.jpg')
         , (2, '33-p.jpg')
         , (2, '34-p.jpg')
         , (3, '41-p.jpg')
         , (3, '61-p.jpg')
         , (3, '62-p.jpg')
         , (3, '63-p.jpg')
         , (3, '64-p.jpg')
         , (3, '65-p.jpg')
         , (3, '66-p.jpg')
         , (4, '40-p.jpg')
         , (4, '67-p.jpg')
         , (4, '68-p.jpg')
         , (4, '69-p.jpg')
         , (5, '51-p.jpg')
         , (5, '52-p.jpg')
         , (6, '54-p.jpg')
         , (6, '55-p.jpg')
         , (7, '87-p.jpg')
         , (7, '88-p.jpg')
         , (7, '112-p.jpg')
         , (8, '89-p.jpg')
         , (8, '90-p.jpg')
         , (8, '113-p.jpg')
         , (9, '72-p.jpg')
         , (9, '73-p.jpg')
         , (9, '109-p.jpg')
         , (9, '110-p.jpg')
         , (9, '111-l.jpg')
         , (10, '75-p.jpg')
         , (10, '76-p.jpg')
         , (11, '78-p.jpg')
         , (11, '79-p.jpg')
         , (11, '94-p.jpg')
         , (11, '95-p.jpg')
         , (12, '92-p.jpg')
         , (12, '93-p.jpg')
         , (13, '97-p.jpg')
         , (13, '98-p.jpg')
         , (13, '99-p.jpg')
         , (13, '100-p.jpg')
         , (13, '101-p.jpg')
         , (13, '102-p.jpg')
         , (14, '104-p.jpg')
         , (14, '105-p.jpg')
         , (14, '106-p.jpg')
         , (14, '107-p.jpg')
         , (14, '108-p.jpg')
  ) p(SectionId, [Image])
) as src
on (trg.[Image] = src.[Image])
when not matched by target then  
  insert (SectionId, [Image])
  values (src.SectionId, src.[Image])
  ;
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
    values ('Capilano Road Residence', null, '22-p.jpg', '/Home/Works/1')
         , ('Highland Blvd Residence', null, '30-p.jpg', '/Home/Works/9')
         , ('W20th Residence', null, '51-p.jpg', '/Home/Works/7')
         , ('Burnaby, BC', null, '54-p.jpg', '/Home/Works/5')
         , ('Port Coquitlam, BC', null, '72-p.jpg', '/Home/Works/4')
         , ('White Rock, BC', null, '97-p.jpg', '/Home/Works/2')
         , ('Capilano Road Residence', null, '104-p.jpg', '/Home/Works/1')
  ) n(Header, [Description], [Image], Link)
) as src
on (trg.Header = src.Header)
when not matched by target then  
  insert (Header, Description, Image, Link)
  values (src.Header, src.[Description], src.[Image], src.Link)
  ;
go