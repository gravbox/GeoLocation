--DO NOT MODIFY THIS FILE. IT IS ALWAYS OVERWRITTEN ON GENERATION.
--Data Schema

--CREATE TABLE [CanadaPostalCode]
if not exists(select * from sysobjects where name = 'CanadaPostalCode' and xtype = 'U')
CREATE TABLE [dbo].[CanadaPostalCode] (
	[RowId] [Int] IDENTITY (1, 1) NOT NULL ,
	[Latitude] [Float] NULL ,
	[PostalCode] [VarChar] (10) NOT NULL ,
	[City] [VarChar] (100) NOT NULL ,
	[Longitude] [Float] NULL ,
	CONSTRAINT [PK_CANADAPOSTALCODE] PRIMARY KEY CLUSTERED
	(
		[RowId]
	)
)

GO

--CREATE TABLE [City]
if not exists(select * from sysobjects where name = 'City' and xtype = 'U')
CREATE TABLE [dbo].[City] (
	[CityId] [Int] IDENTITY (1, 1) NOT NULL ,
	[Name] [VarChar] (100) NULL ,
	[State] [VarChar] (50) NULL ,
	[Population] [Int] NULL ,
	[ModifiedBy] [NVarchar] (50) NULL,
	[ModifiedDate] [DateTime2] CONSTRAINT [DF__CITY_MODIFIEDDATE] DEFAULT sysdatetime() NULL,
	[CreatedBy] [NVarchar] (50) NULL,
	[CreatedDate] [DateTime2] CONSTRAINT [DF__CITY_CREATEDDATE] DEFAULT sysdatetime() NULL,
	[TimeStamp] [ROWVERSION] NOT NULL,
	CONSTRAINT [PK_CITY] PRIMARY KEY CLUSTERED
	(
		[CityId]
	)
)

