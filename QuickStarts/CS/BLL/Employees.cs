using System;

namespace EasyObjectsQuickStart.BLL
{
	/// <summary>
	/// Summary description for Employees.
	/// </summary>
	public class Employees : _Employees
	{
		public Employees(string server, bool useIntegratedSecurity, string userID, string password) 
		{
			this.ConnectionServer = server;
			this.UseIntegratedSecurity = useIntegratedSecurity;
			this.ConnectionUserID = userID;
			this.ConnectionPassword = password;
			this.ConnectionDatabase = "Northwind";
		}
	}
}
