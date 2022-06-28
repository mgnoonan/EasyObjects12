Imports System
Imports NUnit.Framework
Imports NCI.EasyObjects

Namespace EasyObjects.Tests.Oracle

	<TestFixture()> _
	Public Class OracleGroupByFixture

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
        Public Sub OneGroupBy()
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Count"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(3, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub TwoGroupBy()
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Count"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddResultColumn(AggregateTestSchema.DEPARTMENTID)
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.DEPARTMENTID)
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(12, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub GroupByWithWhere()
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Count"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddResultColumn(AggregateTestSchema.DEPARTMENTID)
            obj.Where.ISACTIVE.Operator = WhereParameter.Operand.Equal
            obj.Where.ISACTIVE.Value = True
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.DEPARTMENTID)
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(5, obj.RowCount)
        End Sub


        <Test()> _
        Public Sub GroupByWithWhereAndOrderBy()
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Count"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddResultColumn(AggregateTestSchema.DEPARTMENTID)
            obj.Where.ISACTIVE.Operator = WhereParameter.Operand.Equal
            obj.Where.ISACTIVE.Value = True
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.DEPARTMENTID)
            obj.Query.AddOrderBy(AggregateTestSchema.DEPARTMENTID, WhereParameter.Dir.ASC)
            obj.Query.AddOrderBy(AggregateTestSchema.ISACTIVE, WhereParameter.Dir.ASC)
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(5, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub GroupByWithOrderByCountAll()

            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Count"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddResultColumn(AggregateTestSchema.DEPARTMENTID)
            obj.Where.ISACTIVE.Operator = WhereParameter.Operand.Equal
            obj.Where.ISACTIVE.Value = True
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.DEPARTMENTID)
            obj.Query.AddOrderBy(obj.Query, WhereParameter.Dir.DESC)
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(5, obj.RowCount)
        End Sub

        <Test()> _
          Public Sub GroupByWithTop()

            obj.Query.TopN = 3
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Count"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddResultColumn(AggregateTestSchema.DEPARTMENTID)
            obj.Where.ISACTIVE.Operator = WhereParameter.Operand.Equal
            obj.Where.ISACTIVE.Value = True
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.DEPARTMENTID)
            obj.Query.AddOrderBy(obj.Query, WhereParameter.Dir.DESC)
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(obj.Query.TopN, obj.RowCount)
        End Sub

        <Test()> _
          Public Sub GroupByWithDistinct()

            obj.Query.Distinct = True
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Count"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddResultColumn(AggregateTestSchema.DEPARTMENTID)
            obj.Where.ISACTIVE.Operator = WhereParameter.Operand.Equal
            obj.Where.ISACTIVE.Value = True
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.DEPARTMENTID)
            obj.Query.AddOrderBy(obj.Query, WhereParameter.Dir.DESC)
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(5, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub GroupByWithTearoff()
            obj.Aggregate.SALARY.Function = AggregateParameter.Func.Sum
            obj.Aggregate.SALARY.Alias = "Sum"
            Dim ap As AggregateParameter = obj.Aggregate.TearOff.SALARY
            ap.Function = AggregateParameter.Func.Min
            ap.Alias = "Min"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddResultColumn(AggregateTestSchema.DEPARTMENTID)
            obj.Where.ISACTIVE.Operator = WhereParameter.Operand.Equal
            obj.Where.ISACTIVE.Value = True
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.DEPARTMENTID)
            obj.Query.AddOrderBy(obj.Query, WhereParameter.Dir.DESC)
            Assert.IsTrue(obj.Query.Load())
            Assert.AreEqual(5, obj.RowCount)
        End Sub

        <Test()> _
        Public Sub GroupByWithRollup()
            obj.Query.WithRollup = True
            obj.Query.CountAll = True
            obj.Query.CountAllAlias = "Count"
            obj.Query.AddResultColumn(AggregateTestSchema.ISACTIVE)
            obj.Query.AddResultColumn(AggregateTestSchema.DEPARTMENTID)
            obj.Query.AddGroupBy(AggregateTestSchema.ISACTIVE)
            obj.Query.AddGroupBy(AggregateTestSchema.DEPARTMENTID)
            obj.Query.AddOrderBy(obj.Query, WhereParameter.Dir.DESC)
            obj.Query.Load()
        End Sub

    End Class

End Namespace
