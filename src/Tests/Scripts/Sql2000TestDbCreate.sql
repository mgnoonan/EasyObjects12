IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'EasyObjectTest')
	DROP DATABASE [EasyObjectTest]
GO

CREATE DATABASE [EasyObjectTest]  ON (NAME = N'EasyObjectTest_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\EasyObjectTest_Data.MDF' , SIZE = 2, FILEGROWTH = 10%) LOG ON (NAME = N'EasyObjectTest_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\EasyObjectTest_Log.LDF' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'EasyObjectTest', N'autoclose', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'bulkcopy', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'trunc. log', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'torn page detection', N'true'
GO

exec sp_dboption N'EasyObjectTest', N'read only', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'dbo use', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'single', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'autoshrink', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'ANSI null default', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'recursive triggers', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'ANSI nulls', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'concat null yields null', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'cursor close on commit', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'default to local cursor', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'quoted identifier', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'ANSI warnings', N'false'
GO

exec sp_dboption N'EasyObjectTest', N'auto create statistics', N'true'
GO

exec sp_dboption N'EasyObjectTest', N'auto update statistics', N'true'
GO

use [EasyObjectTest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FullNameView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[FullNameView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AggregateTest]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AggregateTest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ComputedTest]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ComputedTest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Customers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Customers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeDepartmentHistory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EmployeeDepartmentHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Employees]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Employees]
GO

CREATE TABLE [dbo].[AggregateTest] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DepartmentID] [int] NULL ,
	[FirstName] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LastName] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Age] [int] NULL ,
	[HireDate] [datetime] NULL ,
	[Salary] [numeric](8, 4) NULL ,
	[IsActive] [bit] NULL ,
	[ts] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ComputedTest] (
	[RecordID] [int] IDENTITY (1, 1) NOT NULL ,
	[Integer1] [int] NULL ,
	[Integer2] [int] NULL ,
	[String1] [varchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[String2] [varchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Computed1] AS ([Integer1] + [Integer2]) ,
	[Computed2] AS ([String1] + ' ' + [String2]) 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Customers] (
	[CustomerID] [nchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CompanyName] [nvarchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ContactName] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ContactTitle] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Address] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[City] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Region] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PostalCode] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Country] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Phone] [nvarchar] (24) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Fax] [nvarchar] (24) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EmployeeDepartmentHistory] (
	[EmployeeID] [int] NOT NULL ,
	[DepartmentID] [smallint] NOT NULL ,
	[StartDate] [datetime] NOT NULL ,
	[EndDate] [datetime] NULL ,
	[ModifiedDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Employees] (
	[EmployeeID] [uniqueidentifier] NOT NULL ,
	[LastName] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[FirstName] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Title] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TitleOfCourtesy] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[BirthDate] [datetime] NULL ,
	[HireDate] [datetime] NULL ,
	[Address] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[City] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Region] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PostalCode] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Country] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HomePhone] [nvarchar] (24) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Extension] [nvarchar] (4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Photo] [image] NULL ,
	[Notes] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ReportsTo] [int] NULL ,
	[PhotoPath] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AggregateTest] WITH NOCHECK ADD 
	CONSTRAINT [PK_AggregateTest] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ComputedTest] WITH NOCHECK ADD 
	CONSTRAINT [PK_ComputedTest] PRIMARY KEY  CLUSTERED 
	(
		[RecordID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Customers] WITH NOCHECK ADD 
	CONSTRAINT [PK_Customers] PRIMARY KEY  CLUSTERED 
	(
		[CustomerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[EmployeeDepartmentHistory] WITH NOCHECK ADD 
	CONSTRAINT [DF_EmployeeDepartmentHistory_ModifiedDate] DEFAULT (getdate()) FOR [ModifiedDate],
	CONSTRAINT [PK_EmployeeDepartmentHistory_EmployeeID_DepartmentID] PRIMARY KEY  CLUSTERED 
	(
		[EmployeeID],
		[DepartmentID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Employees] WITH NOCHECK ADD 
	CONSTRAINT [DF_Employees_EmployeeID] DEFAULT (newid()) FOR [EmployeeID],
	CONSTRAINT [PK_Employees] PRIMARY KEY  CLUSTERED 
	(
		[EmployeeID]
	)  ON [PRIMARY] 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE VIEW [dbo].[FullNameView] AS 
SELECT (AggregateTest.LastName + ', ' + AggregateTest.FirstName) AS 'FullName',
        AggregateTest.DepartmentID,
        AggregateTest.HireDate,
        AggregateTest.Salary,
        AggregateTest.IsActive
FROM AggregateTest
WHERE (((AggregateTest.IsActive)=1))

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

