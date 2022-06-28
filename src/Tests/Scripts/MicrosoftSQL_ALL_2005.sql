
USE [EasyObjectTest]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetAggregateTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetAggregateTest];
GO

CREATE PROCEDURE [daab_GetAggregateTest]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[DepartmentID],
		[FirstName],
		[LastName],
		[Age],
		[HireDate],
		[Salary],
		[IsActive],
		[ts]
	FROM [AggregateTest]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetAggregateTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetAggregateTest Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetAllAggregateTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetAllAggregateTest];
GO

CREATE PROCEDURE [daab_GetAllAggregateTest]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[DepartmentID],
		[FirstName],
		[LastName],
		[Age],
		[HireDate],
		[Salary],
		[IsActive],
		[ts]
	FROM [AggregateTest]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetAllAggregateTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetAllAggregateTest Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_UpdateAggregateTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_UpdateAggregateTest];
GO

CREATE PROCEDURE [daab_UpdateAggregateTest]
(
	@ID int,
	@DepartmentID int = NULL,
	@FirstName varchar(25) = NULL,
	@LastName varchar(15) = NULL,
	@Age int = NULL,
	@HireDate datetime = NULL,
	@Salary numeric(8,4) = NULL,
	@IsActive bit = NULL,
	@ts timestamp = NULL OUTPUT
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [AggregateTest]
	SET
		[DepartmentID] = @DepartmentID,
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[Age] = @Age,
		[HireDate] = @HireDate,
		[Salary] = @Salary,
		[IsActive] = @IsActive
	WHERE
		[ID] = @ID
	AND [ts] = @ts


	SET @Err = @@Error

    SELECT @ts = [ts]
      FROM [AggregateTest]
     WHERE [ID] = @ID

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_UpdateAggregateTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_UpdateAggregateTest Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_AddAggregateTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_AddAggregateTest];
GO

CREATE PROCEDURE [daab_AddAggregateTest]
(
	@ID int = NULL OUTPUT,
	@DepartmentID int = NULL,
	@FirstName varchar(25) = NULL,
	@LastName varchar(15) = NULL,
	@Age int = NULL,
	@HireDate datetime = NULL,
	@Salary numeric(8,4) = NULL,
	@IsActive bit = NULL,
	@ts timestamp = NULL OUTPUT
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [AggregateTest]
	(
		[DepartmentID],
		[FirstName],
		[LastName],
		[Age],
		[HireDate],
		[Salary],
		[IsActive]
	)
	VALUES
	(
		@DepartmentID,
		@FirstName,
		@LastName,
		@Age,
		@HireDate,
		@Salary,
		@IsActive
	)

	SET @Err = @@Error
	SELECT @ID = SCOPE_IDENTITY()

    SELECT @ts = [ts]
      FROM [AggregateTest]
     WHERE [ID] = @ID

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_AddAggregateTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_AddAggregateTest Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_DeleteAggregateTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_DeleteAggregateTest];
GO

CREATE PROCEDURE [daab_DeleteAggregateTest]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [AggregateTest]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_DeleteAggregateTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_DeleteAggregateTest Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetComputedTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetComputedTest];
GO

CREATE PROCEDURE [daab_GetComputedTest]
(
	@RecordID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[RecordID],
		[Integer1],
		[Integer2],
		[String1],
		[String2],
		[Computed1],
		[Computed2]
	FROM [ComputedTest]
	WHERE
		([RecordID] = @RecordID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetComputedTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetComputedTest Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetAllComputedTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetAllComputedTest];
GO

CREATE PROCEDURE [daab_GetAllComputedTest]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[RecordID],
		[Integer1],
		[Integer2],
		[String1],
		[String2],
		[Computed1],
		[Computed2]
	FROM [ComputedTest]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetAllComputedTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetAllComputedTest Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_UpdateComputedTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_UpdateComputedTest];
GO

CREATE PROCEDURE [daab_UpdateComputedTest]
(
	@RecordID int,
	@Integer1 int = NULL,
	@Integer2 int = NULL,
	@String1 varchar(5) = NULL,
	@String2 varchar(5) = NULL,
	@Computed1 int = NULL OUTPUT,
	@Computed2 varchar(11) = NULL OUTPUT
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ComputedTest]
	SET
		[Integer1] = @Integer1,
		[Integer2] = @Integer2,
		[String1] = @String1,
		[String2] = @String2
	WHERE
		[RecordID] = @RecordID


	SET @Err = @@Error

    SELECT @Computed1 = [Computed1], @Computed2 = [Computed2]
      FROM [ComputedTest]
     WHERE [RecordID] = @RecordID

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_UpdateComputedTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_UpdateComputedTest Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_AddComputedTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_AddComputedTest];
GO

