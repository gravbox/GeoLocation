--DO NOT MODIFY THIS FILE. IT IS ALWAYS OVERWRITTEN ON GENERATION.
--Audit Triggers

--##SECTION BEGIN [AUDIT TRIGGERS]

--DROP ANY AUDIT TRIGGERS FOR [dbo].[CanadaPostalCode]
if exists(select * from sysobjects where name = '__TR_CanadaPostalCode__INSERT' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_CanadaPostalCode__INSERT]
GO
if exists(select * from sysobjects where name = '__TR_CanadaPostalCode__UPDATE' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_CanadaPostalCode__UPDATE]
GO
if exists(select * from sysobjects where name = '__TR_CanadaPostalCode__DELETE' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_CanadaPostalCode__DELETE]
GO

--DROP ANY AUDIT TRIGGERS FOR [dbo].[City]
if exists(select * from sysobjects where name = '__TR_City__INSERT' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_City__INSERT]
GO
if exists(select * from sysobjects where name = '__TR_City__UPDATE' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_City__UPDATE]
GO
if exists(select * from sysobjects where name = '__TR_City__DELETE' AND xtype = 'TR')
DROP TRIGGER [dbo].[__TR_City__DELETE]
GO

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

