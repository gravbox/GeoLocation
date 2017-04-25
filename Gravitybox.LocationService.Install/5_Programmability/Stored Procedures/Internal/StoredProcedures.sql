--DO NOT MODIFY THIS FILE. IT IS ALWAYS OVERWRITTEN ON GENERATION.

--##SECTION BEGIN [INTERNAL STORED PROCS]

--This SQL is generated for internal stored procedures for table [State]
if exists(select * from sys.objects where name = 'gen_State_Delete' and type = 'P' and type_desc = 'SQL_STORED_PROCEDURE')
	drop procedure [dbo].[gen_State_Delete]
GO

if exists(select * from sys.objects where name = 'gen_State_Insert' and type = 'P' and type_desc = 'SQL_STORED_PROCEDURE')
	drop procedure [dbo].[gen_State_Insert]
GO

if exists(select * from sys.objects where name = 'gen_State_Update' and type = 'P' and type_desc = 'SQL_STORED_PROCEDURE')
	drop procedure [dbo].[gen_State_Update]
GO

--This SQL is generated for internal stored procedures for table [Zip]
if exists(select * from sys.objects where name = 'gen_Zip_Delete' and type = 'P' and type_desc = 'SQL_STORED_PROCEDURE')
	drop procedure [dbo].[gen_Zip_Delete]
GO

if exists(select * from sys.objects where name = 'gen_Zip_Insert' and type = 'P' and type_desc = 'SQL_STORED_PROCEDURE')
	drop procedure [dbo].[gen_Zip_Insert]
GO

if exists(select * from sys.objects where name = 'gen_Zip_Update' and type = 'P' and type_desc = 'SQL_STORED_PROCEDURE')
	drop procedure [dbo].[gen_Zip_Update]
GO

--##SECTION END [INTERNAL STORED PROCS]

