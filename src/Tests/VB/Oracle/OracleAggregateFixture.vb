Imports System
Imports System.Data
Imports NUnit.Framework
Imports NCI.EasyObjects

Namespace EasyObjects.Tests.Oracle

    <TestFixture()> _
     Public Class OracleAggregateFixture

        Dim obj As AggregateTest = New AggregateTest

        <TestFixtureSetUp()> _
        Public Sub Init()
            TransactionManager.ThreadTransactionMgrReset()
            obj.DatabaseInstanceName = "OracleUnitTests"
            obj.DynamicQueryInstanceName = "Default Oracle"

            UnitTestBase.RefreshDatabase()
        End Sub

        <SetUp()> _
        Public Sub Init2()
            obj.FlushData()
        End Sub

        <Test()> _
        Public Sub EmptyQueryReturnsSELLECTAll()
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(30, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateAvg()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Avg
            obj.Aggregate.SALARY.Alias = "Avg"
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateCount()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Count
            obj.Aggregate.SALARY.Alias = "Count"
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateMin()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Min
            obj.Aggregate.SALARY.Alias = "Min"
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateMax()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Max
            obj.Aggregate.SALARY.Alias = "Max"
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateSum()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Sum
            obj.Aggregate.SALARY.Alias = "Sum"
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateStdDev()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.StdDev
            obj.Aggregate.SALARY.Alias = "Std Dev"
            obj.Query.Load()
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateVar()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Var
            obj.Aggregate.SALARY.Alias = "Var"
            obj.Query.Load()
        End Sub

        <Test()> _
        Public Sub AddAggregateCountAll()
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Total"
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AddTwoAggregates()
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Total"
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Sum
            obj.Aggregate.SALARY.Alias = "Sum"
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AggregateWithTearoff()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Sum
            obj.Aggregate.SALARY.Alias = "Sum"
            Dim ap As AggregateParameter = obj.Aggregate.TearOff.SALARY
            ap.Function = AggregateParameter.Func.Min
            ap.Alias = "Min"
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub AggregateWithWhere()
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Total"
            obj.Where.ISACTIVE.Operator = WhereParameter.Operand.Equal
            obj.Where.ISACTIVE.Value = True
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(1, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub EmptyAliasUsesColumnName()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Sum
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual("SALARY", obj.Aggregate.SALARY.Alias)
        End Sub

        <Test()> _
        Public Sub DistinctAggregate()
            obj.Aggregate.LASTNAME.Function = AggregateParameter.Func.Count
            obj.Aggregate.LASTNAME.Distinct = True
            Assert.IsTrue(obj.Query.Load())
            Dim testTable As DataTable = obj.DefaultView.Table
            Dim currRows As DataRow() = testTable.Select("", "", DataViewRowState.CurrentRows)
            Dim testRow As DataRow = currRows(0)
            Assert.AreEqual(10, testRow(0))
        End Sub

    End Class

End Namespace
