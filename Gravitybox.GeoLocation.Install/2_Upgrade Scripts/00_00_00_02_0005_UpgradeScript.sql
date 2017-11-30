--Generated Upgrade For Version 0.0.0.2.5
--Generated on 2013-12-27 11:30:11

--ADD COLUMN [Zip].[Population]
if exists(select * from sys.objects where name = 'Zip' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Population' and o.name = 'Zip')
ALTER TABLE [dbo].[Zip] ADD [Population] [Int] NULL 

GO

--INDEX FOR TABLE [Zip] COLUMNS:[Population]
if not exists(select * from sys.indexes where name = 'IDX_ZIP_POPULATION')
CREATE NONCLUSTERED INDEX [IDX_ZIP_POPULATION] ON [dbo].[Zip] ([Population] ASC)

GO