CREATE PROCEDURE [daab_AddComputedTest]
(
	@RecordID int = NULL OUTPUT,
	@Integer1 int = NULL,
	@Integer2 int = NULL,
	@String1 varchar(5) = NULL,
	@String2 varchar(5) = NULL,
	@Computed1 int = NULL OUTPUT,
	@Computed2 varchar(11) = NULL OUTPUT
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [ComputedTest]
	(
		[Integer1],
		[Integer2],
		[String1],
		[String2]
	)
	VALUES
	(
		@Integer1,
		@Integer2,
		@String1,
		@String2
	)

	SET @Err = @@Error
	SELECT @RecordID = SCOPE_IDENTITY()

    SELECT @Computed1 = [Computed1], @Computed2 = [Computed2]
      FROM [ComputedTest]
     WHERE [RecordID] = @RecordID

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_AddComputedTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_AddComputedTest Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_DeleteComputedTest') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_DeleteComputedTest];
GO

CREATE PROCEDURE [daab_DeleteComputedTest]
(
	@RecordID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [ComputedTest]
	WHERE
		[RecordID] = @RecordID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_DeleteComputedTest Succeeded'
ELSE PRINT 'Procedure Creation: daab_DeleteComputedTest Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetCustomers') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetCustomers];
GO

CREATE PROCEDURE [daab_GetCustomers]
(
	@CustomerID nchar(5)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CustomerID],
		[CompanyName],
		[ContactName],
		[ContactTitle],
		[Address],
		[City],
		[Region],
		[PostalCode],
		[Country],
		[Phone],
		[Fax]
	FROM [Customers]
	WHERE
		([CustomerID] = @CustomerID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetCustomers Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetCustomers Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetAllCustomers') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetAllCustomers];
GO

CREATE PROCEDURE [daab_GetAllCustomers]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CustomerID],
		[CompanyName],
		[ContactName],
		[ContactTitle],
		[Address],
		[City],
		[Region],
		[PostalCode],
		[Country],
		[Phone],
		[Fax]
	FROM [Customers]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetAllCustomers Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetAllCustomers Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_UpdateCustomers') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_UpdateCustomers];
GO

CREATE PROCEDURE [daab_UpdateCustomers]
(
	@CustomerID nchar(5),
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30) = NULL,
	@ContactTitle nvarchar(30) = NULL,
	@Address nvarchar(60) = NULL,
	@City nvarchar(15) = NULL,
	@Region nvarchar(15) = NULL,
	@PostalCode nvarchar(10) = NULL,
	@Country nvarchar(15) = NULL,
	@Phone nvarchar(24) = NULL,
	@Fax nvarchar(24) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Customers]
	SET
		[CompanyName] = @CompanyName,
		[ContactName] = @ContactName,
		[ContactTitle] = @ContactTitle,
		[Address] = @Address,
		[City] = @City,
		[Region] = @Region,
		[PostalCode] = @PostalCode,
		[Country] = @Country,
		[Phone] = @Phone,
		[Fax] = @Fax
	WHERE
		[CustomerID] = @CustomerID


	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_UpdateCustomers Succeeded'
ELSE PRINT 'Procedure Creation: daab_UpdateCustomers Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_AddCustomers') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_AddCustomers];
GO

CREATE PROCEDURE [daab_AddCustomers]
(
	@CustomerID nchar(5),
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30) = NULL,
	@ContactTitle nvarchar(30) = NULL,
	@Address nvarchar(60) = NULL,
	@City nvarchar(15) = NULL,
	@Region nvarchar(15) = NULL,
	@PostalCode nvarchar(10) = NULL,
	@Country nvarchar(15) = NULL,
	@Phone nvarchar(24) = NULL,
	@Fax nvarchar(24) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Customers]
	(
		[CustomerID],
		[CompanyName],
		[ContactName],
		[ContactTitle],
		[Address],
		[City],
		[Region],
		[PostalCode],
		[Country],
		[Phone],
		[Fax]
	)
	VALUES
	(
		@CustomerID,
		@CompanyName,
		@ContactName,
		@ContactTitle,
		@Address,
		@City,
		@Region,
		@PostalCode,
		@Country,
		@Phone,
		@Fax
	)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_AddCustomers Succeeded'
