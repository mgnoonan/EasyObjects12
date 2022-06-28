Imports System
Imports System.Data
Imports NUnit.Framework
Imports NCI.EasyObjects

Namespace EasyObjects.Tests.Oracle
    <TestFixture()> _
    Public Class OracleStringKeyFixture
        Dim obj As Customers = New Customers
        Dim primaryKey As String = "EZOBJ"

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

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey))
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub Proc1Insert()
            obj.DefaultCommandType = CommandType.StoredProcedure

            obj.AddNew()
            obj.s_CUSTOMERID = primaryKey
            obj.s_COMPANYNAME = "Noonan Consulting Inc."
            obj.s_CONTACTNAME = "Matthew Noonan"
            obj.s_CONTACTTITLE = "President"
            obj.s_CITY = "Springboro"
            obj.s_REGION = "OH"
            obj.s_POSTALCODE = "45066"
            obj.s_COUNTRY = "USA"
            obj.Save()

            obj.GetChanges()
            Assert.AreEqual(0, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub Proc3Update()
            obj.DefaultCommandType = CommandType.StoredProcedure

            Assert.IsTrue(obj.LoadAll())
            Assert.AreEqual(1, obj.RowCount)

            obj.s_POSTALCODE = "45387"
            obj.Save()

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey))
            Assert.AreEqual(1, obj.RowCount)
            Assert.AreEqual("45387", obj.s_POSTALCODE)
        End Sub

        <Test()> _
        Public Sub Proc4Delete()
            obj.DefaultCommandType = CommandType.StoredProcedure

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey))
            obj.DeleteAll()
            obj.Save()

            Assert.IsFalse(obj.LoadByPrimaryKey(primaryKey))
        End Sub

        <Test()> _
        Public Sub Dynamic2LoadByPrimaryKey()
            obj.DefaultCommandType = CommandType.Text

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey))
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub Dynamic1Insert()
            obj.DefaultCommandType = CommandType.Text

            obj.AddNew()
            obj.s_CUSTOMERID = primaryKey
            obj.s_COMPANYNAME = "Noonan Consulting Inc."
            obj.s_CONTACTNAME = "Matthew Noonan"
            obj.s_CONTACTTITLE = "President"
            obj.s_CITY = "Springboro"
            obj.s_REGION = "OH"
            obj.s_POSTALCODE = "45066"
            obj.s_COUNTRY = "USA"
            obj.Save()

            obj.GetChanges()
            Assert.AreEqual(0, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub Dynamic3Update()
            obj.DefaultCommandType = CommandType.Text

            Assert.IsTrue(obj.LoadAll())
            Assert.AreEqual(1, obj.RowCount)

            obj.s_POSTALCODE = "45387"
            obj.Save()

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey))
            Assert.AreEqual(1, obj.RowCount)
            Assert.AreEqual("45387", obj.s_POSTALCODE)
        End Sub

        <Test()> _
        Public Sub Dynamic4Delete()
            obj.DefaultCommandType = CommandType.Text

            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey))
            obj.DeleteAll()
            obj.Save()

            Assert.IsFalse(obj.LoadByPrimaryKey(primaryKey))
        End Sub
    End Class
End Namespace
