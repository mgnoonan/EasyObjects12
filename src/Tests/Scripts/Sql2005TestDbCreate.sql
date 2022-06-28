/****** Object:  Table [dbo].[AggregateTest]    Script Date: 10/19/2006 16:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AggregateTest]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AggregateTest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] NULL,
	[FirstName] [varchar](25) NULL,
	[LastName] [varchar](15) NULL,
	[Age] [int] NULL,
	[HireDate] [datetime] NULL,
	[Salary] [numeric](8, 4) NULL,
	[IsActive] [bit] NULL,
	[ts] [timestamp] NULL,
 CONSTRAINT [PK_AggregateTest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ComputedTest]    Script Date: 10/19/2006 16:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComputedTest]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ComputedTest](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[Integer1] [int] NULL,
	[Integer2] [int] NULL,
	[String1] [varchar](5) NULL,
	[String2] [varchar](5) NULL,
	[Computed1]  AS ([Integer1]+[Integer2]),
	[Computed2]  AS (([String1]+' ')+[String2]),
 CONSTRAINT [PK_ComputedTest] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/19/2006 16:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[CustomerID] [nchar](5) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[EmployeeDepartmentHistory]    Script Date: 10/19/2006 16:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeDepartmentHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EmployeeDepartmentHistory](
	[EmployeeID] [int] NOT NULL,
	[DepartmentID] [smallint] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_EmployeeDepartmentHistory_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_EmployeeDepartmentHistory_EmployeeID_DepartmentID] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[DepartmentID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/19/2006 16:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Employees_EmployeeID]  DEFAULT (newid()),
	[LastName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[Title] [nvarchar](30) NULL,
	[TitleOfCourtesy] [nvarchar](25) NULL,
	[BirthDate] [datetime] NULL,
	[HireDate] [datetime] NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[HomePhone] [nvarchar](24) NULL,
	[Extension] [nvarchar](4) NULL,
	[Photo] [image] NULL,
	[Notes] [ntext] NULL,
	[ReportsTo] [int] NULL,
	[PhotoPath] [nvarchar](255) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[FullNameView]    Script Date: 10/19/2006 16:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[FullNameView]'))
EXEC dbo.sp_executesql @statement = N'

CREATE VIEW [dbo].[FullNameView] AS 
SELECT (AggregateTest.LastName + '', '' + AggregateTest.FirstName) AS ''FullName'',
        AggregateTest.DepartmentID,
        AggregateTest.HireDate,
        AggregateTest.Salary,
        AggregateTest.IsActive
FROM AggregateTest
WHERE (((AggregateTest.IsActive)=1))

' 