ELSE PRINT 'Procedure Creation: daab_AddCustomers Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_DeleteCustomers') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_DeleteCustomers];
GO

CREATE PROCEDURE [daab_DeleteCustomers]
(
	@CustomerID nchar(5)
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Customers]
	WHERE
		[CustomerID] = @CustomerID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_DeleteCustomers Succeeded'
ELSE PRINT 'Procedure Creation: daab_DeleteCustomers Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetEmployeeDepartmentHistory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetEmployeeDepartmentHistory];
GO

CREATE PROCEDURE [daab_GetEmployeeDepartmentHistory]
(
	@EmployeeID int,
	@DepartmentID smallint
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[EmployeeID],
		[DepartmentID],
		[StartDate],
		[EndDate],
		[ModifiedDate]
	FROM [EmployeeDepartmentHistory]
	WHERE
		([EmployeeID] = @EmployeeID) AND
		([DepartmentID] = @DepartmentID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetEmployeeDepartmentHistory Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetEmployeeDepartmentHistory Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetAllEmployeeDepartmentHistory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetAllEmployeeDepartmentHistory];
GO

CREATE PROCEDURE [daab_GetAllEmployeeDepartmentHistory]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[EmployeeID],
		[DepartmentID],
		[StartDate],
		[EndDate],
		[ModifiedDate]
	FROM [EmployeeDepartmentHistory]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetAllEmployeeDepartmentHistory Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetAllEmployeeDepartmentHistory Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_UpdateEmployeeDepartmentHistory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_UpdateEmployeeDepartmentHistory];
GO

CREATE PROCEDURE [daab_UpdateEmployeeDepartmentHistory]
(
	@EmployeeID int,
	@DepartmentID smallint,
	@StartDate datetime,
	@EndDate datetime = NULL,
	@ModifiedDate datetime
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [EmployeeDepartmentHistory]
	SET
		[StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[ModifiedDate] = @ModifiedDate
	WHERE
		[EmployeeID] = @EmployeeID
	AND	[DepartmentID] = @DepartmentID


	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_UpdateEmployeeDepartmentHistory Succeeded'
ELSE PRINT 'Procedure Creation: daab_UpdateEmployeeDepartmentHistory Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_AddEmployeeDepartmentHistory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_AddEmployeeDepartmentHistory];
GO

CREATE PROCEDURE [daab_AddEmployeeDepartmentHistory]
(
	@EmployeeID int,
	@DepartmentID smallint,
	@StartDate datetime,
	@EndDate datetime = NULL,
	@ModifiedDate datetime
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [EmployeeDepartmentHistory]
	(
		[EmployeeID],
		[DepartmentID],
		[StartDate],
		[EndDate],
		[ModifiedDate]
	)
	VALUES
	(
		@EmployeeID,
		@DepartmentID,
		@StartDate,
		@EndDate,
		@ModifiedDate
	)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_AddEmployeeDepartmentHistory Succeeded'
ELSE PRINT 'Procedure Creation: daab_AddEmployeeDepartmentHistory Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_DeleteEmployeeDepartmentHistory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_DeleteEmployeeDepartmentHistory];
GO

CREATE PROCEDURE [daab_DeleteEmployeeDepartmentHistory]
(
	@EmployeeID int,
	@DepartmentID smallint
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [EmployeeDepartmentHistory]
	WHERE
		[EmployeeID] = @EmployeeID AND
		[DepartmentID] = @DepartmentID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_DeleteEmployeeDepartmentHistory Succeeded'
ELSE PRINT 'Procedure Creation: daab_DeleteEmployeeDepartmentHistory Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetEmployees') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetEmployees];
GO

CREATE PROCEDURE [daab_GetEmployees]
(
	@EmployeeID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[EmployeeID],
		[LastName],
		[FirstName],
		[Title],
		[TitleOfCourtesy],
		[BirthDate],
		[HireDate],
		[Address],
		[City],
		[Region],
		[PostalCode],
		[Country],
		[HomePhone],
		[Extension],
		[Photo],
		[Notes],
		[ReportsTo],
		[PhotoPath]
	FROM [Employees]
	WHERE
		([EmployeeID] = @EmployeeID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetEmployees Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetEmployees Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_GetAllEmployees') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_GetAllEmployees];
GO

CREATE PROCEDURE [daab_GetAllEmployees]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[EmployeeID],
		[LastName],
		[FirstName],
		[Title],
		[TitleOfCourtesy],
		[BirthDate],
		[HireDate],
		[Address],
		[City],
		[Region],
		[PostalCode],
		[Country],
		[HomePhone],
		[Extension],
		[Photo],
		[Notes],
		[ReportsTo],
		[PhotoPath]
	FROM [Employees]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_GetAllEmployees Succeeded'
ELSE PRINT 'Procedure Creation: daab_GetAllEmployees Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_UpdateEmployees') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_UpdateEmployees];
GO

CREATE PROCEDURE [daab_UpdateEmployees]
(
	@EmployeeID uniqueidentifier,
	@LastName nvarchar(20),
	@FirstName nvarchar(10),
	@Title nvarchar(30) = NULL,
	@TitleOfCourtesy nvarchar(25) = NULL,
	@BirthDate datetime = NULL,
	@HireDate datetime = NULL,
	@Address nvarchar(60) = NULL,
	@City nvarchar(15) = NULL,
	@Region nvarchar(15) = NULL,
	@PostalCode nvarchar(10) = NULL,
	@Country nvarchar(15) = NULL,
	@HomePhone nvarchar(24) = NULL,
	@Extension nvarchar(4) = NULL,
	@Photo image = NULL,
	@Notes ntext = NULL,
	@ReportsTo int = NULL,
	@PhotoPath nvarchar(255) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Employees]
	SET
		[LastName] = @LastName,
		[FirstName] = @FirstName,
		[Title] = @Title,
		[TitleOfCourtesy] = @TitleOfCourtesy,
		[BirthDate] = @BirthDate,
		[HireDate] = @HireDate,
		[Address] = @Address,
		[City] = @City,
		[Region] = @Region,
		[PostalCode] = @PostalCode,
		[Country] = @Country,
		[HomePhone] = @HomePhone,
		[Extension] = @Extension,
		[Photo] = @Photo,
		[Notes] = @Notes,
		[ReportsTo] = @ReportsTo,
		[PhotoPath] = @PhotoPath
	WHERE
		[EmployeeID] = @EmployeeID


	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_UpdateEmployees Succeeded'
ELSE PRINT 'Procedure Creation: daab_UpdateEmployees Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_AddEmployees') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_AddEmployees];
GO

