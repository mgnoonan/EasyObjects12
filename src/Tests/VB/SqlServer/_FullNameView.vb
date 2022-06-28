
' Generated by MyGeneration Version # (1.1.4.0)

Imports System
Imports System.Data
Imports System.Collections
Imports System.Collections.Specialized
 
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports NCI.EasyObjects


NameSpace EasyObjects.Tests.SQL


	#Region " Schema "

	Public Class FullNameViewSchema
		Inherits NCI.EasyObjects.Schema

		Private Shared _entries As ArrayList
		Public Shared FullName As New SchemaItem("FullName", DbType.AnsiString, SchemaItemJustify.None, 42, True, False, False)
		Public Shared DepartmentID As New SchemaItem("DepartmentID", DbType.Int32, False, True, False, False, False)
		Public Shared HireDate As New SchemaItem("HireDate", DbType.DateTime, False, True, False, False, False)
		Public Shared Salary As New SchemaItem("Salary", DbType.Decimal, False, True, False, False, False)
		Public Shared IsActive As New SchemaItem("IsActive", DbType.Boolean, False, True, False, False, False)

		Public Overrides ReadOnly Property SchemaEntries() As ArrayList
			Get 
				If _entries Is Nothing Then
					_entries = new ArrayList()
					_entries.Add(FullNameViewSchema.FullName)
					_entries.Add(FullNameViewSchema.DepartmentID)
					_entries.Add(FullNameViewSchema.HireDate)
					_entries.Add(FullNameViewSchema.Salary)
					_entries.Add(FullNameViewSchema.IsActive)
				End If
				Return _entries
			End Get
		End Property
	End Class
	#End Region

