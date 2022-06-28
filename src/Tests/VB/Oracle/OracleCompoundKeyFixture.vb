Imports System
Imports System.Data
Imports NUnit.Framework
Imports NCI.EasyObjects

Namespace EasyObjects.Tests.Oracle
    <TestFixture()> _
    Public Class OracleCompoundKeyFixture
        Dim obj As Oracle.EmployeeDeptHist = New Oracle.EmployeeDeptHist
        Dim primaryKey1 As Integer = 1
        Dim primaryKey2 As Short = 1

        <TestFixtureSetUp()> _
        Public Sub Init()
            obj.DatabaseInstanceName = "OracleUnitTests"
            obj.DynamicQueryInstanceName = "Default Oracle"
        End Sub

        <SetUp()> _
        Public Sub Init2()
            obj.FlushData()
        End Sub

        <Test()> _
        Public Sub Proc2LoadByPrimaryKey()
            obj.DefaultCommandType = CommandType.StoredProcedure

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey1, primaryKey2))
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub Proc1Insert()
            obj.DefaultCommandType = CommandType.StoredProcedure

            obj.AddNew()
            obj.EMPLOYEEID = primaryKey1
            obj.DEPARTMENTID = primaryKey2
            obj.s_STARTDATE = "01/01/2000"
            obj.MODIFIEDDATE = DateTime.Now
            obj.Save()

            obj.GetChanges()
            Assert.AreEqual(0, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub Proc3Update()
            obj.DefaultCommandType = CommandType.StoredProcedure

            Assert.IsTrue(obj.LoadAll())
            Assert.AreEqual(1, obj.RowCount)

            obj.s_ENDDATE = "12/31/2001"
            obj.Save()

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey1, primaryKey2))
            Assert.AreEqual(1, obj.RowCount)
            Assert.AreEqual("12/31/2001", obj.s_ENDDATE)
        End Sub

        <Test()> _
        Public Sub Proc4Delete()
            obj.DefaultCommandType = CommandType.StoredProcedure

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey1, primaryKey2))
            obj.DeleteAll()
            obj.Save()

            Assert.IsFalse(obj.LoadByPrimaryKey(primaryKey1, primaryKey2))
        End Sub

        <Test()> _
        Public Sub Dynamic2LoadByPrimaryKey()
            obj.DefaultCommandType = CommandType.Text

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey1, primaryKey2))
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub Dynamic1Insert()
            obj.DefaultCommandType = CommandType.Text

            obj.AddNew()
            obj.EMPLOYEEID = primaryKey1
            obj.DEPARTMENTID = primaryKey2
            obj.s_STARTDATE = "01/01/2000"
            obj.MODIFIEDDATE = DateTime.Now
            obj.Save()

            obj.GetChanges()
            Assert.AreEqual(0, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub Dynamic3Update()
            obj.DefaultCommandType = CommandType.Text

            Assert.IsTrue(obj.LoadAll())
            Assert.AreEqual(1, obj.RowCount)

            obj.s_ENDDATE = "12/31/2001"
            obj.Save()

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey1, primaryKey2))
            Assert.AreEqual(1, obj.RowCount)
            Assert.AreEqual("12/31/2001", obj.s_ENDDATE)
        End Sub

        <Test()> _
        Public Sub Dynamic4Delete()
            obj.DefaultCommandType = CommandType.Text

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey1, primaryKey2))
            obj.DeleteAll()
            obj.Save()

            Assert.IsFalse(obj.LoadByPrimaryKey(primaryKey1, primaryKey2))
        End Sub
    End Class
End Namespace
