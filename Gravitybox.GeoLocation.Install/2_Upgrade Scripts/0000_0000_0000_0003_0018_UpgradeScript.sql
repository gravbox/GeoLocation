--Generated Upgrade For Version 0.0.0.3.18
--Generated on 2018-03-28 16:39:15

--INDEX FOR TABLE [CanadaPostalCode] COLUMNS:[PostalCode]
if not exists(select * from sys.indexes where name = 'IDX_CANADAPOSTALCODE_POSTALCODE') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'PostalCode' and o.name = 'CanadaPostalCode')
CREATE NONCLUSTERED INDEX [IDX_CANADAPOSTALCODE_POSTALCODE] ON [dbo].[CanadaPostalCode] ([PostalCode] ASC)

GO

--INDEX FOR TABLE [CanadaPostalCode] COLUMNS:[City]
if not exists(select * from sys.indexes where name = 'IDX_CANADAPOSTALCODE_CITY') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'City' and o.name = 'CanadaPostalCode')
CREATE NONCLUSTERED INDEX [IDX_CANADAPOSTALCODE_CITY] ON [dbo].[CanadaPostalCode] ([City] ASC)

GO

