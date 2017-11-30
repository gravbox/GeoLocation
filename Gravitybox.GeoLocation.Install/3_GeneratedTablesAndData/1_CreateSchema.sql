--DO NOT MODIFY THIS FILE. IT IS ALWAYS OVERWRITTEN ON GENERATION.
--Data Schema

--CREATE TABLE [State]
if not exists(select * from sysobjects where name = 'State' and xtype = 'U')
CREATE TABLE [dbo].[State] (
	[Abbr] [VarChar] (2) NOT NULL ,
	[Description] [VarChar] (1000) NULL ,
	[Name] [VarChar] (128) NOT NULL ,
	[StateId] [Int] IDENTITY (1, 1) NOT NULL ,
	[ModifiedBy] [NVarchar] (50) NULL,
	[ModifiedDate] [DateTime2] CONSTRAINT [DF__STATE_MODIFIEDDATE] DEFAULT sysdatetime() NULL,
	[CreatedBy] [NVarchar] (50) NULL,
	[CreatedDate] [DateTime2] CONSTRAINT [DF__STATE_CREATEDDATE] DEFAULT sysdatetime() NULL,
	[TimeStamp] [ROWVERSION] NOT NULL,
	CONSTRAINT [PK_STATE] PRIMARY KEY CLUSTERED
	(
		[StateId]
	)
)

GO

--CREATE TABLE [Zip]
if not exists(select * from sysobjects where name = 'Zip' and xtype = 'U')
CREATE TABLE [dbo].[Zip] (
	[City] [VarChar] (50) NOT NULL ,
	[Latitude] [Float] NULL ,
	[Longitude] [Float] NULL ,
	[Name] [VarChar] (10) NOT NULL ,
	[State] [VarChar] (50) NOT NULL ,
	[ZipId] [Int] IDENTITY (1, 1) NOT NULL ,
	[Population] [Int] NULL ,
	[ModifiedBy] [NVarchar] (50) NULL,
	[ModifiedDate] [DateTime2] CONSTRAINT [DF__ZIP_MODIFIEDDATE] DEFAULT sysdatetime() NULL,
	[CreatedBy] [NVarchar] (50) NULL,
	[CreatedDate] [DateTime2] CONSTRAINT [DF__ZIP_CREATEDDATE] DEFAULT sysdatetime() NULL,
	[TimeStamp] [ROWVERSION] NOT NULL,
	CONSTRAINT [PK_ZIP] PRIMARY KEY CLUSTERED
	(
		[ZipId]
	)
)

GO

