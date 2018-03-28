--Generated Upgrade For Version 0.0.0.3.17
--Generated on 2018-03-28 16:00:35

--CREATE TABLE [CanadaPostalCode]
if not exists(select * from sysobjects where name = 'CanadaPostalCode' and xtype = 'U')
CREATE TABLE [dbo].[CanadaPostalCode] (
	[RowId] [Int] IDENTITY (1, 1) NOT NULL ,
	[Latitude] [Float] NULL ,
	[PostalCode] [VarChar] (10) NOT NULL ,
	[City] [VarChar] (100) NOT NULL ,
	[Longitude] [Float] NULL ,
	[ModifiedBy] [NVarchar] (50) NULL,
	[ModifiedDate] [DateTime2] CONSTRAINT [DF__CANADAPOSTALCODE_MODIFIEDDATE] DEFAULT sysdatetime() NULL,
	[CreatedBy] [NVarchar] (50) NULL,
	[CreatedDate] [DateTime2] CONSTRAINT [DF__CANADAPOSTALCODE_CREATEDDATE] DEFAULT sysdatetime() NULL,
	[TimeStamp] [ROWVERSION] NOT NULL,
	CONSTRAINT [PK_CANADAPOSTALCODE] PRIMARY KEY CLUSTERED
	(
		[RowId]
	)
)

GO
--PRIMARY KEY FOR TABLE [CanadaPostalCode]
if not exists(select * from sysobjects where name = 'PK_CANADAPOSTALCODE' and xtype = 'PK')
ALTER TABLE [dbo].[CanadaPostalCode] WITH NOCHECK ADD 
CONSTRAINT [PK_CANADAPOSTALCODE] PRIMARY KEY CLUSTERED
(
	[RowId]
)

GO
