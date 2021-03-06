Imports System
Imports NUnit.Framework
Imports NCI.EasyObjects

NameSpace EasyObjects.Tests.SQL

	<TestFixture()> _
	 Public Class SQLViewAggregateFixture

		Dim aggTest As FullNameView = New FullNameView

		<TestFixtureSetUp()> _
		Public Sub Init()
            aggTest.DatabaseInstanceName = "SQLUnitTests"
            UnitTestBase.RefreshDatabase()
        End Sub

        <SetUp()> _
        Public Sub Init2()
            aggTest.FlushData()
        End Sub

        <Test()> _
        Public Sub EmptyQueryReturnsSELLECTAll()
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(16, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateAvg()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Avg
            aggTest.Aggregate.Salary.Alias = "Avg"
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateCount()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Count
            aggTest.Aggregate.Salary.Alias = "Count"
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateMin()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Min
            aggTest.Aggregate.Salary.Alias = "Min"
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateMax()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Max
            aggTest.Aggregate.Salary.Alias = "Max"
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateSum()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Sum
            aggTest.Aggregate.Salary.Alias = "Sum"
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AddAggregateStdDev()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.StdDev
            aggTest.Aggregate.Salary.Alias = "Std Dev"
            aggTest.Query.Load()
        End Sub

        <Test()> _
        Public Sub AddAggregateVar()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Var
            aggTest.Aggregate.Salary.Alias = "Var"
            aggTest.Query.Load()
        End Sub

        <Test()> _
        Public Sub AddAggregateCountAll()
            aggTest.Query.CountAll = True
            aggTest.Query.CountAllAlias = "Total"
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AddTwoAggregates()
            aggTest.Query.CountAll = True
            aggTest.Query.CountAllAlias = "Total"
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Sum
            aggTest.Aggregate.Salary.Alias = "Sum"
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AggregateWithTearoff()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Sum
            aggTest.Aggregate.Salary.Alias = "Sum"
            Dim ap As AggregateParameter = aggTest.Aggregate.TearOff.Salary
            ap.Function = AggregateParameter.Func.Min
            ap.Alias = "Min"
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub AggregateWithWhere()
            aggTest.Query.CountAll = True
            aggTest.Query.CountAllAlias = "Total"
            aggTest.Where.IsActive.Operator = WhereParameter.Operand.Equal
            aggTest.Where.IsActive.Value = True
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual(1, aggTest.RowCount)
        End Sub

        <Test()> _
        Public Sub EmptyAliasUsesColumnName()
            aggTest.Aggregate.Salary.Function = AggregateParameter.Func.Sum
            Assert.IsTrue(aggTest.Query.Load())
            Assert.AreEqual("Salary", aggTest.Aggregate.Salary.Alias)
        End Sub

    End Class

End Namespace