CREATE PROCEDURE [daab_AddEmployees]
(
	@EmployeeID uniqueidentifier,
	@LastName nvarchar(20),
	@FirstName nvarchar(10),
	@Title nvarchar(30) = NULL,
	@TitleOfCourtesy nvarchar(25) = NULL,
	@BirthDate datetime = NULL,
	@HireDate datetime = NULL,
	@Address nvarchar(60) = NULL,
	@City nvarchar(15) = NULL,
	@Region nvarchar(15) = NULL,
	@PostalCode nvarchar(10) = NULL,
	@Country nvarchar(15) = NULL,
	@HomePhone nvarchar(24) = NULL,
	@Extension nvarchar(4) = NULL,
	@Photo image = NULL,
	@Notes ntext = NULL,
	@ReportsTo int = NULL,
	@PhotoPath nvarchar(255) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int
	IF @EmployeeID IS NULL
		 SET @EmployeeID = NEWID()


	INSERT
	INTO [Employees]
	(
		[EmployeeID],
		[LastName],
		[FirstName],
		[Title],
		[TitleOfCourtesy],
		[BirthDate],
		[HireDate],
		[Address],
		[City],
		[Region],
		[PostalCode],
		[Country],
		[HomePhone],
		[Extension],
		[Photo],
		[Notes],
		[ReportsTo],
		[PhotoPath]
	)
	VALUES
	(
		@EmployeeID,
		@LastName,
		@FirstName,
		@Title,
		@TitleOfCourtesy,
		@BirthDate,
		@HireDate,
		@Address,
		@City,
		@Region,
		@PostalCode,
		@Country,
		@HomePhone,
		@Extension,
		@Photo,
		@Notes,
		@ReportsTo,
		@PhotoPath
	)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_AddEmployees Succeeded'
ELSE PRINT 'Procedure Creation: daab_AddEmployees Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('daab_DeleteEmployees') AND sysstat & 0xf = 4)
    DROP PROCEDURE [daab_DeleteEmployees];
GO

CREATE PROCEDURE [daab_DeleteEmployees]
(
	@EmployeeID uniqueidentifier
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Employees]
	WHERE
		[EmployeeID] = @EmployeeID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: daab_DeleteEmployees Succeeded'
ELSE PRINT 'Procedure Creation: daab_DeleteEmployees Error on Creation'
GO


