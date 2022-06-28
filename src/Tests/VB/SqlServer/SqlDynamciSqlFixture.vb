Imports System
Imports System.Data
Imports NUnit.Framework
Imports NCI.EasyObjects

Namespace EasyObjects.Tests.SQL

    <TestFixture()> _
    Public Class SqlDynamicSqlFixture
        Dim aggTest As AggregateTest = New AggregateTest

        <TestFixtureSetUp()> _
        Public Sub Init()
            aggTest.DatabaseInstanceName = "SQLUnitTests"
            aggTest.DefaultCommandType = CommandType.Text
            UnitTestBase.RefreshDatabase()
        End Sub

        <SetUp()> _
        Public Sub Init2()
            aggTest.FlushData()
            aggTest.Query.ClearAll()
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

            ' NOTE: Only two rows is in the database because the 
            ' Delete and Insert fixtures run first
            Assert.AreEqual(2, aggTest.RowCount)
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

            aggTest.AddNew()
            aggTest.s_DepartmentID = "3"
            aggTest.s_FirstName = "Matt"
            aggTest.s_LastName = "Noonan"
            aggTest.s_Age = "35"
            aggTest.s_HireDate = "2003-01-01 00:00:00"
            aggTest.s_Salary = "65"
            aggTest.s_IsActive = "true"
            aggTest.Save()
            Assert.IsFalse(aggTest.IsColumnNull(AggregateTestSchema.ID.FieldName))

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
        Public Sub Delete()
            Assert.IsTrue(aggTest.LoadAll())
            aggTest.DeleteAll()
            aggTest.Save()

            Assert.IsFalse(aggTest.LoadAll())
        End Sub
    End Class
End Namespace

'----------------------------------------------------------------
' Converted from C# to VB .NET using CSharpToVBConverter(1.2).
' Developed by: Kamal Patel (http://www.KamalPatel.net) 
'----------------------------------------------------------------
