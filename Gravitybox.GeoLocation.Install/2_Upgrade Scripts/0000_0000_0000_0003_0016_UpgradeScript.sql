--Generated Upgrade For Version 0.0.0.3.16
--Generated on 2018-02-14 14:29:45

--INDEX FOR TABLE [City] COLUMNS:[Name]
if not exists(select * from sys.indexes where name = 'IDX_CITY_NAME') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Name' and o.name = 'City')
CREATE NONCLUSTERED INDEX [IDX_CITY_NAME] ON [dbo].[City] ([Name] ASC)

GO

