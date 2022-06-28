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

Public Class CustomerDemographicsSchema
	Inherits NCI.EasyObjects.Schema

    Private Shared _entries As ArrayList
	Public Shared CustomerTypeID As New SchemaItem("CustomerTypeID", DbType.StringFixedLength, SchemaItemJustify.None, 10, False, True, True, False)
	Public Shared CustomerDesc As New SchemaItem("CustomerDesc", DbType.String, SchemaItemJustify.None, 1073741823, True, False, False, False)

    Public Overrides ReadOnly Property SchemaEntries() As ArrayList
        Get
            If _entries Is Nothing Then
                _entries = New ArrayList()
				_entries.Add(CustomerDemographicsSchema.CustomerTypeID)
				_entries.Add(CustomerDemographicsSchema.CustomerDesc)

            End If
            Return _entries
        End Get
    End Property

End Class

#End Region

Public MustInherit Class _CustomerDemographics
    Inherits NCI.EasyObjects.EasyObject

    Sub New()
        Dim _schema As New CustomerDemographicsSchema()
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
	''' <param name="CustomerTypeID"></param>
	''' <returns>A Boolean indicating success or failure of the query</returns>
	Public Function LoadByPrimaryKey(ByVal CustomerTypeID As String) As Boolean
		
		Select Case Me.DefaultCommandType
			Case CommandType.StoredProcedure
				Dim parameters As ListDictionary = New ListDictionary

				' Add in parameters
				parameters.Add(CustomerDemographicsSchema.CustomerTypeID.FieldName, CustomerTypeID)

				Return MyBase.LoadFromSql(Me.SchemaStoredProcedureWithSeparator & "daab_GetCustomerDemographics", parameters, CommandType.StoredProcedure)
				
			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Me.Where.CustomerTypeID.Value = CustomerTypeID
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
				Return MyBase.LoadFromSql(Me.SchemaStoredProcedureWithSeparator & "daab_GetAllCustomerDemographics", parameters, CommandType.StoredProcedure)
				
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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_AddCustomerDemographics"
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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_UpdateCustomerDemographics"
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
				Me.Where.CustomerTypeID.Operator = WhereParameter.Operand.Equal
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
				Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator & "daab_DeleteCustomerDemographics"
				dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)
		
				' Add primary key parameters
				dbCommandWrapper.AddInParameter("CustomerTypeID", DbType.StringFixedLength, "CustomerTypeID", DataRowVersion.Current)

			Case CommandType.Text
                Me.Query.ClearAll()
                Me.Where.WhereClauseReset()
				Me.Where.CustomerTypeID.Operator = WhereParameter.Operand.Equal
				dbCommandWrapper = Me.Query.GetDeleteCommandWrapper()

				dbCommandWrapper.Command.Parameters.Clear()
				dbCommandWrapper.AddInParameter("CustomerTypeID", DbType.StringFixedLength, "CustomerTypeID", DataRowVersion.Current)

			Case Else
				Throw New ArgumentException("Invalid CommandType", "commandType")
				
		End Select

        Return dbCommandWrapper

    End Function

    Private Sub CreateParameters(ByVal dbCommandWrapper As DBCommandWrapper)
		
		dbCommandWrapper.AddInParameter("CustomerTypeID", DbType.StringFixedLength, "CustomerTypeID", DataRowVersion.Current)
		dbCommandWrapper.AddInParameter("CustomerDesc", DbType.String, "CustomerDesc", DataRowVersion.Current)

    End Sub

#Region " Properties "

	Public Overridable Property CustomerTypeID() As String
        Get
			Return Me.GetString(CustomerDemographicsSchema.CustomerTypeID.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomerDemographicsSchema.CustomerTypeID.FieldName, Value)
      End Set
    End Property

	Public Overridable Property CustomerDesc() As String
        Get
			Return Me.GetString(CustomerDemographicsSchema.CustomerDesc.FieldName)
      End Get
        Set(ByVal Value As String)
			Me.SetString(CustomerDemographicsSchema.CustomerDesc.FieldName, Value)
      End Set
    End Property

    Public Overrides ReadOnly Property TableName() As String
        Get
            Return "CustomerDemographics"
        End Get
    End Property

#End Region

#Region " String Properties "
		Public Overridable Property s_CustomerTypeID As String
			Get
				If Me.IsColumnNull(CustomerDemographicsSchema.CustomerTypeID.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomerDemographicsSchema.CustomerTypeID.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomerDemographicsSchema.CustomerTypeID.FieldName)
				Else
					Me.CustomerTypeID = MyBase.SetStringAsString(CustomerDemographicsSchema.CustomerTypeID.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_CustomerDesc As String
			Get
				If Me.IsColumnNull(CustomerDemographicsSchema.CustomerDesc.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(CustomerDemographicsSchema.CustomerDesc.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(CustomerDemographicsSchema.CustomerDesc.FieldName)
				Else
					Me.CustomerDesc = MyBase.SetStringAsString(CustomerDemographicsSchema.CustomerDesc.FieldName, Value)
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

			Public ReadOnly Property CustomerTypeID() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomerDemographicsSchema.CustomerTypeID)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

			Public ReadOnly Property CustomerDesc() As WhereParameter
				Get
					Dim wp As WhereParameter = New WhereParameter(CustomerDemographicsSchema.CustomerDesc)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddWhereParameter(wp)
					Return wp
				End Get
			End Property

	End Class
	
	#End Region	

		Public ReadOnly Property CustomerTypeID() As WhereParameter 
			Get
				If _CustomerTypeID_W Is Nothing Then
					_CustomerTypeID_W = TearOff.CustomerTypeID
				End If
				Return _CustomerTypeID_W
			End Get
		End Property

		Public ReadOnly Property CustomerDesc() As WhereParameter 
			Get
				If _CustomerDesc_W Is Nothing Then
					_CustomerDesc_W = TearOff.CustomerDesc
				End If
				Return _CustomerDesc_W
			End Get
		End Property

		Private _CustomerTypeID_W As WhereParameter = Nothing
		Private _CustomerDesc_W As WhereParameter = Nothing

		Public Sub WhereClauseReset()

		_CustomerTypeID_W = Nothing
		_CustomerDesc_W = Nothing
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

			Public ReadOnly Property CustomerTypeID() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomerDemographicsSchema.CustomerTypeID)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

			Public ReadOnly Property CustomerDesc() As AggregateParameter
				Get
					Dim ap As AggregateParameter = New AggregateParameter(CustomerDemographicsSchema.CustomerDesc)
                    Dim query As NCI.EasyObjects.DynamicQuery = Me._clause._entity.Query
                    query.AddAggregateParameter(ap)
					Return ap
				End Get
			End Property

	End Class
	
	#End Region	

		Public ReadOnly Property CustomerTypeID() As AggregateParameter 
			Get
				If _CustomerTypeID_W Is Nothing Then
					_CustomerTypeID_W = TearOff.CustomerTypeID
				End If
				Return _CustomerTypeID_W
			End Get
		End Property

		Public ReadOnly Property CustomerDesc() As AggregateParameter 
			Get
				If _CustomerDesc_W Is Nothing Then
					_CustomerDesc_W = TearOff.CustomerDesc
				End If
				Return _CustomerDesc_W
			End Get
		End Property

		Private _CustomerTypeID_W As AggregateParameter = Nothing
		Private _CustomerDesc_W As AggregateParameter = Nothing

		Public Sub AggregateClauseReset()

		_CustomerTypeID_W = Nothing
		_CustomerDesc_W = Nothing
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


