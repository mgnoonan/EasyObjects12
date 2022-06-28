Imports System
Imports System.Data
Imports NUnit.Framework
Imports NCI.EasyObjects
 
Namespace EasyObjects.Tests.Oracle
	<TestFixture> _ 
	Public Class OracleDynamicSqlFixture
		Dim aggTest As Oracle.AggregateTest =  New Oracle.AggregateTest() 
 
		<TestFixtureSetUp> _ 
		Public  Sub Init()
			aggTest.DatabaseInstanceName = "OracleUnitTests"
			aggTest.DynamicQueryInstanceName = "Default Oracle"
			aggTest.DefaultCommandType = CommandType.Text
			UnitTestBase.RefreshDatabase()
		End Sub
 
		<SetUp> _ 
		Public  Sub Init2()
			aggTest.FlushData()
			aggTest.Query.ClearAll()
		End Sub
 
		<Test> _ 
		Public  Sub LoadByPrimaryKey()
			Assert.IsTrue(aggTest.Query.Load())
			Dim primaryKey As Decimal =  aggTest.ID 
			aggTest.FlushData()
 
			Assert.IsTrue(aggTest.LoadByPrimaryKey(primaryKey))
			Assert.AreEqual(1, aggTest.RowCount)
		End Sub
 
		<Test> _ 
		Public  Sub LoadAll()
			Assert.IsTrue(aggTest.LoadAll())
 
			' NOTE: Only one row is in the database because the 
			' Delete and Insert fixtures run first
			Assert.AreEqual(32, aggTest.RowCount)
		End Sub
 
		<Test> _ 
		Public  Sub Insert()
			aggTest.AddNew()
			aggTest.s_DEPARTMENTID = "3"
			aggTest.s_FIRSTNAME = "John"
			aggTest.s_LASTNAME = "Doe"
			aggTest.s_AGE = "16"
			aggTest.s_HIREDATE = "2000-02-16 00:00:00"
			aggTest.s_SALARY = "34.71"
			aggTest.s_ISACTIVE = "1"
			aggTest.Save()
			Assert.IsFalse(aggTest.IsColumnNull(AggregateTestSchema.ID.FieldName))
 
			aggTest.GetChanges()
			Assert.AreEqual(0, aggTest.RowCount)
		End Sub
 
		<Test> _ 
		Public  Sub InsertIdentity()
			aggTest.AddNew()
			aggTest.IdentityInsert = True
			aggTest.s_ID = "31"
			aggTest.s_DEPARTMENTID = "3"
			aggTest.s_FIRSTNAME = "John"
			aggTest.s_LASTNAME = "Doe"
			aggTest.s_AGE = "16"
			aggTest.s_HIREDATE = "2000-02-16 00:00:00"
			aggTest.s_SALARY = "34.71"
			aggTest.s_ISACTIVE = "1"
			aggTest.Save()
			Assert.AreEqual(aggTest.ErrorMessage, String.Empty)
            Assert.IsFalse(aggTest.IsColumnNull(AggregateTestSchema.TS.FieldName))
 
			aggTest.GetChanges()
			Assert.AreEqual(0, aggTest.RowCount)
		End Sub
 
		<Test> _ 
		Public  Sub Update()
			Assert.IsTrue(aggTest.LoadAll())
 
			Dim primaryKey As Decimal =  aggTest.ID 
			aggTest.s_DEPARTMENTID = "3"
			aggTest.s_FIRSTNAME = "John"
			aggTest.s_LASTNAME = "Doe"
			aggTest.s_AGE = "16"
			aggTest.s_HIREDATE = "2000-02-16 00:00:00"
			aggTest.s_SALARY = "34.71"
			aggTest.s_ISACTIVE = "1"
			aggTest.Save()
 
			aggTest.LoadByPrimaryKey(primaryKey)
			Assert.AreEqual(1, aggTest.RowCount)
			Assert.AreEqual("John", aggTest.s_FIRSTNAME)
		End Sub
 
		<Test> _ 
		Public  Sub XDelete()
			Assert.IsTrue(aggTest.LoadAll())
			aggTest.DeleteAll()
			aggTest.Save()
 
			Assert.IsFalse(aggTest.LoadAll())
		End Sub
 
        <Test(), ExpectedException(GetType(System.Data.OracleClient.OracleException))> _
        Public Sub Concurrency()
            Dim primaryKey As Integer = 1
            Assert.IsTrue(aggTest.LoadByPrimaryKey(primaryKey))
            aggTest.s_HIREDATE = "2000-02-16 00:00:00"

            Dim obj As AggregateTest = New AggregateTest
            obj.DatabaseInstanceName = "OracleUnitTests"
            obj.DynamicQueryInstanceName = "Default Oracle"
            obj.DefaultCommandType = CommandType.Text
            Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey))
            obj.HIREDATE = DateTime.Now
            obj.Save()

            aggTest.Save()
        End Sub
    End Class
End Namespace
