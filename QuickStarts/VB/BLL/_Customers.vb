'===============================================================================
'  Generated From - VbNet_EasyObject_BusinessEntity.vbgen
' 
'  ** IMPORTANT  ** 
'  
'  This object is 'MustInherit' which means you need to inherit from it to be able
'  to instantiate it.  This is very easily done. You can override properties and
'  methods in your derived class, this allows you to regenerate this class at any
'  time and not worry about overwriting custom code. 
'
'  NEVER EDIT THIS FILE.
'
'  Public Class YourObject 
'      Inherits _YourObject
'
'  End Class
'
'===============================================================================

' EasyObjects.NET version 1.1
' Generated by MyGeneration Version # (1.1.6.0)

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Xml
Imports System.IO

Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports NCI.EasyObjects


#Region " Schema "

Public Class CustomersSchema
	Inherits NCI.EasyObjects.Schema

    Private Shared _entries As ArrayList
	Public Shared CustomerID As New SchemaItem("CustomerID", DbType.StringFixedLength, SchemaItemJustify.None, 5, False, True, True, False)
	Public Shared CompanyName As New SchemaItem("CompanyName", DbType.String, SchemaItemJustify.None, 40, False, False, False, False)
	Public Shared ContactName As New SchemaItem("ContactName", DbType.String, SchemaItemJustify.None, 30, True, False, False, False)
	Public Shared ContactTitle As New SchemaItem("ContactTitle", DbType.String, SchemaItemJustify.None, 30, True, False, False, False)
	Public Shared Address As New SchemaItem("Address", DbType.String, SchemaItemJustify.None, 60, True, False, False, False)
	Public Shared City As New SchemaItem("City", DbType.String, SchemaItemJustify.None, 15, True, False, False, False)
	Public Shared Region As New SchemaItem("Region", DbType.String, SchemaItemJustify.None, 15, True, False, False, False)
	Public Shared PostalCode As New SchemaItem("PostalCode", DbType.String, SchemaItemJustify.None, 10, True, False, False, False)
	Public Shared Country As New SchemaItem("Country", DbType.String, SchemaItemJustify.None, 15, True, False, False, False)
	Public Shared Phone As New SchemaItem("Phone", DbType.String, SchemaItemJustify.None, 24, True, False, False, False)
	Public Shared Fax As New SchemaItem("Fax", DbType.String, SchemaItemJustify.None, 24, True, False, False, False)

    Public Overrides ReadOnly Property SchemaEntries() As ArrayList
        Get
            If _entries Is Nothing Then
                _entries = New ArrayList()
				_entries.Add(CustomersSchema.CustomerID)
				_entries.Add(CustomersSchema.CompanyName)
				_entries.Add(CustomersSchema.ContactName)
				_entries.Add(CustomersSchema.ContactTitle)
				_entries.Add(CustomersSchema.Address)
				_entries.Add(CustomersSchema.City)
				_entries.Add(CustomersSchema.Region)
				_entries.Add(CustomersSchema.PostalCode)
				_entries.Add(CustomersSchema.Country)
				_entries.Add(CustomersSchema.Phone)
				_entries.Add(CustomersSchema.Fax)

            End If
            Return _entries
        End Get
    End Property

End Class

#End Region