--##SECTION BEGIN [FIELD CREATE]
--TABLE [State] ADD FIELDS
if exists(select * from sys.objects where name = 'State' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Abbr' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [Abbr] [VarChar] (2) NOT NULL 
if exists(select * from sys.objects where name = 'State' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Description' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [Description] [VarChar] (1000) NULL 
if exists(select * from sys.objects where name = 'State' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Name' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [Name] [VarChar] (128) NOT NULL 
if exists(select * from sys.objects where name = 'State' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'StateId' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [StateId] [Int] IDENTITY (1, 1) NOT NULL 
GO
--TABLE [Zip] ADD FIELDS
if exists(select * from sys.objects where name = 'Zip' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'City' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [City] [VarChar] (50) NOT NULL 
if exists(select * from sys.objects where name = 'Zip' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Latitude' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [Latitude] [Float] NULL 
if exists(select * from sys.objects where name = 'Zip' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Longitude' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [Longitude] [Float] NULL 
if exists(select * from sys.objects where name = 'Zip' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Name' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [Name] [VarChar] (10) NOT NULL 
if exists(select * from sys.objects where name = 'Zip' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'State' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [State] [VarChar] (50) NOT NULL 
if exists(select * from sys.objects where name = 'Zip' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ZipId' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [ZipId] [Int] IDENTITY (1, 1) NOT NULL 
if exists(select * from sys.objects where name = 'Zip' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Population' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [Population] [Int] NULL 
GO
--##SECTION END [FIELD CREATE]

--##SECTION BEGIN [AUDIT TRAIL CREATE]

--APPEND AUDIT TRAIL CREATE FOR TABLE [State]
if exists(select * from sys.objects where name = 'State' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CreatedBy' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [CreatedBy] [NVarchar] (50) NULL
if exists(select * from sys.objects where name = 'State' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CreatedDate' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [CreatedDate] [DateTime2] CONSTRAINT [DF__STATE_CREATEDDATE] DEFAULT sysdatetime() NULL
GO

--APPEND AUDIT TRAIL MODIFY FOR TABLE [State]
if exists(select * from sys.objects where name = 'State' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ModifiedBy' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [ModifiedBy] [NVarchar] (50) NULL
if exists(select * from sys.objects where name = 'State' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ModifiedDate' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [ModifiedDate] [DateTime2] CONSTRAINT [DF__STATE_MODIFIEDDATE] DEFAULT sysdatetime() NULL
GO

--APPEND AUDIT TRAIL TIMESTAMP FOR TABLE [State]
if exists(select * from sys.objects where name = 'State' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'TimeStamp' and o.name = 'State')
ALTER TABLE [dbo].[State] ADD [TimeStamp] [ROWVERSION] NOT NULL
GO

GO

--APPEND AUDIT TRAIL CREATE FOR TABLE [Zip]
if exists(select * from sys.objects where name = 'Zip' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CreatedBy' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [CreatedBy] [NVarchar] (50) NULL
if exists(select * from sys.objects where name = 'Zip' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CreatedDate' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [CreatedDate] [DateTime2] CONSTRAINT [DF__ZIP_CREATEDDATE] DEFAULT sysdatetime() NULL
GO

--APPEND AUDIT TRAIL MODIFY FOR TABLE [Zip]
if exists(select * from sys.objects where name = 'Zip' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ModifiedBy' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [ModifiedBy] [NVarchar] (50) NULL
if exists(select * from sys.objects where name = 'Zip' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ModifiedDate' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [ModifiedDate] [DateTime2] CONSTRAINT [DF__ZIP_MODIFIEDDATE] DEFAULT sysdatetime() NULL
GO

--APPEND AUDIT TRAIL TIMESTAMP FOR TABLE [Zip]
if exists(select * from sys.objects where name = 'Zip' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'TimeStamp' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [TimeStamp] [ROWVERSION] NOT NULL
GO

GO

--##SECTION END [AUDIT TRAIL CREATE]

--##SECTION BEGIN [AUDIT TRAIL REMOVE]

--##SECTION END [AUDIT TRAIL REMOVE]

--##SECTION BEGIN [RENAME PK]

--RENAME EXISTING PRIMARY KEYS IF NECESSARY
DECLARE @pkfixState varchar(500)
SET @pkfixState = (SELECT top 1 i.name AS IndexName FROM sys.indexes AS i WHERE i.is_primary_key = 1 AND OBJECT_NAME(i.OBJECT_ID) = 'State')
if @pkfixState <> '' and (BINARY_CHECKSUM(@pkfixState) <> BINARY_CHECKSUM('PK_STATE')) exec('sp_rename '''+@pkfixState+''', ''PK_STATE''')
DECLARE @pkfixZip varchar(500)
SET @pkfixZip = (SELECT top 1 i.name AS IndexName FROM sys.indexes AS i WHERE i.is_primary_key = 1 AND OBJECT_NAME(i.OBJECT_ID) = 'Zip')
if @pkfixZip <> '' and (BINARY_CHECKSUM(@pkfixZip) <> BINARY_CHECKSUM('PK_ZIP')) exec('sp_rename '''+@pkfixZip+''', ''PK_ZIP''')
GO

--##SECTION END [RENAME PK]

--##SECTION BEGIN [DROP PK]

--##SECTION END [DROP PK]

--##SECTION BEGIN [CREATE PK]

--PRIMARY KEY FOR TABLE [State]
if not exists(select * from sysobjects where name = 'PK_STATE' and xtype = 'PK')
ALTER TABLE [dbo].[State] WITH NOCHECK ADD 
CONSTRAINT [PK_STATE] PRIMARY KEY CLUSTERED
(
	[StateId]
)
GO
--PRIMARY KEY FOR TABLE [Zip]
if not exists(select * from sysobjects where name = 'PK_ZIP' and xtype = 'PK')
ALTER TABLE [dbo].[Zip] WITH NOCHECK ADD 
CONSTRAINT [PK_ZIP] PRIMARY KEY CLUSTERED
(
	[ZipId]
)
GO
--##SECTION END [CREATE PK]

--##SECTION BEGIN [AUDIT TABLES PK]

--DROP PRIMARY KEY FOR TABLE [__AUDIT__STATE]
if exists(select * from sys.objects where name = 'PK___AUDIT__STATE' and type = 'PK' and type_desc = 'PRIMARY_KEY_CONSTRAINT')
ALTER TABLE [dbo].[__AUDIT__STATE] DROP CONSTRAINT [PK___AUDIT__STATE]
GO

--DROP PRIMARY KEY FOR TABLE [__AUDIT__ZIP]
if exists(select * from sys.objects where name = 'PK___AUDIT__ZIP' and type = 'PK' and type_desc = 'PRIMARY_KEY_CONSTRAINT')
ALTER TABLE [dbo].[__AUDIT__ZIP] DROP CONSTRAINT [PK___AUDIT__ZIP]
GO

--##SECTION END [AUDIT TABLES PK]

--##SECTION BEGIN [CREATE INDEXES]

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_STATE_ABBR' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_STATE_ABBR] ON [dbo].[State]
GO

--INDEX FOR TABLE [State] COLUMNS:[Abbr]
if not exists(select * from sys.indexes where name = 'IDX_STATE_ABBR') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Abbr' and o.name = 'State')
CREATE NONCLUSTERED INDEX [IDX_STATE_ABBR] ON [dbo].[State] ([Abbr] ASC)
GO

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_STATE_NAME' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_STATE_NAME] ON [dbo].[State]
GO

--INDEX FOR TABLE [State] COLUMNS:[Name]
if not exists(select * from sys.indexes where name = 'IDX_STATE_NAME') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Name' and o.name = 'State')
CREATE NONCLUSTERED INDEX [IDX_STATE_NAME] ON [dbo].[State] ([Name] ASC)
GO

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_ZIP_CITY' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_ZIP_CITY] ON [dbo].[Zip]
GO

--INDEX FOR TABLE [Zip] COLUMNS:[City]
if not exists(select * from sys.indexes where name = 'IDX_ZIP_CITY') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'City' and o.name = 'Zip')
CREATE NONCLUSTERED INDEX [IDX_ZIP_CITY] ON [dbo].[Zip] ([City] ASC)
GO

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_ZIP_NAME' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_ZIP_NAME] ON [dbo].[Zip]
GO

--INDEX FOR TABLE [Zip] COLUMNS:[Name]
if not exists(select * from sys.indexes where name = 'IDX_ZIP_NAME') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Name' and o.name = 'Zip')
CREATE NONCLUSTERED INDEX [IDX_ZIP_NAME] ON [dbo].[Zip] ([Name] ASC)
GO

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_ZIP_STATE' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_ZIP_STATE] ON [dbo].[Zip]
GO

--INDEX FOR TABLE [Zip] COLUMNS:[State]
if not exists(select * from sys.indexes where name = 'IDX_ZIP_STATE') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'State' and o.name = 'Zip')
CREATE NONCLUSTERED INDEX [IDX_ZIP_STATE] ON [dbo].[Zip] ([State] ASC)
GO

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_ZIP_POPULATION' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_ZIP_POPULATION] ON [dbo].[Zip]
GO

--INDEX FOR TABLE [Zip] COLUMNS:[Population]
if not exists(select * from sys.indexes where name = 'IDX_ZIP_POPULATION') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Population' and o.name = 'Zip')
CREATE NONCLUSTERED INDEX [IDX_ZIP_POPULATION] ON [dbo].[Zip] ([Population] ASC)
GO

--##SECTION END [CREATE INDEXES]

--##SECTION BEGIN [TENANT INDEXES]

--##SECTION END [TENANT INDEXES]

--##SECTION BEGIN [REMOVE DEFAULTS]

--BEGIN DEFAULTS FOR TABLE [State]
DECLARE @defaultName varchar(max)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'State' and c.name = 'Abbr')
if @defaultName IS NOT NULL
exec('ALTER TABLE [State] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'State' and c.name = 'Description')
if @defaultName IS NOT NULL
exec('ALTER TABLE [State] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'State' and c.name = 'Name')
if @defaultName IS NOT NULL
exec('ALTER TABLE [State] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'State' and c.name = 'StateId')
if @defaultName IS NOT NULL
exec('ALTER TABLE [State] DROP CONSTRAINT ' + @defaultName)
--END DEFAULTS FOR TABLE [State]
GO

--BEGIN DEFAULTS FOR TABLE [Zip]
DECLARE @defaultName varchar(max)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'Zip' and c.name = 'City')
if @defaultName IS NOT NULL
exec('ALTER TABLE [Zip] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'Zip' and c.name = 'Latitude')
if @defaultName IS NOT NULL
exec('ALTER TABLE [Zip] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'Zip' and c.name = 'Longitude')
if @defaultName IS NOT NULL
exec('ALTER TABLE [Zip] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'Zip' and c.name = 'Name')
if @defaultName IS NOT NULL
exec('ALTER TABLE [Zip] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'Zip' and c.name = 'Population')
if @defaultName IS NOT NULL
exec('ALTER TABLE [Zip] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'Zip' and c.name = 'State')
if @defaultName IS NOT NULL
exec('ALTER TABLE [Zip] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'Zip' and c.name = 'ZipId')
if @defaultName IS NOT NULL
exec('ALTER TABLE [Zip] DROP CONSTRAINT ' + @defaultName)
--END DEFAULTS FOR TABLE [Zip]
GO

--##SECTION END [REMOVE DEFAULTS]

--##SECTION BEGIN [CREATE DEFAULTS]

--##SECTION END [CREATE DEFAULTS]

if not exists(select * from sys.objects where [name] = '__nhydrateschema' and [type] = 'U')
BEGIN
CREATE TABLE [__nhydrateschema] (
[dbVersion] [varchar] (50) NOT NULL,
[LastUpdate] [datetime] NOT NULL,
[ModelKey] [uniqueidentifier] NOT NULL,
[History] [nvarchar](max) NOT NULL
)
if not exists(select * from sys.objects where [name] = '__pk__nhydrateschema' and [type] = 'PK')
ALTER TABLE [__nhydrateschema] WITH NOCHECK ADD CONSTRAINT [__pk__nhydrateschema] PRIMARY KEY CLUSTERED ([ModelKey])
END
GO

if not exists(select * from sys.objects where name = '__nhydrateobjects' and [type] = 'U')
CREATE TABLE [dbo].[__nhydrateobjects]
(
	[rowid] [bigint] IDENTITY(1,1) NOT NULL,
	[id] [uniqueidentifier] NULL,
	[name] [nvarchar](450) NOT NULL,
	[type] [varchar](10) NOT NULL,
	[schema] [nvarchar](450) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[Hash] [varchar](32) NULL,
	[ModelKey] [uniqueidentifier] NOT NULL,
)

if not exists(select * from sys.indexes where name = '__ix__nhydrateobjects_name')
CREATE NONCLUSTERED INDEX [__ix__nhydrateobjects_name] ON [dbo].[__nhydrateobjects]
(
	[name] ASC
)

if not exists(select * from sys.indexes where name = '__ix__nhydrateobjects_schema')
CREATE NONCLUSTERED INDEX [__ix__nhydrateobjects_schema] ON [dbo].[__nhydrateobjects] 
(
	[schema] ASC
)

if not exists(select * from sys.indexes where name = '__ix__nhydrateobjects_type')
CREATE NONCLUSTERED INDEX [__ix__nhydrateobjects_type] ON [dbo].[__nhydrateobjects] 
(
	[type] ASC
)

if not exists(select * from sys.indexes where name = '__ix__nhydrateobjects_modelkey')
CREATE NONCLUSTERED INDEX [__ix__nhydrateobjects_modelkey] ON [dbo].[__nhydrateobjects] 
(
	[ModelKey] ASC
)

if not exists(select * from sys.indexes where name = '__pk__nhydrateobjects')
ALTER TABLE [dbo].[__nhydrateobjects] ADD CONSTRAINT [__pk__nhydrateobjects] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)
GO

