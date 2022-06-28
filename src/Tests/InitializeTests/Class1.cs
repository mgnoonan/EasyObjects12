using System;
using System.Data;
using NCI.EasyObjects;
using NCI.EasyObjects.Tests.SQL;

namespace InitializeTests
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
//				Console.WriteLine ("Refreshing database");
//				UnitTestBase.RefreshDatabase();

//				SqlDynamicSqlFixture obj = new SqlDynamicSqlFixture();
//				obj.Concurrency();
				
				SqlComputedColumnFixture obj = new SqlComputedColumnFixture();
				obj.Init();
				obj.Dynamic3Update();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}

			Console.WriteLine("\n\nPress <ENTER> to continue...");
			Console.ReadLine();
		}
	}
}
