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
' Generated by MyGeneration Version # (1.1.7.7)

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Xml
Imports System.IO

Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports NCI.EasyObjects


NameSpace EasyObjects.Tests.Oracle

#Region " Schema "

Public Class CustomersSchema
	Inherits NCI.EasyObjects.Schema

    Private Shared _entries As ArrayList
	Public Shared CUSTOMERID As New SchemaItem("CUSTOMERID", DbType.AnsiStringFixedLength, SchemaItemJustify.None, 5, False, True, False, False)
	Public Shared COMPANYNAME As New SchemaItem("COMPANYNAME", DbType.AnsiString, SchemaItemJustify.None, 40, True, False, False, False)
	Public Shared CONTACTNAME As New SchemaItem("CONTACTNAME", DbType.AnsiString, SchemaItemJustify.None, 30, True, False, False, False)
	Public Shared CONTACTTITLE As New SchemaItem("CONTACTTITLE", DbType.AnsiString, SchemaItemJustify.None, 30, True, False, False, False)
	Public Shared ADDRESS As New SchemaItem("ADDRESS", DbType.AnsiString, SchemaItemJustify.None, 60, True, False, False, False)
	Public Shared CITY As New SchemaItem("CITY", DbType.AnsiString, SchemaItemJustify.None, 15, True, False, False, False)
	Public Shared REGION As New SchemaItem("REGION", DbType.AnsiString, SchemaItemJustify.None, 15, True, False, False, False)
	Public Shared POSTALCODE As New SchemaItem("POSTALCODE", DbType.AnsiString, SchemaItemJustify.None, 10, True, False, False, False)
	Public Shared COUNTRY As New SchemaItem("COUNTRY", DbType.AnsiString, SchemaItemJustify.None, 15, True, False, False, False)
	Public Shared PHONE As New SchemaItem("PHONE", DbType.AnsiString, SchemaItemJustify.None, 24, True, False, False, False)
	Public Shared FAX As New SchemaItem("FAX", DbType.AnsiString, SchemaItemJustify.None, 24, True, False, False, False)

    Public Overrides ReadOnly Property SchemaEntries() As ArrayList
        Get
            If _entries Is Nothing Then
                _entries = New ArrayList()
				_entries.Add(CustomersSchema.CUSTOMERID)
				_entries.Add(CustomersSchema.COMPANYNAME)
				_entries.Add(CustomersSchema.CONTACTNAME)
				_entries.Add(CustomersSchema.CONTACTTITLE)
				_entries.Add(CustomersSchema.ADDRESS)
				_entries.Add(CustomersSchema.CITY)
				_entries.Add(CustomersSchema.REGION)
				_entries.Add(CustomersSchema.POSTALCODE)
				_entries.Add(CustomersSchema.COUNTRY)
				_entries.Add(CustomersSchema.PHONE)
				_entries.Add(CustomersSchema.FAX)

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
		Me.SchemaGlobal = "MNOONA01"
    End Sub

	Public Overrides Sub FlushData()
		Me._whereClause = Nothing
		Me._aggregateClause = Nothing
		MyBase.FlushData()
	End Sub
		
	''' <summary>
	''' Loads the business object with info from the database, based on the requested primary key.
	''' </summary>
	''' <param name="CUSTOMERID"></param>
	''' <returns>A Boolean indicating success or failure of the query</returns>
	Public Function LoadByPrimaryKey(ByVal CUSTOMERID As String) As Boolean
		
		Select Case Me.DefaultCommandType
			Case CommandType.StoredProcedure
				Dim parameters As ListDictionary = New ListDictionary

				' Add in parameters
				parameters.Add(CustomersSchema.CUSTOMERID.FieldName, CUSTOMERID)

				Return MyBase.LoadFromSql(Me.SchemaStoredProcedureWithSeparator & "daab_GetCUSTOMERS", parameters, CommandType.StoredProcedure)
				
			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Me.Where.CUSTOMERID.Value = CUSTOMERID
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
				Return MyBase.LoadFromSql(Me.SchemaStoredProcedureWithSeparator & "daab_GetAllCUSTOMERS", parameters, CommandType.StoredProcedure)
				
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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_AddCUSTOMERS"
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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_UpdateCUSTOMERS"
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
				Me.Where.CUSTOMERID.Operator = WhereParameter.Operand.Equal
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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_DeleteCUSTOMERS"
				dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)
		
				' Add primary key parameters
				dbCommandWrapper.AddInParameter("CUSTOMERID", DbType.AnsiStringFixedLength, "CUSTOMERID", DataRowVersion.Current)

			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Me.Where.CUSTOMERID.Operator = WhereParameter.Operand.Equal
				dbCommandWrapper = Me.Query.GetDeleteCommandWrapper()

				dbCommandWrapper.Command.Parameters.Clear()
				dbCommandWrapper.AddInParameter("CUSTOMERID", DbType.AnsiStringFixedLength, "CUSTOMERID", DataRowVersion.Current)

			Case Else
				Throw New ArgumentException("Invalid CommandType", "commandType")
				
		End Select

        Return dbCommandWrapper

    End Function

    Private Sub CreateParameters(ByVal dbCommandWrapper As DBCommandWrapper)
		
		dbCommandWrapper.AddInParameter("CUSTOMERID", DbType.AnsiStringFixedLength, "CUSTOMERID", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("COMPANYNAME", DbType.AnsiString, "COMPANYNAME", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("CONTACTNAME", DbType.AnsiString, "CONTACTNAME", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("CONTACTTITLE", DbType.AnsiString, "CONTACTTITLE", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("ADDRESS", DbType.AnsiString, "ADDRESS", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("CITY", DbType.AnsiString, "CITY", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("REGION", DbType.AnsiString, "REGION", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("POSTALCODE", DbType.AnsiString, "POSTALCODE", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("COUNTRY", DbType.AnsiString, "COUNTRY", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("PHONE", DbType.AnsiString, "PHONE", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("FAX", DbType.AnsiString, "FAX", DataRowVersion.Current)

    End Sub

#Region " Properties "

	Public Overridable Property CUSTOMERID() As String
        Get
			Return Me.GetString(CustomersSchema.CUSTOMERID.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.CUSTOMERID.FieldName, Value)
      End Set
    End Property

	Public Overridable Property COMPANYNAME() As String
        Get
			Return Me.GetString(CustomersSchema.COMPANYNAME.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.COMPANYNAME.FieldName, Value)
      End Set
    End Property

	Public Overridable Property CONTACTNAME() As String
        Get
			Return Me.GetString(CustomersSchema.CONTACTNAME.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.CONTACTNAME.FieldName, Value)
      End Set
    End Property

	Public Overridable Property CONTACTTITLE() As String
        Get
			Return Me.GetString(CustomersSchema.CONTACTTITLE.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.CONTACTTITLE.FieldName, Value)
      End Set
    End Property

	Public Overridable Property ADDRESS() As String
        Get
			Return Me.GetString(CustomersSchema.ADDRESS.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.ADDRESS.FieldName, Value)
      End Set
    End Property

	Public Overridable Property CITY() As String
        Get
			Return Me.GetString(CustomersSchema.CITY.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.CITY.FieldName, Value)
      End Set
    End Property

	Public Overridable Property REGION() As String
        Get
			Return Me.GetString(CustomersSchema.REGION.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.REGION.FieldName, Value)
      End Set
    End Property

	Public Overridable Property POSTALCODE() As String
        Get
			Return Me.GetString(CustomersSchema.POSTALCODE.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.POSTALCODE.FieldName, Value)
      End Set
    End Property

	Public Overridable Property COUNTRY() As String
        Get
			Return Me.GetString(CustomersSchema.COUNTRY.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.COUNTRY.FieldName, Value)
      End Set
    End Property

	Public Overridable Property PHONE() As String
        Get
			Return Me.GetString(CustomersSchema.PHONE.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.PHONE.FieldName, Value)
      End Set
    End Property

	Public Overridable Property FAX() As String
        Get
			Return Me.GetString(CustomersSchema.FAX.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomersSchema.FAX.FieldName, Value)
      End Set
    End Property

    Public Overrides ReadOnly Property TableName() As String
        Get
            Return "CUSTOMERS"
        End Get
    End Property

#End Region

#Region " String Properties "
		Public Overridable Property s_CUSTOMERID As String
			Get
				If Me.IsColumnNull(CustomersSchema.CUSTOMERID.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.CUSTOMERID.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.CUSTOMERID.FieldName)
				Else
					Me.CUSTOMERID = MyBase.SetStringAsString(CustomersSchema.CUSTOMERID.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_COMPANYNAME As String
			Get
				If Me.IsColumnNull(CustomersSchema.COMPANYNAME.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.COMPANYNAME.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.COMPANYNAME.FieldName)
				Else
					Me.COMPANYNAME = MyBase.SetStringAsString(CustomersSchema.COMPANYNAME.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_CONTACTNAME As String
			Get
				If Me.IsColumnNull(CustomersSchema.CONTACTNAME.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.CONTACTNAME.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.CONTACTNAME.FieldName)
				Else
					Me.CONTACTNAME = MyBase.SetStringAsString(CustomersSchema.CONTACTNAME.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_CONTACTTITLE As String
			Get
				If Me.IsColumnNull(CustomersSchema.CONTACTTITLE.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.CONTACTTITLE.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.CONTACTTITLE.FieldName)
				Else
					Me.CONTACTTITLE = MyBase.SetStringAsString(CustomersSchema.CONTACTTITLE.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_ADDRESS As String
			Get
				If Me.IsColumnNull(CustomersSchema.ADDRESS.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.ADDRESS.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.ADDRESS.FieldName)
				Else
					Me.ADDRESS = MyBase.SetStringAsString(CustomersSchema.ADDRESS.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_CITY As String
			Get
				If Me.IsColumnNull(CustomersSchema.CITY.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.CITY.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.CITY.FieldName)
				Else
					Me.CITY = MyBase.SetStringAsString(CustomersSchema.CITY.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_REGION As String
			Get
				If Me.IsColumnNull(CustomersSchema.REGION.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.REGION.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.REGION.FieldName)
				Else
					Me.REGION = MyBase.SetStringAsString(CustomersSchema.REGION.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_POSTALCODE As String
			Get
				If Me.IsColumnNull(CustomersSchema.POSTALCODE.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.POSTALCODE.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.POSTALCODE.FieldName)
				Else
					Me.POSTALCODE = MyBase.SetStringAsString(CustomersSchema.POSTALCODE.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_COUNTRY As String
			Get
				If Me.IsColumnNull(CustomersSchema.COUNTRY.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.COUNTRY.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.COUNTRY.FieldName)
				Else
					Me.COUNTRY = MyBase.SetStringAsString(CustomersSchema.COUNTRY.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_PHONE As String
			Get
				If Me.IsColumnNull(CustomersSchema.PHONE.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.PHONE.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.PHONE.FieldName)
				Else
					Me.PHONE = MyBase.SetStringAsString(CustomersSchema.PHONE.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_FAX As String
			Get
				If Me.IsColumnNull(CustomersSchema.FAX.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomersSchema.FAX.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomersSchema.FAX.FieldName)
				Else
					Me.FAX = MyBase.SetStringAsString(CustomersSchema.FAX.FieldName, Value)
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

			Public ReadOnly Property CUSTOMERID() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.CUSTOMERID)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property COMPANYNAME() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.COMPANYNAME)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property CONTACTNAME() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.CONTACTNAME)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property CONTACTTITLE() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.CONTACTTITLE)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property ADDRESS() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.ADDRESS)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property CITY() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.CITY)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property REGION() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.REGION)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property POSTALCODE() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.POSTALCODE)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property COUNTRY() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.COUNTRY)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property PHONE() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.PHONE)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property FAX() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomersSchema.FAX)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

	End Class
	
	#End Region	

		Public ReadOnly Property CUSTOMERID() As WhereParameter 
			Get
				If _CUSTOMERID_W Is Nothing Then
					_CUSTOMERID_W = TearOff.CUSTOMERID
				End If
				Return _CUSTOMERID_W
			End Get
		End Property

		Public ReadOnly Property COMPANYNAME() As WhereParameter 
			Get
				If _COMPANYNAME_W Is Nothing Then
					_COMPANYNAME_W = TearOff.COMPANYNAME
				End If
				Return _COMPANYNAME_W
			End Get
		End Property

		Public ReadOnly Property CONTACTNAME() As WhereParameter 
			Get
				If _CONTACTNAME_W Is Nothing Then
					_CONTACTNAME_W = TearOff.CONTACTNAME
				End If
				Return _CONTACTNAME_W
			End Get
		End Property

		Public ReadOnly Property CONTACTTITLE() As WhereParameter 
			Get
				If _CONTACTTITLE_W Is Nothing Then
					_CONTACTTITLE_W = TearOff.CONTACTTITLE
				End If
				Return _CONTACTTITLE_W
			End Get
		End Property

		Public ReadOnly Property ADDRESS() As WhereParameter 
			Get
				If _ADDRESS_W Is Nothing Then
					_ADDRESS_W = TearOff.ADDRESS
				End If
				Return _ADDRESS_W
			End Get
		End Property

		Public ReadOnly Property CITY() As WhereParameter 
			Get
				If _CITY_W Is Nothing Then
					_CITY_W = TearOff.CITY
				End If
				Return _CITY_W
			End Get
		End Property

		Public ReadOnly Property REGION() As WhereParameter 
			Get
				If _REGION_W Is Nothing Then
					_REGION_W = TearOff.REGION
				End If
				Return _REGION_W
			End Get
		End Property

		Public ReadOnly Property POSTALCODE() As WhereParameter 
			Get
				If _POSTALCODE_W Is Nothing Then
					_POSTALCODE_W = TearOff.POSTALCODE
				End If
				Return _POSTALCODE_W
			End Get
		End Property

		Public ReadOnly Property COUNTRY() As WhereParameter 
			Get
				If _COUNTRY_W Is Nothing Then
					_COUNTRY_W = TearOff.COUNTRY
				End If
				Return _COUNTRY_W
			End Get
		End Property

		Public ReadOnly Property PHONE() As WhereParameter 
			Get
				If _PHONE_W Is Nothing Then
					_PHONE_W = TearOff.PHONE
				End If
				Return _PHONE_W
			End Get
		End Property

		Public ReadOnly Property FAX() As WhereParameter 
			Get
				If _FAX_W Is Nothing Then
					_FAX_W = TearOff.FAX
				End If
				Return _FAX_W
			End Get
		End Property

		Private _CUSTOMERID_W As WhereParameter = Nothing
		Private _COMPANYNAME_W As WhereParameter = Nothing
		Private _CONTACTNAME_W As WhereParameter = Nothing
		Private _CONTACTTITLE_W As WhereParameter = Nothing
		Private _ADDRESS_W As WhereParameter = Nothing
		Private _CITY_W As WhereParameter = Nothing
		Private _REGION_W As WhereParameter = Nothing
		Private _POSTALCODE_W As WhereParameter = Nothing
		Private _COUNTRY_W As WhereParameter = Nothing
		Private _PHONE_W As WhereParameter = Nothing
		Private _FAX_W As WhereParameter = Nothing

		Public Sub WhereClauseReset()

		_CUSTOMERID_W = Nothing
		_COMPANYNAME_W = Nothing
		_CONTACTNAME_W = Nothing
		_CONTACTTITLE_W = Nothing
		_ADDRESS_W = Nothing
		_CITY_W = Nothing
		_REGION_W = Nothing
		_POSTALCODE_W = Nothing
		_COUNTRY_W = Nothing
		_PHONE_W = Nothing
		_FAX_W = Nothing
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

			Public ReadOnly Property CUSTOMERID() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.CUSTOMERID)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property COMPANYNAME() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.COMPANYNAME)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property CONTACTNAME() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.CONTACTNAME)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property CONTACTTITLE() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.CONTACTTITLE)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property ADDRESS() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.ADDRESS)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property CITY() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.CITY)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property REGION() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.REGION)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property POSTALCODE() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.POSTALCODE)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property COUNTRY() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.COUNTRY)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property PHONE() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.PHONE)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property FAX() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomersSchema.FAX)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

	End Class
	
	#End Region	

		Public ReadOnly Property CUSTOMERID() As AggregateParameter 
			Get
				If _CUSTOMERID_W Is Nothing Then
					_CUSTOMERID_W = TearOff.CUSTOMERID
				End If
				Return _CUSTOMERID_W
			End Get
		End Property

		Public ReadOnly Property COMPANYNAME() As AggregateParameter 
			Get
				If _COMPANYNAME_W Is Nothing Then
					_COMPANYNAME_W = TearOff.COMPANYNAME
				End If
				Return _COMPANYNAME_W
			End Get
		End Property

		Public ReadOnly Property CONTACTNAME() As AggregateParameter 
			Get
				If _CONTACTNAME_W Is Nothing Then
					_CONTACTNAME_W = TearOff.CONTACTNAME
				End If
				Return _CONTACTNAME_W
			End Get
		End Property

		Public ReadOnly Property CONTACTTITLE() As AggregateParameter 
			Get
				If _CONTACTTITLE_W Is Nothing Then
					_CONTACTTITLE_W = TearOff.CONTACTTITLE
				End If
				Return _CONTACTTITLE_W
			End Get
		End Property

		Public ReadOnly Property ADDRESS() As AggregateParameter 
			Get
				If _ADDRESS_W Is Nothing Then
					_ADDRESS_W = TearOff.ADDRESS
				End If
				Return _ADDRESS_W
			End Get
		End Property

		Public ReadOnly Property CITY() As AggregateParameter 
			Get
				If _CITY_W Is Nothing Then
					_CITY_W = TearOff.CITY
				End If
				Return _CITY_W
			End Get
		End Property

		Public ReadOnly Property REGION() As AggregateParameter 
			Get
				If _REGION_W Is Nothing Then
					_REGION_W = TearOff.REGION
				End If
				Return _REGION_W
			End Get
		End Property

		Public ReadOnly Property POSTALCODE() As AggregateParameter 
			Get
				If _POSTALCODE_W Is Nothing Then
					_POSTALCODE_W = TearOff.POSTALCODE
				End If
				Return _POSTALCODE_W
			End Get
		End Property

		Public ReadOnly Property COUNTRY() As AggregateParameter 
			Get
				If _COUNTRY_W Is Nothing Then
					_COUNTRY_W = TearOff.COUNTRY
				End If
				Return _COUNTRY_W
			End Get
		End Property

		Public ReadOnly Property PHONE() As AggregateParameter 
			Get
				If _PHONE_W Is Nothing Then
					_PHONE_W = TearOff.PHONE
				End If
				Return _PHONE_W
			End Get
		End Property

		Public ReadOnly Property FAX() As AggregateParameter 
			Get
				If _FAX_W Is Nothing Then
					_FAX_W = TearOff.FAX
				End If
				Return _FAX_W
			End Get
		End Property

		Private _CUSTOMERID_W As AggregateParameter = Nothing
		Private _COMPANYNAME_W As AggregateParameter = Nothing
		Private _CONTACTNAME_W As AggregateParameter = Nothing
		Private _CONTACTTITLE_W As AggregateParameter = Nothing
		Private _ADDRESS_W As AggregateParameter = Nothing
		Private _CITY_W As AggregateParameter = Nothing
		Private _REGION_W As AggregateParameter = Nothing
		Private _POSTALCODE_W As AggregateParameter = Nothing
		Private _COUNTRY_W As AggregateParameter = Nothing
		Private _PHONE_W As AggregateParameter = Nothing
		Private _FAX_W As AggregateParameter = Nothing

		Public Sub AggregateClauseReset()

		_CUSTOMERID_W = Nothing
		_COMPANYNAME_W = Nothing
		_CONTACTNAME_W = Nothing
		_CONTACTTITLE_W = Nothing
		_ADDRESS_W = Nothing
		_CITY_W = Nothing
		_REGION_W = Nothing
		_POSTALCODE_W = Nothing
		_COUNTRY_W = Nothing
		_PHONE_W = Nothing
		_FAX_W = Nothing
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

End NameSpace


