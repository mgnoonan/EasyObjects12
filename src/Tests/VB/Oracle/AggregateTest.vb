Imports System
Imports System.Data
Imports System.Collections.Specialized
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports NCI.EasyObjects

Namespace EasyObjects.Tests.Oracle
    Public Class AggregateTest
        Inherits _AggregateTest

        Public Sub New()
        End Sub

        Public Function GetReaderAggregateTest() As IDataReader
            '  Create the Database object, using the default database service. The
            '  default database service is determined through configuration.
            Dim db As Database = GetDatabase()

            Dim sqlCommand As String = Me.SchemaStoredProcedureWithSeparator + "daab_GetAllAggregateTest"
            Dim dbCommandWrapper As DBCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand)

            ' Add procedure parameters

            Return MyBase.LoadFromSqlReader(dbCommandWrapper)
        End Function

        Public Function GetScalarAggregateTest() As Object
            '  Create the Database object, using the default database service. The
            '  default database service is determined through configuration.
            Dim db As Database = GetDatabase()

            Dim sqlCommand As String = "SELECT COUNT(*) FROM " + Me.SchemaTableViewWithSeparator + Me.TableName
            Dim dbCommandWrapper As DBCommandWrapper = db.GetSqlStringCommandWrapper(sqlCommand)

            ' Add procedure parameters

            Return MyBase.LoadFromSqlScalar(dbCommandWrapper)
        End Function
    End Class
End Namespace
