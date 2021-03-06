Imports System
Imports System.Data
Imports NUnit.Framework
Imports NCI.EasyObjects

Namespace EasyObjects.Tests.SQL

    <TestFixture()> _
    Public Class SqlStoredProcedureFixture
        Dim aggTest As AggregateTest = New AggregateTest

        <TestFixtureSetUp()> _
        Public Sub Init()
            aggTest.DatabaseInstanceName = "SQLUnitTests"
            aggTest.DefaultCommandType = CommandType.StoredProcedure
            UnitTestBase.RefreshDatabase()
        End Sub

        <SetUp()> _
        Public Sub Init2()
            aggTest.FlushData()
        End Sub

        <Test()> _
        Public Sub LoadByPrimaryKey()
            Assert.IsTrue(aggTest.Query.Load())
            Dim primaryKey As Integer = aggTest.ID
            aggTest.FlushData()

            Assert.IsTrue(aggTest.LoadByPrimaryKey(primaryKey))
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub LoadAll()
            Assert.IsTrue(aggTest.LoadAll())
            Assert.AreEqual(31, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub Insert()
            aggTest.AddNew()
            aggTest.s_DepartmentID = "3"
            aggTest.s_FirstName = "John"
            aggTest.s_LastName = "Doe"
            aggTest.s_Age = "30"
            aggTest.s_HireDate = "2000-02-16 00:00:00"
            aggTest.s_Salary = "34.71"
            aggTest.s_IsActive = "true"
            aggTest.Save()
            Assert.IsFalse(aggTest.IsColumnNull(AggregateTestSchema.ID.FieldName))
            Assert.IsFalse(aggTest.IsColumnNull(AggregateTestSchema.Ts.FieldName))

            aggTest.GetChanges()
            Assert.AreEqual(0, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub Update()
            Assert.IsTrue(aggTest.LoadAll())

            Dim primaryKey As Integer = aggTest.ID
            aggTest.s_DepartmentID = "3"
            aggTest.s_FirstName = "John"
            aggTest.s_LastName = "Doe"
            aggTest.s_Age = "30"
            aggTest.s_HireDate = "2000-02-16 00:00:00"
            aggTest.s_Salary = "34.71"
            aggTest.s_IsActive = "true"
            aggTest.Save()

            aggTest.LoadByPrimaryKey(primaryKey)
            Assert.AreEqual(1, aggTest.RowCount)
            Assert.AreEqual("John", aggTest.s_FirstName)
        End Sub

        <Test()> _
        Public Sub XDelete()
            Assert.IsTrue(aggTest.LoadAll())
            aggTest.DeleteAll()
            aggTest.Save()

            Assert.IsFalse(aggTest.LoadAll())
        End Sub

        <Test(), ExpectedException(GetType(System.Data.SqlClient.SqlException))> _
        Public Sub Concurrency()

            Dim primaryKey As Integer = 1
            Assert.IsTrue(aggTest.LoadByPrimaryKey(primaryKey))
            aggTest.s_HireDate = "2000-02-16 00:00:00"

            Dim obj As AggregateTest = New AggregateTest
            obj.DefaultCommandType = CommandType.Text
            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey))
            obj.HireDate = DateTime.Now
            obj.Save()

            aggTest.Save()
        End Sub

        <Test()> _
        Public Sub GetScalar()
            Dim result As Object = aggTest.GetScalarAggregateTest()
            Assert.IsNotNull(result)
            Assert.AreEqual(30, result)
        End Sub

        <Test()> _
        Public Sub GetReader()
            Dim result As IDataReader = aggTest.GetReaderAggregateTest()
            Assert.IsNotNull(result)
            Assert.IsFalse(result.RecordsAffected = 0)
            result.Close()
        End Sub
    End Class
End Namespace