Public Class _FullNameView
	Inherits EasyObject
	
		Public Sub New()
			Dim _schema As FullNameViewSchema = New FullNameViewSchema()
			Me.SchemaEntries = _schema.SchemaEntries
			Me.SchemaGlobal = "dbo"
		End Sub
	
		'=================================================================
		'  	public Function LoadAll() As Boolean
		'=================================================================
		'  Loads all of the records in the database, and sets the currentRow to the first row
		'=================================================================
		Public Function LoadAll() As Boolean
			Return MyBase.Query.Load()
		End Function
		
		Public Overrides Sub FlushData()
			Me._whereClause = Nothing
			Me._aggregateClause = Nothing
			MyBase.FlushData()
		End Sub
		
		#Region " Properties "
		Public Overridable Property FullName As String
			Get
				Return MyBase.GetString(FullNameViewSchema.FullName.FieldName)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(FullNameViewSchema.FullName.FieldName, Value)
			End Set
		End Property

		Public Overridable Property DepartmentID As Integer
			Get
				Return MyBase.GetInteger(FullNameViewSchema.DepartmentID.FieldName)
			End Get
			Set(ByVal Value As Integer)
				MyBase.SetInteger(FullNameViewSchema.DepartmentID.FieldName, Value)
			End Set
		End Property

		Public Overridable Property HireDate As DateTime
			Get
				Return MyBase.GetDateTime(FullNameViewSchema.HireDate.FieldName)
			End Get
			Set(ByVal Value As DateTime)
				MyBase.SetDateTime(FullNameViewSchema.HireDate.FieldName, Value)
			End Set
		End Property

		Public Overridable Property Salary As Decimal
			Get
				Return MyBase.GetDecimal(FullNameViewSchema.Salary.FieldName)
			End Get
			Set(ByVal Value As Decimal)
				MyBase.SetDecimal(FullNameViewSchema.Salary.FieldName, Value)
			End Set
		End Property

		Public Overridable Property IsActive As Boolean
			Get
				Return MyBase.GetBoolean(FullNameViewSchema.IsActive.FieldName)
			End Get
			Set(ByVal Value As Boolean)
				MyBase.SetBoolean(FullNameViewSchema.IsActive.FieldName, Value)
			End Set
		End Property


		Public Overrides ReadOnly Property TableName As String
			Get 
				Return "FullNameView"
			End Get
		End Property
		
		#End Region		
		
		#Region " String Properties "

		Public Overridable Property s_FullName As String
			Get
				If Me.IsColumnNull(FullNameViewSchema.FullName.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(FullNameViewSchema.FullName.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(FullNameViewSchema.FullName.FieldName)
				Else
					Me.FullName = MyBase.SetStringAsString(FullNameViewSchema.FullName.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_DepartmentID As String
			Get
				If Me.IsColumnNull(FullNameViewSchema.DepartmentID.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetIntegerAsString(FullNameViewSchema.DepartmentID.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(FullNameViewSchema.DepartmentID.FieldName)
				Else
					Me.DepartmentID = MyBase.SetIntegerAsString(FullNameViewSchema.DepartmentID.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_HireDate As String
			Get
				If Me.IsColumnNull(FullNameViewSchema.HireDate.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetDateTimeAsString(FullNameViewSchema.HireDate.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(FullNameViewSchema.HireDate.FieldName)
				Else
					Me.HireDate = MyBase.SetDateTimeAsString(FullNameViewSchema.HireDate.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_Salary As String
			Get
				If Me.IsColumnNull(FullNameViewSchema.Salary.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetDecimalAsString(FullNameViewSchema.Salary.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(FullNameViewSchema.Salary.FieldName)
				Else
					Me.Salary = MyBase.SetDecimalAsString(FullNameViewSchema.Salary.FieldName, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_IsActive As String
			Get
				If Me.IsColumnNull(FullNameViewSchema.IsActive.FieldName) Then
					Return String.Empty
				Else
					Return MyBase.GetBooleanAsString(FullNameViewSchema.IsActive.FieldName)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(FullNameViewSchema.IsActive.FieldName)
				Else
					Me.IsActive = MyBase.SetBooleanAsString(FullNameViewSchema.IsActive.FieldName, Value)
				End If
			End Set
		End Property


		#End Region		
	
		#Region " Where Clause "
		Public Class WhereClause

			Public Sub New(ByVal entity As EasyObject)
				Me._entity = entity
			End Sub
			
			Public ReadOnly Property TearOff() As TearOffWhereParameter
				Get 
					If _tearOff Is Nothing Then
						_tearOff = New TearOffWhereParameter(Me)
					End If
 
					Return _tearOff
				End Get
			End Property

			#Region " TearOff's "
			Public Class TearOffWhereParameter
			
				Public Sub New(ByVal clause As WhereClause)
					Me._clause = clause
				End Sub
				
			
		Public ReadOnly Property FullName() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(FullNameViewSchema.FullName)
				Me._clause._entity.Query.AddWhereParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property DepartmentID() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(FullNameViewSchema.DepartmentID)
				Me._clause._entity.Query.AddWhereParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property HireDate() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(FullNameViewSchema.HireDate)
				Me._clause._entity.Query.AddWhereParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property Salary() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(FullNameViewSchema.Salary)
				Me._clause._entity.Query.AddWhereParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property IsActive() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(FullNameViewSchema.IsActive)
				Me._clause._entity.Query.AddWhereParameter(where)
				Return where
			End Get
		End Property


				Private _clause as WhereClause
			End Class
			#End Region	
		
		Public ReadOnly Property FullName() As WhereParameter 
			Get
				If _FullName_W Is Nothing Then
					_FullName_W = TearOff.FullName
				End If
				Return _FullName_W
			End Get
		End Property

		Public ReadOnly Property DepartmentID() As WhereParameter 
			Get
				If _DepartmentID_W Is Nothing Then
					_DepartmentID_W = TearOff.DepartmentID
				End If
				Return _DepartmentID_W
			End Get
		End Property

		Public ReadOnly Property HireDate() As WhereParameter 
			Get
				If _HireDate_W Is Nothing Then
					_HireDate_W = TearOff.HireDate
				End If
				Return _HireDate_W
			End Get
		End Property

		Public ReadOnly Property Salary() As WhereParameter 
			Get
				If _Salary_W Is Nothing Then
					_Salary_W = TearOff.Salary
				End If
				Return _Salary_W
			End Get
		End Property

		Public ReadOnly Property IsActive() As WhereParameter 
			Get
				If _IsActive_W Is Nothing Then
					_IsActive_W = TearOff.IsActive
				End If
				Return _IsActive_W
			End Get
		End Property

		Private _FullName_W As WhereParameter = Nothing
		Private _DepartmentID_W As WhereParameter = Nothing
		Private _HireDate_W As WhereParameter = Nothing
		Private _Salary_W As WhereParameter = Nothing
		Private _IsActive_W As WhereParameter = Nothing

		Public Sub WhereClauseReset()

		_FullName_W = Nothing
		_DepartmentID_W = Nothing
		_HireDate_W = Nothing
		_Salary_W = Nothing
		_IsActive_W = Nothing
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
			
			Public ReadOnly Property TearOff() As TearOffAggregateParameter
				Get 
					If _tearOff Is Nothing Then
						_tearOff = New TearOffAggregateParameter(Me)
					End If
 
					Return _tearOff
				End Get
			End Property

			#Region " TearOff's "
			Public Class TearOffAggregateParameter
			
				Public Sub New(ByVal clause As AggregateClause)
					Me._clause = clause
				End Sub
				
			
		Public ReadOnly Property FullName() As AggregateParameter
			Get
				Dim aggregate As AggregateParameter = New AggregateParameter(FullNameViewSchema.FullName)
				Me._clause._entity.Query.AddAggregateParameter(aggregate)
				Return aggregate
			End Get
		End Property

		Public ReadOnly Property DepartmentID() As AggregateParameter
			Get
				Dim aggregate As AggregateParameter = New AggregateParameter(FullNameViewSchema.DepartmentID)
				Me._clause._entity.Query.AddAggregateParameter(aggregate)
				Return aggregate
			End Get
		End Property

		Public ReadOnly Property HireDate() As AggregateParameter
			Get
				Dim aggregate As AggregateParameter = New AggregateParameter(FullNameViewSchema.HireDate)
				Me._clause._entity.Query.AddAggregateParameter(aggregate)
				Return aggregate
			End Get
		End Property

		Public ReadOnly Property Salary() As AggregateParameter
			Get
				Dim aggregate As AggregateParameter = New AggregateParameter(FullNameViewSchema.Salary)
				Me._clause._entity.Query.AddAggregateParameter(aggregate)
				Return aggregate
			End Get
		End Property

		Public ReadOnly Property IsActive() As AggregateParameter
			Get
				Dim aggregate As AggregateParameter = New AggregateParameter(FullNameViewSchema.IsActive)
				Me._clause._entity.Query.AddAggregateParameter(aggregate)
				Return aggregate
			End Get
		End Property


				Private _clause as AggregateClause
			End Class
			#End Region	
		
		Public ReadOnly Property FullName() As AggregateParameter 
			Get
				If _FullName_W Is Nothing Then
					_FullName_W = TearOff.FullName
				End If
				Return _FullName_W
			End Get
		End Property

		Public ReadOnly Property DepartmentID() As AggregateParameter 
			Get
				If _DepartmentID_W Is Nothing Then
					_DepartmentID_W = TearOff.DepartmentID
				End If
				Return _DepartmentID_W
			End Get
		End Property

		Public ReadOnly Property HireDate() As AggregateParameter 
			Get
				If _HireDate_W Is Nothing Then
					_HireDate_W = TearOff.HireDate
				End If
				Return _HireDate_W
			End Get
		End Property

		Public ReadOnly Property Salary() As AggregateParameter 
			Get
				If _Salary_W Is Nothing Then
					_Salary_W = TearOff.Salary
				End If
				Return _Salary_W
			End Get
		End Property

		Public ReadOnly Property IsActive() As AggregateParameter 
			Get
				If _IsActive_W Is Nothing Then
					_IsActive_W = TearOff.IsActive
				End If
				Return _IsActive_W
			End Get
		End Property

		Private _FullName_W As AggregateParameter = Nothing
		Private _DepartmentID_W As AggregateParameter = Nothing
		Private _HireDate_W As AggregateParameter = Nothing
		Private _Salary_W As AggregateParameter = Nothing
		Private _IsActive_W As AggregateParameter = Nothing

		Public Sub AggregateClauseReset()

		_FullName_W = Nothing
		_DepartmentID_W = Nothing
		_HireDate_W = Nothing
		_Salary_W = Nothing
		_IsActive_W = Nothing
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

