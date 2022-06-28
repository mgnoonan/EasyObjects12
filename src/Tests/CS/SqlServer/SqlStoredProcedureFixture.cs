using System;
using System.Data;
using NUnit.Framework;
using NCI.EasyObjects;

namespace NCI.EasyObjects.Tests.SQL
{
	/// <summary>
	/// Summary description for SqlStoredProcedureFixture.
	/// </summary>
	[TestFixture]
	public class SqlStoredProcedureFixture
	{
		AggregateTest aggTest = new AggregateTest();
		
		[TestFixtureSetUp]
		public void Init()
		{
			aggTest.DatabaseInstanceName = "SQLUnitTests";
			aggTest.DefaultCommandType = CommandType.StoredProcedure;
			UnitTestBase.RefreshDatabase();
		}
	
		[SetUp]
		public void Init2()
		{
			aggTest.FlushData();
		}
	
		[Test]
		public void LoadByPrimaryKey()
		{
			Assert.IsTrue(aggTest.Query.Load());
			int primaryKey = aggTest.ID;
			aggTest.FlushData();

			Assert.IsTrue(aggTest.LoadByPrimaryKey(primaryKey));
			Assert.AreEqual(1, aggTest.RowCount);
		}
	
		[Test]
		public void LoadAll()
		{
			Assert.IsTrue(aggTest.LoadAll());
			Assert.AreEqual(31, aggTest.RowCount);
		}
	
		[Test]
		public void Insert()
		{
			aggTest.AddNew();
			aggTest.s_DepartmentID = "3";
			aggTest.s_FirstName = "John";
			aggTest.s_LastName = "Doe";
			aggTest.s_Age = "30";
			aggTest.s_HireDate = "2000-02-16 00:00:00";
			aggTest.s_Salary = "34.71";
			aggTest.s_IsActive = "true";
			aggTest.Save();
			Assert.IsFalse(aggTest.IsColumnNull(AggregateTestSchema.ID.FieldName));
			Assert.IsFalse(aggTest.IsColumnNull(AggregateTestSchema.Ts.FieldName));

			aggTest.GetChanges();
			Assert.AreEqual(0, aggTest.RowCount);
		}
	
		[Test]
		public void Update()
		{
			Assert.IsTrue(aggTest.LoadAll());

			int primaryKey = aggTest.ID;
			aggTest.s_DepartmentID = "3";
			aggTest.s_FirstName = "John";
			aggTest.s_LastName = "Doe";
			aggTest.s_Age = "30";
			aggTest.s_HireDate = "2000-02-16 00:00:00";
			aggTest.s_Salary = "34.71";
			aggTest.s_IsActive = "true";
			aggTest.Save();
			
			aggTest.LoadByPrimaryKey(primaryKey);
			Assert.AreEqual(1, aggTest.RowCount);
			Assert.AreEqual("John", aggTest.s_FirstName);
		}
	
		[Test]
		public void XDelete()
		{
			Assert.IsTrue(aggTest.LoadAll());
			aggTest.DeleteAll();
			aggTest.Save();

			Assert.IsFalse(aggTest.LoadAll());
		}
		
		[Test]
		[ExpectedException(typeof(System.Data.DBConcurrencyException))]
		public void Concurrency()
		{
			int primaryKey = 1;
			Assert.IsTrue(aggTest.LoadByPrimaryKey(primaryKey));
			aggTest.s_HireDate = "2000-02-16 00:00:00";

			AggregateTest obj = new AggregateTest();
			obj.DefaultCommandType = CommandType.Text;
			Assert.IsTrue(obj.LoadByPrimaryKey(primaryKey));
			obj.HireDate = DateTime.Now;
			obj.Save();

			aggTest.Save();
		}
	
		[Test]
		public void GetScalar()
		{
			object result = aggTest.GetScalarAggregateTest();
			Assert.IsNotNull(result);
			Assert.AreEqual(30, result);
		}
	
		[Test]
		public void GetReader()
		{
			IDataReader result = aggTest.GetReaderAggregateTest();
			Assert.IsNotNull(result);
			Assert.IsFalse(result.RecordsAffected == 0);
			result.Close();
		}
	}
}
