--Generated Upgrade For Version 0.0.0.3.20
--Generated on 2018-03-28 16:44:22

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

