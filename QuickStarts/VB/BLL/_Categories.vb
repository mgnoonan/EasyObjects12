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

Public Class CategoriesSchema
	Inherits NCI.EasyObjects.Schema

    Private Shared _entries As ArrayList
	Public Shared CategoryID As New SchemaItem("CategoryID", DbType.Int32, True, False, False, True, True, False)
	Public Shared CategoryName As New SchemaItem("CategoryName", DbType.String, SchemaItemJustify.None, 15, False, False, False, False)
	Public Shared Description As New SchemaItem("Description", DbType.String, SchemaItemJustify.None, 1073741823, True, False, False, False)
	Public Shared Picture As New SchemaItem("Picture", DbType.Binary, False, True, False, False, False, False)

    Public Overrides ReadOnly Property SchemaEntries() As ArrayList
        Get
            If _entries Is Nothing Then
                _entries = New ArrayList()
				_entries.Add(CategoriesSchema.CategoryID)
				_entries.Add(CategoriesSchema.CategoryName)
				_entries.Add(CategoriesSchema.Description)
				_entries.Add(CategoriesSchema.Picture)

            End If
            Return _entries
        End Get
    End Property

End Class

#End Region

Public MustInherit Class _Categories
    Inherits NCI.EasyObjects.EasyObject

    Sub New()
        Dim _schema As New CategoriesSchema()
        Me.SchemaEntries = _schema.SchemaEntries
		Me.SchemaGlobal = "test"
    End Sub

	Public Overrides Sub FlushData()
		Me._whereClause = Nothing
		Me._aggregateClause = Nothing
		MyBase.FlushData()
	End Sub
		
	''' <summary>
	''' Loads the business object with info from the database, based on the requested primary key.
	''' </summary>
	''' <param name="CategoryID"></param>
	''' <returns>A Boolean indicating success or failure of the query</returns>
	Public Function LoadByPrimaryKey(ByVal CategoryID As Integer) As Boolean
		
		Select Case Me.DefaultCommandType
			Case CommandType.StoredProcedure
				Dim parameters As ListDictionary = New ListDictionary

				' Add in parameters
				parameters.Add(CategoriesSchema.CategoryID.FieldName, CategoryID)

				Return MyBase.LoadFromSql(Me.SchemaStoredProcedureWithSeparator & "daab_GetCategories", parameters, CommandType.StoredProcedure)
				
			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Me.Where.CategoryID.Value = CategoryID
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
				Return MyBase.LoadFromSql(Me.SchemaStoredProcedureWithSeparator & "daab_GetAllCategories", parameters, CommandType.StoredProcedure)
				
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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_AddCategories"
				dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)
		
				dbCommandWrapper.AddParameter("CategoryID", DbType.Int32, 0, ParameterDirection.Output, true, 0, 0, "CategoryID", DataRowVersion.Default, Convert.DBNull)
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
					dbCommandWrapper.AddInParameter("CategoryID", DbType.Int32, "CategoryID", DataRowVersion.Default)
				Else
					dbCommandWrapper.AddParameter("CategoryID", DbType.Int32, 0, ParameterDirection.Output, true, 0, 0, "CategoryID", DataRowVersion.Default, Convert.DBNull)
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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_UpdateCategories"
				dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)
				
				dbCommandWrapper.AddInParameter("CategoryID", DbType.Int32, "CategoryID", DataRowVersion.Current)
				CreateParameters(dbCommandWrapper)

			Case CommandType.Text
                Me.Query.ClearAll()
				For Each item As SchemaItem In Me.SchemaEntries
					If Not (item.IsAutoKey OrElse item.IsComputed)
						Me.Query.AddUpdateColumn(item)
					End If
				Next

				Me.Where.WhereClauseReset()
				Me.Where.CategoryID.Operator = WhereParameter.Operand.Equal
				dbCommandWrapper = Me.Query.GetUpdateCommandWrapper()

				dbCommandWrapper.Command.Parameters.Clear()
				CreateParameters(dbCommandWrapper)
				dbCommandWrapper.AddInParameter("CategoryID", DbType.Int32, "CategoryID", DataRowVersion.Current)

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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_DeleteCategories"
				dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)
		
				' Add primary key parameters
				dbCommandWrapper.AddInParameter("CategoryID", DbType.Int32, "CategoryID", DataRowVersion.Current)

			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Me.Where.CategoryID.Operator = WhereParameter.Operand.Equal
				dbCommandWrapper = Me.Query.GetDeleteCommandWrapper()

				dbCommandWrapper.Command.Parameters.Clear()
				dbCommandWrapper.AddInParameter("CategoryID", DbType.Int32, "CategoryID", DataRowVersion.Current)

			Case Else
				Throw New ArgumentException("Invalid CommandType", "commandType")
				
		End Select

        Return dbCommandWrapper

    End Function

    Private Sub CreateParameters(ByVal dbCommandWrapper As DBCommandWrapper)
		
		dbCommandWrapper.AddInParameter("CategoryName", DbType.String, "CategoryName", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("Description", DbType.String, "Description", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("Picture", DbType.Binary, "Picture", DataRowVersion.Current)

    End Sub

#Region " Properties "

	Public Overridable Property CategoryID() As Integer
        Get
			Return Me.GetInteger(CategoriesSchema.CategoryID.FieldName)
      End Get
        Set(ByVal Value As Integer)
			Me.SetInteger(CategoriesSchema.CategoryID.FieldName, Value)
      End Set
    End Property

	Public Overridable Property CategoryName() As String
        Get
			Return Me.GetString(CategoriesSchema.CategoryName.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CategoriesSchema.CategoryName.FieldName, Value)
      End Set
    End Property

	Public Overridable Property Description() As String
        Get
			Return Me.GetString(CategoriesSchema.Description.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CategoriesSchema.Description.FieldName, Value)
      End Set
    End Property

	Public Overridable Property Picture() As Byte()
        Get
			Return Me.GetByteArray(CategoriesSchema.Picture.FieldName)
      End Get
        Set(ByVal Value As Byte())
			Me.SetByteArray(CategoriesSchema.Picture.FieldName, Value)
      End Set
    End Property

    Public Overrides ReadOnly Property TableName() As String
        Get
            Return "Categories"
        End Get
    End Property

#End Region

#Region " String Properties "
		Public Overridable Property s_CategoryID As String
			Get
				If Me.IsColumnNull(CategoriesSchema.CategoryID.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetIntegerAsString(CategoriesSchema.CategoryID.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CategoriesSchema.CategoryID.FieldName)
				Else
					Me.CategoryID = MyBase.SetIntegerAsString(CategoriesSchema.CategoryID.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_CategoryName As String
			Get
				If Me.IsColumnNull(CategoriesSchema.CategoryName.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CategoriesSchema.CategoryName.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CategoriesSchema.CategoryName.FieldName)
				Else
					Me.CategoryName = MyBase.SetStringAsString(CategoriesSchema.CategoryName.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_Description As String
			Get
				If Me.IsColumnNull(CategoriesSchema.Description.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CategoriesSchema.Description.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CategoriesSchema.Description.FieldName)
				Else
					Me.Description = MyBase.SetStringAsString(CategoriesSchema.Description.FieldName, Value)
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

			Public ReadOnly Property CategoryID() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CategoriesSchema.CategoryID)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property CategoryName() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CategoriesSchema.CategoryName)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property Description() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CategoriesSchema.Description)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property Picture() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CategoriesSchema.Picture)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

	End Class
	
	#End Region	

		Public ReadOnly Property CategoryID() As WhereParameter 
			Get
				If _CategoryID_W Is Nothing Then
					_CategoryID_W = TearOff.CategoryID
				End If
				Return _CategoryID_W
			End Get
		End Property

		Public ReadOnly Property CategoryName() As WhereParameter 
			Get
				If _CategoryName_W Is Nothing Then
					_CategoryName_W = TearOff.CategoryName
				End If
				Return _CategoryName_W
			End Get
		End Property

		Public ReadOnly Property Description() As WhereParameter 
			Get
				If _Description_W Is Nothing Then
					_Description_W = TearOff.Description
				End If
				Return _Description_W
			End Get
		End Property

		Public ReadOnly Property Picture() As WhereParameter 
			Get
				If _Picture_W Is Nothing Then
					_Picture_W = TearOff.Picture
				End If
				Return _Picture_W
			End Get
		End Property

		Private _CategoryID_W As WhereParameter = Nothing
		Private _CategoryName_W As WhereParameter = Nothing
		Private _Description_W As WhereParameter = Nothing
		Private _Picture_W As WhereParameter = Nothing

		Public Sub WhereClauseReset()

		_CategoryID_W = Nothing
		_CategoryName_W = Nothing
		_Description_W = Nothing
		_Picture_W = Nothing
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

			Public ReadOnly Property CategoryID() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CategoriesSchema.CategoryID)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property CategoryName() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CategoriesSchema.CategoryName)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property Description() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CategoriesSchema.Description)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property Picture() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CategoriesSchema.Picture)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

	End Class
	
	#End Region	

		Public ReadOnly Property CategoryID() As AggregateParameter 
			Get
				If _CategoryID_W Is Nothing Then
					_CategoryID_W = TearOff.CategoryID
				End If
				Return _CategoryID_W
			End Get
		End Property

		Public ReadOnly Property CategoryName() As AggregateParameter 
			Get
				If _CategoryName_W Is Nothing Then
					_CategoryName_W = TearOff.CategoryName
				End If
				Return _CategoryName_W
			End Get
		End Property

		Public ReadOnly Property Description() As AggregateParameter 
			Get
				If _Description_W Is Nothing Then
					_Description_W = TearOff.Description
				End If
				Return _Description_W
			End Get
		End Property

		Public ReadOnly Property Picture() As AggregateParameter 
			Get
				If _Picture_W Is Nothing Then
					_Picture_W = TearOff.Picture
				End If
				Return _Picture_W
			End Get
		End Property

		Private _CategoryID_W As AggregateParameter = Nothing
		Private _CategoryName_W As AggregateParameter = Nothing
		Private _Description_W As AggregateParameter = Nothing
		Private _Picture_W As AggregateParameter = Nothing

		Public Sub AggregateClauseReset()

		_CategoryID_W = Nothing
		_CategoryName_W = Nothing
		_Description_W = Nothing
		_Picture_W = Nothing
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


