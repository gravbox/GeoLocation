--Generated Upgrade For Version 0.0.0.3.14
--Generated on 2018-02-14 13:41:42

--ADD COLUMN [City].[Population]
if exists(select * from sys.objects where name = 'City' and type = 'U') AND not exists (select * from syscolumns c inner join sysobjects o on c.id = o.id where c.name = 'Population' and o.name = 'City')
ALTER TABLE [dbo].[City] ADD [Population] [Int] NULL 

GO
