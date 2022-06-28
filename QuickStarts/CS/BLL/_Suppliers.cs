/*
'===============================================================================
'  Generated From - CSharp_EasyObject_BusinessEntity.vbgen
' 
'  ** IMPORTANT  ** 
'  How to Generate your stored procedures:
' 
'  SQL      = SQL_DAAB_StoredProcs.vbgen
'  
'  This object is 'abstract' which means you need to inherit from it to be able
'  to instantiate it.  This is very easily done. You can override properties and
'  methods in your derived class, this allows you to regenerate this class at any
'  time and not worry about overwriting custom code. 
'
'  NEVER EDIT THIS FILE.
'
'  public class YourObject :  _YourObject
'  {
'
'  }
'
'===============================================================================
*/

// Generated by MyGeneration Version # (1.1.4.0)

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using System.IO;

using Microsoft.Practices.EnterpriseLibrary.Data;
using NCI.EasyObjects;

namespace EasyObjectsQuickStart.BLL
{

	#region Schema

	public class SuppliersSchema : NCI.EasyObjects.Schema
	{
		private static ArrayList _entries;
		public static SchemaItem SupplierID = new SchemaItem("SupplierID", DbType.Int32, true, false, false, true, true, false);
		public static SchemaItem CompanyName = new SchemaItem("CompanyName", DbType.String, SchemaItemJustify.None, 40, false, false, false, false);
		public static SchemaItem ContactName = new SchemaItem("ContactName", DbType.String, SchemaItemJustify.None, 30, true, false, false, false);
		public static SchemaItem ContactTitle = new SchemaItem("ContactTitle", DbType.String, SchemaItemJustify.None, 30, true, false, false, false);
		public static SchemaItem Address = new SchemaItem("Address", DbType.String, SchemaItemJustify.None, 60, true, false, false, false);
		public static SchemaItem City = new SchemaItem("City", DbType.String, SchemaItemJustify.None, 15, true, false, false, false);
		public static SchemaItem Region = new SchemaItem("Region", DbType.String, SchemaItemJustify.None, 15, true, false, false, false);
		public static SchemaItem PostalCode = new SchemaItem("PostalCode", DbType.String, SchemaItemJustify.None, 10, true, false, false, false);
		public static SchemaItem Country = new SchemaItem("Country", DbType.String, SchemaItemJustify.None, 15, true, false, false, false);
		public static SchemaItem Phone = new SchemaItem("Phone", DbType.String, SchemaItemJustify.None, 24, true, false, false, false);
		public static SchemaItem Fax = new SchemaItem("Fax", DbType.String, SchemaItemJustify.None, 24, true, false, false, false);
		public static SchemaItem HomePage = new SchemaItem("HomePage", DbType.String, SchemaItemJustify.None, 1073741823, true, false, false, false);

		public override ArrayList SchemaEntries
		{
			get
			{
				if (_entries == null )
				{
					_entries = new ArrayList();
					_entries.Add(SuppliersSchema.SupplierID);
					_entries.Add(SuppliersSchema.CompanyName);
					_entries.Add(SuppliersSchema.ContactName);
					_entries.Add(SuppliersSchema.ContactTitle);
					_entries.Add(SuppliersSchema.Address);
					_entries.Add(SuppliersSchema.City);
					_entries.Add(SuppliersSchema.Region);
					_entries.Add(SuppliersSchema.PostalCode);
					_entries.Add(SuppliersSchema.Country);
					_entries.Add(SuppliersSchema.Phone);
					_entries.Add(SuppliersSchema.Fax);
					_entries.Add(SuppliersSchema.HomePage);
				}
				return _entries;
			}
		}
	}
	#endregion

	public abstract class _Suppliers : EasyObject
	{

		public _Suppliers()
		{
			SuppliersSchema _schema = new SuppliersSchema();
			this.SchemaEntries = _schema.SchemaEntries;
			this.SchemaGlobal = "dbo";
		}
		