Public MustInherit Class _Customers
    Inherits NCI.EasyObjects.EasyObject

    Sub New()
        Dim _schema As New CustomersSchema()
        Me.SchemaEntries = _schema.SchemaEntries
		Me.SchemaGlobal = "dbo"
    End Sub

	Public Overrides Sub FlushData()
		Me._whereClause = Nothing
		Me._aggregateClause = Nothing
		MyBase.FlushData()
	End Sub
		
	''' <summary>
	''' Loads the business object with info from the database, based on the requested primary key.
	''' </summary>
	''' <param name="CustomerID"></param>
	''' <returns>A Boolean indicating success or failure of the query</returns>
	Public Function LoadByPrimaryKey(ByVal CustomerID As String) As Boolean
		
		Select Case Me.DefaultCommandType
			Case CommandType.StoredProcedure
				Dim parameters As ListDictionary = New ListDictionary

				' Add in parameters
				parameters.Add(CustomersSchema.CustomerID.FieldName, CustomerID)

				Return MyBase.LoadFromSql(Me.SchemaStoredProcedureWithSeparator & "daab_GetCustomers", parameters, CommandType.StoredProcedure)
				
			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Me.Where.CustomerID.Value = CustomerID
				Return Me.Query.Load()

			Case Else
				Throw New ArgumentException("Invalid CommandType", "commandType")
				
		End Select
		
	End Function

    ''' <summary>
    ''' Loads all records from the table.
    ''' </summary>
    ''' <returns>A Boolean indicating success or failure of the query</returns>
    Public Function LoadAll() As Boolean
	
		Select Case Me.DefaultCommandType
		
			Case CommandType.StoredProcedure
				Dim parameters As ListDictionary = Nothing
				Return MyBase.LoadFromSql(Me.SchemaStoredProcedureWithSeparator & "daab_GetAllCustomers", parameters, CommandType.StoredProcedure)
				
			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Return Me.Query.Load()
			
			Case Else
				Throw New ArgumentException("Invalid CommandType", "commandType")
				
		End Select

    End Function

    ''' <summary>
    ''' Adds a new record to the internal table.
    ''' </summary>
	Public Overrides Sub AddNew()
		MyBase.AddNew()

	End Sub

    Protected Overloads Overrides Function GetInsertCommand(commandType As CommandType) As DBCommandWrapper
	
		Dim dbCommandWrapper As DBCommandWrapper
		
        ' Create the Database object, using the default database service. The
        ' default database service is determined through configuration.
        Dim db As Database = GetDatabase()
	
		Select Case commandType
		
			Case CommandType.StoredProcedure
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_AddCustomers"
				dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)
		
				CreateParameters(dbCommandWrapper)

			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				For Each item As SchemaItem In Me.SchemaEntries
					If Not item.IsComputed Then
						If (item.IsAutoKey And Me.IdentityInsert) Or Not item.IsAutoKey Then
							Me.Query.AddInsertColumn(item)
						End If
					End If
				Next
				dbCommandWrapper = Me.Query.GetInsertCommandWrapper()

				dbCommandWrapper.Command.Parameters.Clear()
				If Me.IdentityInsert Then
				Else
				End If

				CreateParameters(dbCommandWrapper)
				
			Case Else
				Throw New ArgumentException("Invalid CommandType", "commandType")
				
		End Select

        Return dbCommandWrapper

    End Function

    Protected Overloads Overrides Function GetUpdateCommand(commandType As CommandType) As DBCommandWrapper
	
		Dim dbCommandWrapper As DBCommandWrapper

        ' Create the Database object, using the default database service. The
        ' default database service is determined through configuration.
        Dim db As Database = GetDatabase()
	
		Select Case commandType
		
			Case CommandType.StoredProcedure
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_UpdateCustomers"
				dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)
				
				CreateParameters(dbCommandWrapper)

			Case CommandType.Text
                Me.Query.ClearAll()
				For Each item As SchemaItem In Me.SchemaEntries
					If Not (item.IsAutoKey OrElse item.IsComputed)
						Me.Query.AddUpdateColumn(item)
					End If
				Next

				Me.Where.WhereClauseReset()
				Me.Where.CustomerID.Operator = WhereParameter.Operand.Equal
				dbCommandWrapper = Me.Query.GetUpdateCommandWrapper()

				dbCommandWrapper.Command.Parameters.Clear()
				CreateParameters(dbCommandWrapper)

			Case Else
				Throw New ArgumentException("Invalid CommandType", "commandType")
				
		End Select

        Return dbCommandWrapper

    End Function

    Protected Overloads Overrides Function GetDeleteCommand(commandType As CommandType) As DBCommandWrapper
	
		Dim dbCommandWrapper As DBCommandWrapper

        ' Create the Database object, using the default database service. The
        ' default database service is determined through configuration.
        Dim db As Database = GetDatabase()
	
		Select Case commandType
		
			Case CommandType.StoredProcedure
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_DeleteCustomers"
				dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)
		
				' Add primary key parameters
				dbCommandWrapper.AddInParameter("CustomerID", DbType.StringFixedLength, "CustomerID", DataRowVersion.Current)

			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Me.Where.CustomerID.Operator = WhereParameter.Operand.Equal
				dbCommandWrapper = Me.Query.GetDeleteCommandWrapper()

				dbCommandWrapper.Command.Parameters.Clear()
				dbCommandWrapper.AddInParameter("CustomerID", DbType.StringFixedLength, "CustomerID", DataRowVersion.Current)

			Case Else
				Throw New ArgumentException("Invalid CommandType", "commandType")
				
		End Select

        Return dbCommandWrapper

    End Function

    Private Sub CreateParameters(ByVal dbCommandWrapper As DBCommandWrapper)
		
		dbCommandWrapper.AddInParameter("CustomerID", DbType.StringFixedLength, "CustomerID", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("CompanyName", DbType.String, "CompanyName", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("ContactName", DbType.String, "ContactName", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("ContactTitle", DbType.String, "ContactTitle", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("Address", DbType.String, "Address", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("City", DbType.String, "City", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("Region", DbType.String, "Region", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("PostalCode", DbType.String, "PostalCode", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("Country", DbType.String, "Country", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("Phone", DbType.String, "Phone", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("Fax", DbType.String, "Fax", DataRowVersion.Current)

    End Sub

#Region " Properties "

	Public Overridable Property CustomerID() As String
        Get
			Return Me.GetString(CustomersSchema.CustomerID.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.CustomerID.FieldName, Value)
      End Set
    End Property

	Public Overridable Property CompanyName() As String
        Get
			Return Me.GetString(CustomersSchema.CompanyName.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.CompanyName.FieldName, Value)
      End Set
    End Property

	Public Overridable Property ContactName() As String
        Get
			Return Me.GetString(CustomersSchema.ContactName.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.ContactName.FieldName, Value)
      End Set
    End Property

	Public Overridable Property ContactTitle() As String
        Get
			Return Me.GetString(CustomersSchema.ContactTitle.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.ContactTitle.FieldName, Value)
      End Set
    End Property

	Public Overridable Property Address() As String
        Get
			Return Me.GetString(CustomersSchema.Address.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.Address.FieldName, Value)
      End Set
    End Property

	Public Overridable Property City() As String
        Get
			Return Me.GetString(CustomersSchema.City.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.City.FieldName, Value)
      End Set
    End Property

	Public Overridable Property Region() As String
        Get
			Return Me.GetString(CustomersSchema.Region.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.Region.FieldName, Value)
      End Set
    End Property

	Public Overridable Property PostalCode() As String
        Get
			Return Me.GetString(CustomersSchema.PostalCode.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.PostalCode.FieldName, Value)
      End Set
    End Property

	Public Overridable Property Country() As String
        Get
			Return Me.GetString(CustomersSchema.Country.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.Country.FieldName, Value)
      End Set
    End Property

	Public Overridable Property Phone() As String
        Get
			Return Me.GetString(CustomersSchema.Phone.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.Phone.FieldName, Value)
      End Set
    End Property

	Public Overridable Property Fax() As String
        Get
			Return Me.GetString(CustomersSchema.Fax.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.Fax.FieldName, Value)
      End Set
    End Property

    Public Overrides ReadOnly Property TableName() As String
        Get
            Return "Customers"
        End Get
    End Property

#End Region

#Region " String Properties "
		Public Overridable Property s_CustomerID As String
			Get
				If Me.IsColumnNull(CustomersSchema.CustomerID.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.CustomerID.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.CustomerID.FieldName)
				Else
					Me.CustomerID = MyBase.SetStringAsString(CustomersSchema.CustomerID.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_CompanyName As String
			Get
				If Me.IsColumnNull(CustomersSchema.CompanyName.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.CompanyName.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.CompanyName.FieldName)
				Else
					Me.CompanyName = MyBase.SetStringAsString(CustomersSchema.CompanyName.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_ContactName As String
			Get
				If Me.IsColumnNull(CustomersSchema.ContactName.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.ContactName.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.ContactName.FieldName)
				Else
					Me.ContactName = MyBase.SetStringAsString(CustomersSchema.ContactName.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_ContactTitle As String
			Get
				If Me.IsColumnNull(CustomersSchema.ContactTitle.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.ContactTitle.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.ContactTitle.FieldName)
				Else
					Me.ContactTitle = MyBase.SetStringAsString(CustomersSchema.ContactTitle.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_Address As String
			Get
				If Me.IsColumnNull(CustomersSchema.Address.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.Address.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.Address.FieldName)
				Else
					Me.Address = MyBase.SetStringAsString(CustomersSchema.Address.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_City As String
			Get
				If Me.IsColumnNull(CustomersSchema.City.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.City.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.City.FieldName)
				Else
					Me.City = MyBase.SetStringAsString(CustomersSchema.City.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_Region As String
			Get
				If Me.IsColumnNull(CustomersSchema.Region.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.Region.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.Region.FieldName)
				Else
					Me.Region = MyBase.SetStringAsString(CustomersSchema.Region.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_PostalCode As String
			Get
				If Me.IsColumnNull(CustomersSchema.PostalCode.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.PostalCode.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.PostalCode.FieldName)
				Else
					Me.PostalCode = MyBase.SetStringAsString(CustomersSchema.PostalCode.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_Country As String
			Get
				If Me.IsColumnNull(CustomersSchema.Country.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.Country.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.Country.FieldName)
				Else
					Me.Country = MyBase.SetStringAsString(CustomersSchema.Country.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_Phone As String
			Get
				If Me.IsColumnNull(CustomersSchema.Phone.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.Phone.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.Phone.FieldName)
				Else
					Me.Phone = MyBase.SetStringAsString(CustomersSchema.Phone.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_Fax As String
			Get
				If Me.IsColumnNull(CustomersSchema.Fax.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.Fax.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.Fax.FieldName)
				Else
					Me.Fax = MyBase.SetStringAsString(CustomersSchema.Fax.FieldName, Value)
				End If
			End Set
		End Property


#End Region

#Region " Where Clause "
    Public Class WhereClause

        Public Sub New(ByVal entity As EasyObject)
            Me._entity = entity
        End Sub
		
		Public ReadOnly Property TearOff As TearOffWhereParameter
			Get
				If _tearOff Is Nothing Then
					_tearOff = new TearOffWhereParameter(Me)
				End If

				Return _tearOff
			End Get
		End Property

		#Region " TearOff's "
		Public class TearOffWhereParameter
		
			Private _clause as WhereClause
			
			Public Sub New(ByVal clause As WhereClause)
				Me._clause = clause
			End Sub

			Public ReadOnly Property CustomerID() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.CustomerID)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property CompanyName() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.CompanyName)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property ContactName() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.ContactName)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property ContactTitle() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.ContactTitle)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property Address() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.Address)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property City() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.City)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property Region() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.Region)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property PostalCode() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.PostalCode)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property Country() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.Country)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property Phone() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.Phone)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property Fax() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.Fax)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

	End Class
	
	#End Region	

		Public ReadOnly Property CustomerID() As WhereParameter 
			Get
				If _CustomerID_W Is Nothing Then
					_CustomerID_W = TearOff.CustomerID
				End If
				Return _CustomerID_W
			End Get
		End Property

		Public ReadOnly Property CompanyName() As WhereParameter 
			Get
				If _CompanyName_W Is Nothing Then
					_CompanyName_W = TearOff.CompanyName
				End If
				Return _CompanyName_W
			End Get
		End Property

		Public ReadOnly Property ContactName() As WhereParameter 
			Get
				If _ContactName_W Is Nothing Then
					_ContactName_W = TearOff.ContactName
				End If
				Return _ContactName_W
			End Get
		End Property

		Public ReadOnly Property ContactTitle() As WhereParameter 
			Get
				If _ContactTitle_W Is Nothing Then
					_ContactTitle_W = TearOff.ContactTitle
				End If
				Return _ContactTitle_W
			End Get
		End Property

		Public ReadOnly Property Address() As WhereParameter 
			Get
				If _Address_W Is Nothing Then
					_Address_W = TearOff.Address
				End If
				Return _Address_W
			End Get
		End Property

		Public ReadOnly Property City() As WhereParameter 
			Get
				If _City_W Is Nothing Then
					_City_W = TearOff.City
				End If
				Return _City_W
			End Get
		End Property

		Public ReadOnly Property Region() As WhereParameter 
			Get
				If _Region_W Is Nothing Then
					_Region_W = TearOff.Region
				End If
				Return _Region_W
			End Get
		End Property

		Public ReadOnly Property PostalCode() As WhereParameter 
			Get
				If _PostalCode_W Is Nothing Then
					_PostalCode_W = TearOff.PostalCode
				End If
				Return _PostalCode_W
			End Get
		End Property

		Public ReadOnly Property Country() As WhereParameter 
			Get
				If _Country_W Is Nothing Then
					_Country_W = TearOff.Country
				End If
				Return _Country_W
			End Get
		End Property

		Public ReadOnly Property Phone() As WhereParameter 
			Get
				If _Phone_W Is Nothing Then
					_Phone_W = TearOff.Phone
				End If
				Return _Phone_W
			End Get
		End Property

		Public ReadOnly Property Fax() As WhereParameter 
			Get
				If _Fax_W Is Nothing Then
					_Fax_W = TearOff.Fax
				End If
				Return _Fax_W
			End Get
		End Property

		Private _CustomerID_W As WhereParameter = Nothing
		Private _CompanyName_W As WhereParameter = Nothing
		Private _ContactName_W As WhereParameter = Nothing
		Private _ContactTitle_W As WhereParameter = Nothing
		Private _Address_W As WhereParameter = Nothing
		Private _City_W As WhereParameter = Nothing
		Private _Region_W As WhereParameter = Nothing
		Private _PostalCode_W As WhereParameter = Nothing
		Private _Country_W As WhereParameter = Nothing
		Private _Phone_W As WhereParameter = Nothing
		Private _Fax_W As WhereParameter = Nothing

		Public Sub WhereClauseReset()

		_CustomerID_W = Nothing
		_CompanyName_W = Nothing
		_ContactName_W = Nothing
		_ContactTitle_W = Nothing
		_Address_W = Nothing
		_City_W = Nothing
		_Region_W = Nothing
		_PostalCode_W = Nothing
		_Country_W = Nothing
		_Phone_W = Nothing
		_Fax_W = Nothing
			Me._entity.Query.FlushWhereParameters()

		End Sub
	
		Private _entity As EasyObject
		Private _tearOff As TearOffWhereParameter
    End Class	

	Public ReadOnly Property Where() As WhereClause
		Get
			If _whereClause Is Nothing Then
				_whereClause = New WhereClause(Me)
			End If
	
			Return _whereClause
		End Get
	End Property
	
	Private _whereClause As WhereClause = Nothing	
#End Region	

#Region " Aggregate Clause "
    Public Class AggregateClause

        Public Sub New(ByVal entity As EasyObject)
            Me._entity = entity
        End Sub
		
		Public ReadOnly Property TearOff As TearOffAggregateParameter
			Get
				If _tearOff Is Nothing Then
					_tearOff = new TearOffAggregateParameter(Me)
				End If

				Return _tearOff
			End Get
		End Property

		#Region " TearOff's "
		Public class TearOffAggregateParameter
		
			Private _clause as AggregateClause
			
			Public Sub New(ByVal clause As AggregateClause)
				Me._clause = clause
			End Sub

			Public ReadOnly Property CustomerID() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.CustomerID)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property CompanyName() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.CompanyName)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property ContactName() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.ContactName)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property ContactTitle() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.ContactTitle)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property Address() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.Address)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property City() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.City)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property Region() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.Region)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property PostalCode() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.PostalCode)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property Country() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.Country)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property Phone() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.Phone)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property Fax() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.Fax)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

	End Class
	
	#End Region	

		Public ReadOnly Property CustomerID() As AggregateParameter 
			Get
				If _CustomerID_W Is Nothing Then
					_CustomerID_W = TearOff.CustomerID
				End If
				Return _CustomerID_W
			End Get
		End Property

		Public ReadOnly Property CompanyName() As AggregateParameter 
			Get
				If _CompanyName_W Is Nothing Then
					_CompanyName_W = TearOff.CompanyName
				End If
				Return _CompanyName_W
			End Get
		End Property

		Public ReadOnly Property ContactName() As AggregateParameter 
			Get
				If _ContactName_W Is Nothing Then
					_ContactName_W = TearOff.ContactName
				End If
				Return _ContactName_W
			End Get
		End Property

		Public ReadOnly Property ContactTitle() As AggregateParameter 
			Get
				If _ContactTitle_W Is Nothing Then
					_ContactTitle_W = TearOff.ContactTitle
				End If
				Return _ContactTitle_W
			End Get
		End Property

		Public ReadOnly Property Address() As AggregateParameter 
			Get
				If _Address_W Is Nothing Then
					_Address_W = TearOff.Address
				End If
				Return _Address_W
			End Get
		End Property

		Public ReadOnly Property City() As AggregateParameter 
			Get
				If _City_W Is Nothing Then
					_City_W = TearOff.City
				End If
				Return _City_W
			End Get
		End Property

		Public ReadOnly Property Region() As AggregateParameter 
			Get
				If _Region_W Is Nothing Then
					_Region_W = TearOff.Region
				End If
				Return _Region_W
			End Get
		End Property

		Public ReadOnly Property PostalCode() As AggregateParameter 
			Get
				If _PostalCode_W Is Nothing Then
					_PostalCode_W = TearOff.PostalCode
				End If
				Return _PostalCode_W
			End Get
		End Property

		Public ReadOnly Property Country() As AggregateParameter 
			Get
				If _Country_W Is Nothing Then
					_Country_W = TearOff.Country
				End If
				Return _Country_W
			End Get
		End Property

		Public ReadOnly Property Phone() As AggregateParameter 
			Get
				If _Phone_W Is Nothing Then
					_Phone_W = TearOff.Phone
				End If
				Return _Phone_W
			End Get
		End Property

		Public ReadOnly Property Fax() As AggregateParameter 
			Get
				If _Fax_W Is Nothing Then
					_Fax_W = TearOff.Fax
				End If
				Return _Fax_W
			End Get
		End Property

		Private _CustomerID_W As AggregateParameter = Nothing
		Private _CompanyName_W As AggregateParameter = Nothing
		Private _ContactName_W As AggregateParameter = Nothing
		Private _ContactTitle_W As AggregateParameter = Nothing
		Private _Address_W As AggregateParameter = Nothing
		Private _City_W As AggregateParameter = Nothing
		Private _Region_W As AggregateParameter = Nothing
		Private _PostalCode_W As AggregateParameter = Nothing
		Private _Country_W As AggregateParameter = Nothing
		Private _Phone_W As AggregateParameter = Nothing
		Private _Fax_W As AggregateParameter = Nothing

		Public Sub AggregateClauseReset()

		_CustomerID_W = Nothing
		_CompanyName_W = Nothing
		_ContactName_W = Nothing
		_ContactTitle_W = Nothing
		_Address_W = Nothing
		_City_W = Nothing
		_Region_W = Nothing
		_PostalCode_W = Nothing
		_Country_W = Nothing
		_Phone_W = Nothing
		_Fax_W = Nothing
			Me._entity.Query.FlushAggregateParameters()

		End Sub
	
		Private _entity As EasyObject
		Private _tearOff As TearOffAggregateParameter
    End Class	

	Public ReadOnly Property Aggregate() As AggregateClause
		Get
			If _aggregateClause Is Nothing Then
				_aggregateClause = New AggregateClause(Me)
			End If
	
			Return _aggregateClause
		End Get
	End Property
	
	Private _aggregateClause As AggregateClause = Nothing	
#End Region	

End Class


