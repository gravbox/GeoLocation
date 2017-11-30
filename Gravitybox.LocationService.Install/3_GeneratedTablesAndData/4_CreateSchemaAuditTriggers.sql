--DO NOT MODIFY THIS FILE. IT IS ALWAYS OVERWRITTEN ON GENERATION.
--Audit Triggers

--##SECTION BEGIN [AUDIT TRIGGERS]

--DROP ANY AUDIT TRIGGERS FOR [dbo].[State]
if exists(select * from sysobjects where name = '__TR_State__INSERT' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_State__INSERT]
GO
if exists(select * from sysobjects where name = '__TR_State__UPDATE' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_State__UPDATE]
GO
if exists(select * from sysobjects where name = '__TR_State__DELETE' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_State__DELETE]
GO

--DROP ANY AUDIT TRIGGERS FOR [dbo].[Zip]
if exists(select * from sysobjects where name = '__TR_Zip__INSERT' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_Zip__INSERT]
GO
if exists(select * from sysobjects where name = '__TR_Zip__UPDATE' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_Zip__UPDATE]
GO
if exists(select * from sysobjects where name = '__TR_Zip__DELETE' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_Zip__DELETE]
GO

--##SECTION END [AUDIT TRIGGERS]