		public override void FlushData() 	 
		{ 	 
			this._whereClause = null; 	 
			this._aggregateClause = null; 	 
			base.FlushData(); 	 
		}
			   
		/// <summary>
		/// Loads the business object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="SupplierID"></param>
		/// <returns>A Boolean indicating success or failure of the query</returns>
		public bool LoadByPrimaryKey(int SupplierID)
		{
			switch(this.DefaultCommandType)
			{
				case CommandType.StoredProcedure:
					ListDictionary parameters = new ListDictionary();

					// Add in parameters
					parameters.Add(SuppliersSchema.SupplierID.FieldName, SupplierID);

					return base.LoadFromSql(this.SchemaStoredProcedureWithSeparator + "daab_GetSuppliers", parameters, CommandType.StoredProcedure);

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					this.Where.SupplierID.Value = SupplierID;
					return this.Query.Load();

				default:
					throw new ArgumentException("Invalid CommandType", "commandType");
			}
		}
	
		/// <summary>
		/// Loads all records from the table.
		/// </summary>
		/// <returns>A Boolean indicating success or failure of the query</returns>
		public bool LoadAll()
		{
			switch(this.DefaultCommandType)
			{
				case CommandType.StoredProcedure:
					return base.LoadFromSql(this.SchemaStoredProcedureWithSeparator + "daab_GetAllSuppliers", null, CommandType.StoredProcedure);

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					return this.Query.Load();

				default:
					throw new ArgumentException("Invalid CommandType", "commandType");
			}
		}

		/// <summary>
		/// Adds a new record to the internal table.
		/// </summary>
		public override void AddNew()
		{
			base.AddNew();
		}

		protected override DBCommandWrapper GetInsertCommand(CommandType commandType)
		{	
			DBCommandWrapper dbCommandWrapper;

			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = GetDatabase();

			switch(commandType)
			{
				case CommandType.StoredProcedure:
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_AddSuppliers";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);

					dbCommandWrapper.AddParameter("SupplierID", DbType.Int32, 0, ParameterDirection.Output, true, 0, 0, "SupplierID", DataRowVersion.Default, Convert.DBNull);
					CreateParameters(dbCommandWrapper);
					
					return dbCommandWrapper;

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					foreach(SchemaItem item in this.SchemaEntries)
					{
						if (!(item.IsAutoKey || item.IsComputed))
						{
							this.Query.AddInsertColumn(item);
						}
					}
					dbCommandWrapper = this.Query.GetInsertCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					CreateParameters(dbCommandWrapper);
					dbCommandWrapper.AddParameter("SupplierID", DbType.Int32, 0, ParameterDirection.Output, true, 0, 0, "SupplierID", DataRowVersion.Default, Convert.DBNull);
					
					return dbCommandWrapper;

				default:
					throw new ArgumentException("Invalid CommandType", "commandType");
			}
		}

