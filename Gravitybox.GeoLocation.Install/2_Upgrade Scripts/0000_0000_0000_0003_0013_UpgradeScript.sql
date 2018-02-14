--Generated Upgrade For Version 0.0.0.3.13
--Generated on 2018-02-14 13:40:03

--CREATE TABLE [City]
if not exists(select * from sysobjects where name = 'City' and xtype = 'U')
CREATE TABLE [dbo].[City] (
	[CityId] [Int] IDENTITY (1, 1) NOT NULL ,
	[Name] [VarChar] (100) NULL ,
	[State] [VarChar] (50) NULL ,
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
--PRIMARY KEY FOR TABLE [City]
if not exists(select * from sysobjects where name = 'PK_CITY' and xtype = 'PK')
ALTER TABLE [dbo].[City] WITH NOCHECK ADD 
CONSTRAINT [PK_CITY] PRIMARY KEY CLUSTERED
(
	[CityId]
)

GO
