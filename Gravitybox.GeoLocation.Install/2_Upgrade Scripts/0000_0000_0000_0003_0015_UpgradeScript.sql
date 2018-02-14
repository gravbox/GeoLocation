--Generated Upgrade For Version 0.0.0.3.15
--Generated on 2018-02-14 13:47:51

--INDEX FOR TABLE [City] COLUMNS:[State]
if not exists(select * from sys.indexes where name = 'IDX_CITY_STATE') and exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'State' and o.name = 'City')
CREATE NONCLUSTERED INDEX [IDX_CITY_STATE] ON [dbo].[City] ([State] ASC)

GO

