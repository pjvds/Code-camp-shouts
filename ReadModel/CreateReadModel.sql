USE Master
GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ReadModel')
DROP DATABASE [ReadModel]
GO

USE master
GO

CREATE DATABASE [ReadModel]
GO

USE ReadModel
GO

CREATE TABLE [dbo].[TotalsPerDayItem](
	[Id] [int] PRIMARY KEY IDENTITY(1,1),
	[Date] [datetime] NOT NULL,
	[NewCount] [int] NOT NULL,
	[EditCount] [int] NOT NULL)
GO
CREATE TABLE [dbo].[NoteItem](
	[Id] [uniqueidentifier] PRIMARY KEY,
	[Text] [varchar](250) NULL,
	[CreationDate] [datetime] NULL)
GO