		protected override DBCommandWrapper GetUpdateCommand(CommandType commandType)
		{
			DBCommandWrapper dbCommandWrapper;

			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = GetDatabase();

			switch(commandType)
			{
				case CommandType.StoredProcedure:
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_UpdateSuppliers";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);

					dbCommandWrapper.AddInParameter("SupplierID", DbType.Int32, "SupplierID", DataRowVersion.Current);
					CreateParameters(dbCommandWrapper);
					
					return dbCommandWrapper;

				case CommandType.Text:
					this.Query.ClearAll();
					foreach(SchemaItem item in this.SchemaEntries)
					{
						if (!(item.IsAutoKey || item.IsComputed))
						{
							this.Query.AddUpdateColumn(item);
						}
					}

					this.Where.WhereClauseReset();
					this.Where.SupplierID.Operator = WhereParameter.Operand.Equal;
					dbCommandWrapper = this.Query.GetUpdateCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					CreateParameters(dbCommandWrapper);
					dbCommandWrapper.AddInParameter("SupplierID", DbType.Int32, "SupplierID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				default:
					throw new ArgumentException("Invalid CommandType", "commandType");
			}
		}

		protected override DBCommandWrapper GetDeleteCommand(CommandType commandType)
		{
			DBCommandWrapper dbCommandWrapper;

			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = GetDatabase();

			switch(commandType)
			{
				case CommandType.StoredProcedure:
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_DeleteSuppliers";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);
					dbCommandWrapper.AddInParameter("SupplierID", DbType.Int32, "SupplierID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					this.Where.SupplierID.Operator = WhereParameter.Operand.Equal;
					dbCommandWrapper = this.Query.GetDeleteCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					dbCommandWrapper.AddInParameter("SupplierID", DbType.Int32, "SupplierID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				default:
					throw new ArgumentException("Invalid CommandType", "commandType");
			}
		}

		private void CreateParameters(DBCommandWrapper dbCommandWrapper)
		{
			dbCommandWrapper.AddInParameter("CompanyName", DbType.String, "CompanyName", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("ContactName", DbType.String, "ContactName", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("ContactTitle", DbType.String, "ContactTitle", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("Address", DbType.String, "Address", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("City", DbType.String, "City", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("Region", DbType.String, "Region", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("PostalCode", DbType.String, "PostalCode", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("Country", DbType.String, "Country", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("Phone", DbType.String, "Phone", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("Fax", DbType.String, "Fax", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("HomePage", DbType.String, "HomePage", DataRowVersion.Current);
		}
		
		#region Properties
		public virtual int SupplierID
		{
			get
			{
				return this.GetInteger(SuppliersSchema.SupplierID.FieldName);
	    	}
			set
			{
				this.SetInteger(SuppliersSchema.SupplierID.FieldName, value);
			}
		}
		public virtual string CompanyName
		{
			get
			{
				return this.GetString(SuppliersSchema.CompanyName.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.CompanyName.FieldName, value);
			}
		}
		public virtual string ContactName
		{
			get
			{
				return this.GetString(SuppliersSchema.ContactName.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.ContactName.FieldName, value);
			}
		}
		public virtual string ContactTitle
		{
			get
			{
				return this.GetString(SuppliersSchema.ContactTitle.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.ContactTitle.FieldName, value);
			}
		}
		public virtual string Address
		{
			get
			{
				return this.GetString(SuppliersSchema.Address.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.Address.FieldName, value);
			}
		}
		public virtual string City
		{
			get
			{
				return this.GetString(SuppliersSchema.City.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.City.FieldName, value);
			}
		}
		public virtual string Region
		{
			get
			{
				return this.GetString(SuppliersSchema.Region.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.Region.FieldName, value);
			}
		}
		public virtual string PostalCode
		{
			get
			{
				return this.GetString(SuppliersSchema.PostalCode.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.PostalCode.FieldName, value);
			}
		}
		public virtual string Country
		{
			get
			{
				return this.GetString(SuppliersSchema.Country.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.Country.FieldName, value);
			}
		}
		public virtual string Phone
		{
			get
			{
				return this.GetString(SuppliersSchema.Phone.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.Phone.FieldName, value);
			}
		}
		public virtual string Fax
		{
			get
			{
				return this.GetString(SuppliersSchema.Fax.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.Fax.FieldName, value);
			}
		}
		public virtual string HomePage
		{
			get
			{
				return this.GetString(SuppliersSchema.HomePage.FieldName);
	    	}
			set
			{
				this.SetString(SuppliersSchema.HomePage.FieldName, value);
			}
		}

		public override string TableName
		{
			get { return "Suppliers"; }
		}
		
		#endregion		
		
		#region String Properties
	
		public virtual string s_SupplierID
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.SupplierID.FieldName) ? string.Empty : base.GetIntegerAsString(SuppliersSchema.SupplierID.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.SupplierID.FieldName);
				else
					this.SupplierID = base.SetIntegerAsString(SuppliersSchema.SupplierID.FieldName, value);
			}
		}

		public virtual string s_CompanyName
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.CompanyName.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.CompanyName.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.CompanyName.FieldName);
				else
					this.CompanyName = base.SetStringAsString(SuppliersSchema.CompanyName.FieldName, value);
			}
		}

		public virtual string s_ContactName
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.ContactName.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.ContactName.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.ContactName.FieldName);
				else
					this.ContactName = base.SetStringAsString(SuppliersSchema.ContactName.FieldName, value);
			}
		}

		public virtual string s_ContactTitle
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.ContactTitle.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.ContactTitle.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.ContactTitle.FieldName);
				else
					this.ContactTitle = base.SetStringAsString(SuppliersSchema.ContactTitle.FieldName, value);
			}
		}

		public virtual string s_Address
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.Address.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.Address.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.Address.FieldName);
				else
					this.Address = base.SetStringAsString(SuppliersSchema.Address.FieldName, value);
			}
		}

		public virtual string s_City
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.City.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.City.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.City.FieldName);
				else
					this.City = base.SetStringAsString(SuppliersSchema.City.FieldName, value);
			}
		}

		public virtual string s_Region
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.Region.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.Region.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.Region.FieldName);
				else
					this.Region = base.SetStringAsString(SuppliersSchema.Region.FieldName, value);
			}
		}

		public virtual string s_PostalCode
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.PostalCode.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.PostalCode.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.PostalCode.FieldName);
				else
					this.PostalCode = base.SetStringAsString(SuppliersSchema.PostalCode.FieldName, value);
			}
		}

		public virtual string s_Country
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.Country.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.Country.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.Country.FieldName);
				else
					this.Country = base.SetStringAsString(SuppliersSchema.Country.FieldName, value);
			}
		}

		public virtual string s_Phone
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.Phone.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.Phone.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.Phone.FieldName);
				else
					this.Phone = base.SetStringAsString(SuppliersSchema.Phone.FieldName, value);
			}
		}

		public virtual string s_Fax
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.Fax.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.Fax.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.Fax.FieldName);
				else
					this.Fax = base.SetStringAsString(SuppliersSchema.Fax.FieldName, value);
			}
		}

		public virtual string s_HomePage
	    {
			get
	        {
				return this.IsColumnNull(SuppliersSchema.HomePage.FieldName) ? string.Empty : base.GetStringAsString(SuppliersSchema.HomePage.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(SuppliersSchema.HomePage.FieldName);
				else
					this.HomePage = base.SetStringAsString(SuppliersSchema.HomePage.FieldName, value);
			}
		}


		#endregion		
	
		#region Where Clause
		public class WhereClause
		{
			public WhereClause(EasyObject entity)
			{
				this._entity = entity;
			}
			
			public TearOffWhereParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffWhereParameter(this);
					}

					return _tearOff;
				}
			}

			#region TearOff's
			public class TearOffWhereParameter
			{
				public TearOffWhereParameter(WhereClause clause)
				{
					this._clause = clause;
				}
				
				
				public WhereParameter SupplierID
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.SupplierID);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter CompanyName
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.CompanyName);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter ContactName
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.ContactName);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter ContactTitle
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.ContactTitle);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Address
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.Address);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter City
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.City);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Region
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.Region);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter PostalCode
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.PostalCode);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Country
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.Country);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Phone
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.Phone);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Fax
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.Fax);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter HomePage
				{
					get
					{
							WhereParameter wp = new WhereParameter(SuppliersSchema.HomePage);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter SupplierID
		    {
				get
		        {
					if(_SupplierID_W == null)
	        	    {
						_SupplierID_W = TearOff.SupplierID;
					}
					return _SupplierID_W;
				}
			}

			public WhereParameter CompanyName
		    {
				get
		        {
					if(_CompanyName_W == null)
	        	    {
						_CompanyName_W = TearOff.CompanyName;
					}
					return _CompanyName_W;
				}
			}

			public WhereParameter ContactName
		    {
				get
		        {
					if(_ContactName_W == null)
	        	    {
						_ContactName_W = TearOff.ContactName;
					}
					return _ContactName_W;
				}
			}

			public WhereParameter ContactTitle
		    {
				get
		        {
					if(_ContactTitle_W == null)
	        	    {
						_ContactTitle_W = TearOff.ContactTitle;
					}
					return _ContactTitle_W;
				}
			}

			public WhereParameter Address
		    {
				get
		        {
					if(_Address_W == null)
	        	    {
						_Address_W = TearOff.Address;
					}
					return _Address_W;
				}
			}

			public WhereParameter City
		    {
				get
		        {
					if(_City_W == null)
	        	    {
						_City_W = TearOff.City;
					}
					return _City_W;
				}
			}

			public WhereParameter Region
		    {
				get
		        {
					if(_Region_W == null)
	        	    {
						_Region_W = TearOff.Region;
					}
					return _Region_W;
				}
			}

			public WhereParameter PostalCode
		    {
				get
		        {
					if(_PostalCode_W == null)
	        	    {
						_PostalCode_W = TearOff.PostalCode;
					}
					return _PostalCode_W;
				}
			}

			public WhereParameter Country
		    {
				get
		        {
					if(_Country_W == null)
	        	    {
						_Country_W = TearOff.Country;
					}
					return _Country_W;
				}
			}

			public WhereParameter Phone
		    {
				get
		        {
					if(_Phone_W == null)
	        	    {
						_Phone_W = TearOff.Phone;
					}
					return _Phone_W;
				}
			}

			public WhereParameter Fax
		    {
				get
		        {
					if(_Fax_W == null)
	        	    {
						_Fax_W = TearOff.Fax;
					}
					return _Fax_W;
				}
			}

			public WhereParameter HomePage
		    {
				get
		        {
					if(_HomePage_W == null)
	        	    {
						_HomePage_W = TearOff.HomePage;
					}
					return _HomePage_W;
				}
			}

			private WhereParameter _SupplierID_W = null;
			private WhereParameter _CompanyName_W = null;
			private WhereParameter _ContactName_W = null;
			private WhereParameter _ContactTitle_W = null;
			private WhereParameter _Address_W = null;
			private WhereParameter _City_W = null;
			private WhereParameter _Region_W = null;
			private WhereParameter _PostalCode_W = null;
			private WhereParameter _Country_W = null;
			private WhereParameter _Phone_W = null;
			private WhereParameter _Fax_W = null;
			private WhereParameter _HomePage_W = null;

			public void WhereClauseReset()
			{
				_SupplierID_W = null;
				_CompanyName_W = null;
				_ContactName_W = null;
				_ContactTitle_W = null;
				_Address_W = null;
				_City_W = null;
				_Region_W = null;
				_PostalCode_W = null;
				_Country_W = null;
				_Phone_W = null;
				_Fax_W = null;
				_HomePage_W = null;

				this._entity.Query.FlushWhereParameters();

			}
	
			private EasyObject _entity;
			private TearOffWhereParameter _tearOff;
			
		}
	
		public WhereClause Where
		{
			get
			{
				if(_whereClause == null)
				{
					_whereClause = new WhereClause(this);
				}
		
				return _whereClause;
			}
		}
		
		private WhereClause _whereClause = null;	
		#endregion
		
		#region Aggregate Clause
		public class AggregateClause
		{
			public AggregateClause(EasyObject entity)
			{
				this._entity = entity;
			}
			
			public TearOffAggregateParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffAggregateParameter(this);
					}

					return _tearOff;
				}
			}

			#region TearOff's
			public class TearOffAggregateParameter
			{
				public TearOffAggregateParameter(AggregateClause clause)
				{
					this._clause = clause;
				}
				
				
				public AggregateParameter SupplierID
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.SupplierID);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter CompanyName
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.CompanyName);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter ContactName
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.ContactName);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter ContactTitle
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.ContactTitle);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Address
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.Address);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter City
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.City);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Region
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.Region);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter PostalCode
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.PostalCode);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Country
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.Country);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Phone
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.Phone);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Fax
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.Fax);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter HomePage
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(SuppliersSchema.HomePage);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter SupplierID
		    {
				get
		        {
					if(_SupplierID_W == null)
	        	    {
						_SupplierID_W = TearOff.SupplierID;
					}
					return _SupplierID_W;
				}
			}

			public AggregateParameter CompanyName
		    {
				get
		        {
					if(_CompanyName_W == null)
	        	    {
						_CompanyName_W = TearOff.CompanyName;
					}
					return _CompanyName_W;
				}
			}

			public AggregateParameter ContactName
		    {
				get
		        {
					if(_ContactName_W == null)
	        	    {
						_ContactName_W = TearOff.ContactName;
					}
					return _ContactName_W;
				}
			}

			public AggregateParameter ContactTitle
		    {
				get
		        {
					if(_ContactTitle_W == null)
	        	    {
						_ContactTitle_W = TearOff.ContactTitle;
					}
					return _ContactTitle_W;
				}
			}

			public AggregateParameter Address
		    {
				get
		        {
					if(_Address_W == null)
	        	    {
						_Address_W = TearOff.Address;
					}
					return _Address_W;
				}
			}

			public AggregateParameter City
		    {
				get
		        {
					if(_City_W == null)
	        	    {
						_City_W = TearOff.City;
					}
					return _City_W;
				}
			}

			public AggregateParameter Region
		    {
				get
		        {
					if(_Region_W == null)
	        	    {
						_Region_W = TearOff.Region;
					}
					return _Region_W;
				}
			}

			public AggregateParameter PostalCode
		    {
				get
		        {
					if(_PostalCode_W == null)
	        	    {
						_PostalCode_W = TearOff.PostalCode;
					}
					return _PostalCode_W;
				}
			}

			public AggregateParameter Country
		    {
				get
		        {
					if(_Country_W == null)
	        	    {
						_Country_W = TearOff.Country;
					}
					return _Country_W;
				}
			}

			public AggregateParameter Phone
		    {
				get
		        {
					if(_Phone_W == null)
	        	    {
						_Phone_W = TearOff.Phone;
					}
					return _Phone_W;
				}
			}

			public AggregateParameter Fax
		    {
				get
		        {
					if(_Fax_W == null)
	        	    {
						_Fax_W = TearOff.Fax;
					}
					return _Fax_W;
				}
			}

			public AggregateParameter HomePage
		    {
				get
		        {
					if(_HomePage_W == null)
	        	    {
						_HomePage_W = TearOff.HomePage;
					}
					return _HomePage_W;
				}
			}

			private AggregateParameter _SupplierID_W = null;
			private AggregateParameter _CompanyName_W = null;
			private AggregateParameter _ContactName_W = null;
			private AggregateParameter _ContactTitle_W = null;
			private AggregateParameter _Address_W = null;
			private AggregateParameter _City_W = null;
			private AggregateParameter _Region_W = null;
			private AggregateParameter _PostalCode_W = null;
			private AggregateParameter _Country_W = null;
			private AggregateParameter _Phone_W = null;
			private AggregateParameter _Fax_W = null;
			private AggregateParameter _HomePage_W = null;

			public void AggregateClauseReset()
			{
				_SupplierID_W = null;
				_CompanyName_W = null;
				_ContactName_W = null;
				_ContactTitle_W = null;
				_Address_W = null;
				_City_W = null;
				_Region_W = null;
				_PostalCode_W = null;
				_Country_W = null;
				_Phone_W = null;
				_Fax_W = null;
				_HomePage_W = null;

				this._entity.Query.FlushAggregateParameters();

			}
	
			private EasyObject _entity;
			private TearOffAggregateParameter _tearOff;
			
		}
	
		public AggregateClause Aggregate
		{
			get
			{
				if(_aggregateClause == null)
				{
					_aggregateClause = new AggregateClause(this);
				}
		
				return _aggregateClause;
			}
		}
		
		private AggregateClause _aggregateClause = null;	
		#endregion
	}
}