GO

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
--TABLE [CanadaPostalCode] ADD FIELDS
if exists(select * from sys.objects where name = 'CanadaPostalCode' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'RowId' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] ADD [RowId] [Int] IDENTITY (1, 1) NOT NULL 
if exists(select * from sys.objects where name = 'CanadaPostalCode' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Latitude' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] ADD [Latitude] [Float] NULL 
if exists(select * from sys.objects where name = 'CanadaPostalCode' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'PostalCode' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] ADD [PostalCode] [VarChar] (10) NOT NULL 
if exists(select * from sys.objects where name = 'CanadaPostalCode' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'City' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] ADD [City] [VarChar] (100) NOT NULL 
if exists(select * from sys.objects where name = 'CanadaPostalCode' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Longitude' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] ADD [Longitude] [Float] NULL 
GO
--TABLE [City] ADD FIELDS
if exists(select * from sys.objects where name = 'City' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CityId' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [CityId] [Int] IDENTITY (1, 1) NOT NULL 
if exists(select * from sys.objects where name = 'City' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Name' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [Name] [VarChar] (100) NULL 
if exists(select * from sys.objects where name = 'City' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'State' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [State] [VarChar] (50) NULL 
if exists(select * from sys.objects where name = 'City' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Population' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [Population] [Int] NULL 
GO
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

--APPEND AUDIT TRAIL CREATE FOR TABLE [City]
if exists(select * from sys.objects where name = 'City' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CreatedBy' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [CreatedBy] [NVarchar] (50) NULL
if exists(select * from sys.objects where name = 'City' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CreatedDate' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [CreatedDate] [DateTime2] CONSTRAINT [DF__CITY_CREATEDDATE] DEFAULT sysdatetime() NULL
GO

--APPEND AUDIT TRAIL MODIFY FOR TABLE [City]
if exists(select * from sys.objects where name = 'City' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ModifiedBy' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [ModifiedBy] [NVarchar] (50) NULL
if exists(select * from sys.objects where name = 'City' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ModifiedDate' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [ModifiedDate] [DateTime2] CONSTRAINT [DF__CITY_MODIFIEDDATE] DEFAULT sysdatetime() NULL
GO

--APPEND AUDIT TRAIL TIMESTAMP FOR TABLE [City]
if exists(select * from sys.objects where name = 'City' and type = 'U') and not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'TimeStamp' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [TimeStamp] [ROWVERSION] NOT NULL
GO

GO

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

--REMOVE AUDIT TRAIL CREATE FOR TABLE [CanadaPostalCode]
if exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CreatedBy' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] DROP COLUMN [CreatedBy]
if exists (select * from sys.objects where name = 'DF__CANADAPOSTALCODE_CREATEDDATE' and [type] = 'D')
ALTER TABLE [dbo].[CanadaPostalCode] DROP CONSTRAINT [DF__CANADAPOSTALCODE_CREATEDDATE]
if exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'CreatedDate' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] DROP COLUMN [CreatedDate]
GO

--REMOVE AUDIT TRAIL MODIFY FOR TABLE [CanadaPostalCode]
if exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ModifiedBy' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] DROP COLUMN [ModifiedBy]
if exists (select * from sys.objects where name = 'DF__CANADAPOSTALCODE_MODIFIEDDATE' and [type] = 'D')
ALTER TABLE [dbo].[CanadaPostalCode] DROP CONSTRAINT [DF__CANADAPOSTALCODE_MODIFIEDDATE]
if exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'ModifiedDate' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] DROP COLUMN [ModifiedDate]
GO

--REMOVE AUDIT TRAIL TIMESTAMP FOR TABLE [CanadaPostalCode]
if exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'TimeStamp' and o.name = 'CanadaPostalCode')
ALTER TABLE [dbo].[CanadaPostalCode] DROP COLUMN [TimeStamp]
GO

GO

--##SECTION END [AUDIT TRAIL REMOVE]

--##SECTION BEGIN [RENAME PK]

--RENAME EXISTING PRIMARY KEYS IF NECESSARY
DECLARE @pkfixCanadaPostalCode varchar(500)
SET @pkfixCanadaPostalCode = (SELECT top 1 i.name AS IndexName FROM sys.indexes AS i WHERE i.is_primary_key = 1 AND OBJECT_NAME(i.OBJECT_ID) = 'CanadaPostalCode')
if @pkfixCanadaPostalCode <> '' and (BINARY_CHECKSUM(@pkfixCanadaPostalCode) <> BINARY_CHECKSUM('PK_CANADAPOSTALCODE')) exec('sp_rename '''+@pkfixCanadaPostalCode+''', ''PK_CANADAPOSTALCODE''')
DECLARE @pkfixCity varchar(500)
SET @pkfixCity = (SELECT top 1 i.name AS IndexName FROM sys.indexes AS i WHERE i.is_primary_key = 1 AND OBJECT_NAME(i.OBJECT_ID) = 'City')
if @pkfixCity <> '' and (BINARY_CHECKSUM(@pkfixCity) <> BINARY_CHECKSUM('PK_CITY')) exec('sp_rename '''+@pkfixCity+''', ''PK_CITY''')
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

--PRIMARY KEY FOR TABLE [CanadaPostalCode]
if not exists(select * from sysobjects where name = 'PK_CANADAPOSTALCODE' and xtype = 'PK')
ALTER TABLE [dbo].[CanadaPostalCode] WITH NOCHECK ADD 
CONSTRAINT [PK_CANADAPOSTALCODE] PRIMARY KEY CLUSTERED
(
	[RowId]
)
GO
--PRIMARY KEY FOR TABLE [City]
if not exists(select * from sysobjects where name = 'PK_CITY' and xtype = 'PK')
ALTER TABLE [dbo].[City] WITH NOCHECK ADD 
CONSTRAINT [PK_CITY] PRIMARY KEY CLUSTERED
(
	[CityId]
)
GO
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

--DROP PRIMARY KEY FOR TABLE [__AUDIT__CANADAPOSTALCODE]
if exists(select * from sys.objects where name = 'PK___AUDIT__CANADAPOSTALCODE' and type = 'PK' and type_desc = 'PRIMARY_KEY_CONSTRAINT')
ALTER TABLE [dbo].[__AUDIT__CANADAPOSTALCODE] DROP CONSTRAINT [PK___AUDIT__CANADAPOSTALCODE]
GO

--DROP PRIMARY KEY FOR TABLE [__AUDIT__CITY]
if exists(select * from sys.objects where name = 'PK___AUDIT__CITY' and type = 'PK' and type_desc = 'PRIMARY_KEY_CONSTRAINT')
ALTER TABLE [dbo].[__AUDIT__CITY] DROP CONSTRAINT [PK___AUDIT__CITY]
GO

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
if exists(select * from sys.indexes where name = 'IDX_CANADAPOSTALCODE_POSTALCODE' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_CANADAPOSTALCODE_POSTALCODE] ON [dbo].[CanadaPostalCode]
GO

--INDEX FOR TABLE [CanadaPostalCode] COLUMNS:[PostalCode]
if not exists(select * from sys.indexes where name = 'IDX_CANADAPOSTALCODE_POSTALCODE') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'PostalCode' and o.name = 'CanadaPostalCode')
CREATE NONCLUSTERED INDEX [IDX_CANADAPOSTALCODE_POSTALCODE] ON [dbo].[CanadaPostalCode] ([PostalCode] ASC)
GO

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_CANADAPOSTALCODE_CITY' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_CANADAPOSTALCODE_CITY] ON [dbo].[CanadaPostalCode]
GO

--INDEX FOR TABLE [CanadaPostalCode] COLUMNS:[City]
if not exists(select * from sys.indexes where name = 'IDX_CANADAPOSTALCODE_CITY') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'City' and o.name = 'CanadaPostalCode')
CREATE NONCLUSTERED INDEX [IDX_CANADAPOSTALCODE_CITY] ON [dbo].[CanadaPostalCode] ([City] ASC)
GO

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_CITY_STATE' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_CITY_STATE] ON [dbo].[City]
GO

--INDEX FOR TABLE [City] COLUMNS:[State]
if not exists(select * from sys.indexes where name = 'IDX_CITY_STATE') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'State' and o.name = 'City')
CREATE NONCLUSTERED INDEX [IDX_CITY_STATE] ON [dbo].[City] ([State] ASC)
GO

--DELETE INDEX
if exists(select * from sys.indexes where name = 'IDX_CITY_NAME' and type_desc = 'CLUSTERED')
DROP INDEX [IDX_CITY_NAME] ON [dbo].[City]
GO

--INDEX FOR TABLE [City] COLUMNS:[Name]
if not exists(select * from sys.indexes where name = 'IDX_CITY_NAME') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Name' and o.name = 'City')
CREATE NONCLUSTERED INDEX [IDX_CITY_NAME] ON [dbo].[City] ([Name] ASC)
GO

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

--BEGIN DEFAULTS FOR TABLE [CanadaPostalCode]
DECLARE @defaultName varchar(max)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'CanadaPostalCode' and c.name = 'City')
if @defaultName IS NOT NULL
exec('ALTER TABLE [CanadaPostalCode] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'CanadaPostalCode' and c.name = 'Latitude')
if @defaultName IS NOT NULL
exec('ALTER TABLE [CanadaPostalCode] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'CanadaPostalCode' and c.name = 'Longitude')
if @defaultName IS NOT NULL
exec('ALTER TABLE [CanadaPostalCode] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'CanadaPostalCode' and c.name = 'PostalCode')
if @defaultName IS NOT NULL
exec('ALTER TABLE [CanadaPostalCode] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'CanadaPostalCode' and c.name = 'RowId')
if @defaultName IS NOT NULL
exec('ALTER TABLE [CanadaPostalCode] DROP CONSTRAINT ' + @defaultName)
--END DEFAULTS FOR TABLE [CanadaPostalCode]
GO

--BEGIN DEFAULTS FOR TABLE [City]
DECLARE @defaultName varchar(max)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'City' and c.name = 'CityId')
if @defaultName IS NOT NULL
exec('ALTER TABLE [City] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'City' and c.name = 'Name')
if @defaultName IS NOT NULL
exec('ALTER TABLE [City] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'City' and c.name = 'Population')
if @defaultName IS NOT NULL
exec('ALTER TABLE [City] DROP CONSTRAINT ' + @defaultName)
SET @defaultName = (SELECT d.name FROM sys.columns c inner join sys.default_constraints d on c.column_id = d.parent_column_id and c.object_id = d.parent_object_id inner join sys.objects o on d.parent_object_id = o.object_id where o.name = 'City' and c.name = 'State')
if @defaultName IS NOT NULL
exec('ALTER TABLE [City] DROP CONSTRAINT ' + @defaultName)
--END DEFAULTS FOR TABLE [City]
GO

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

