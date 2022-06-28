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

	public class CustomersSchema : NCI.EasyObjects.Schema
	{
		private static ArrayList _entries;
		public static SchemaItem CustomerID = new SchemaItem("CustomerID", DbType.StringFixedLength, SchemaItemJustify.None, 5, false, true, true, false);
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

		public override ArrayList SchemaEntries
		{
			get
			{
				if (_entries == null )
				{
					_entries = new ArrayList();
					_entries.Add(CustomersSchema.CustomerID);
					_entries.Add(CustomersSchema.CompanyName);
					_entries.Add(CustomersSchema.ContactName);
					_entries.Add(CustomersSchema.ContactTitle);
					_entries.Add(CustomersSchema.Address);
					_entries.Add(CustomersSchema.City);
					_entries.Add(CustomersSchema.Region);
					_entries.Add(CustomersSchema.PostalCode);
					_entries.Add(CustomersSchema.Country);
					_entries.Add(CustomersSchema.Phone);
					_entries.Add(CustomersSchema.Fax);
				}
				return _entries;
			}
		}
	}
	#endregion

	public abstract class _Customers : EasyObject
	{

		public _Customers()
		{
			CustomersSchema _schema = new CustomersSchema();
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
		/// <param name="CustomerID"></param>
		/// <returns>A Boolean indicating success or failure of the query</returns>
		public bool LoadByPrimaryKey(string CustomerID)
		{
			switch(this.DefaultCommandType)
			{
				case CommandType.StoredProcedure:
					ListDictionary parameters = new ListDictionary();

					// Add in parameters
					parameters.Add(CustomersSchema.CustomerID.FieldName, CustomerID);

					return base.LoadFromSql(this.SchemaStoredProcedureWithSeparator + "daab_GetCustomers", parameters, CommandType.StoredProcedure);

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					this.Where.CustomerID.Value = CustomerID;
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
					return base.LoadFromSql(this.SchemaStoredProcedureWithSeparator + "daab_GetAllCustomers", null, CommandType.StoredProcedure);

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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_AddCustomers";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);

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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_UpdateCustomers";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);

					dbCommandWrapper.AddInParameter("CustomerID", DbType.StringFixedLength, "CustomerID", DataRowVersion.Current);
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
					this.Where.CustomerID.Operator = WhereParameter.Operand.Equal;
					dbCommandWrapper = this.Query.GetUpdateCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					CreateParameters(dbCommandWrapper);
					dbCommandWrapper.AddInParameter("CustomerID", DbType.StringFixedLength, "CustomerID", DataRowVersion.Current);
					
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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_DeleteCustomers";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);
					dbCommandWrapper.AddInParameter("CustomerID", DbType.StringFixedLength, "CustomerID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					this.Where.CustomerID.Operator = WhereParameter.Operand.Equal;
					dbCommandWrapper = this.Query.GetDeleteCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					dbCommandWrapper.AddInParameter("CustomerID", DbType.StringFixedLength, "CustomerID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				default:
					throw new ArgumentException("Invalid CommandType", "commandType");
			}
		}

		private void CreateParameters(DBCommandWrapper dbCommandWrapper)
		{
			dbCommandWrapper.AddInParameter("CustomerID", DbType.StringFixedLength, "CustomerID", DataRowVersion.Current);
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
		}
		
		#region Properties
		public virtual string CustomerID
		{
			get
			{
				return this.GetString(CustomersSchema.CustomerID.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.CustomerID.FieldName, value);
			}
		}
		public virtual string CompanyName
		{
			get
			{
				return this.GetString(CustomersSchema.CompanyName.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.CompanyName.FieldName, value);
			}
		}
		public virtual string ContactName
		{
			get
			{
				return this.GetString(CustomersSchema.ContactName.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.ContactName.FieldName, value);
			}
		}
		public virtual string ContactTitle
		{
			get
			{
				return this.GetString(CustomersSchema.ContactTitle.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.ContactTitle.FieldName, value);
			}
		}
		public virtual string Address
		{
			get
			{
				return this.GetString(CustomersSchema.Address.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.Address.FieldName, value);
			}
		}
		public virtual string City
		{
			get
			{
				return this.GetString(CustomersSchema.City.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.City.FieldName, value);
			}
		}
		public virtual string Region
		{
			get
			{
				return this.GetString(CustomersSchema.Region.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.Region.FieldName, value);
			}
		}
		public virtual string PostalCode
		{
			get
			{
				return this.GetString(CustomersSchema.PostalCode.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.PostalCode.FieldName, value);
			}
		}
		public virtual string Country
		{
			get
			{
				return this.GetString(CustomersSchema.Country.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.Country.FieldName, value);
			}
		}
		public virtual string Phone
		{
			get
			{
				return this.GetString(CustomersSchema.Phone.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.Phone.FieldName, value);
			}
		}
		public virtual string Fax
		{
			get
			{
				return this.GetString(CustomersSchema.Fax.FieldName);
	    	}
			set
			{
				this.SetString(CustomersSchema.Fax.FieldName, value);
			}
		}

		public override string TableName
		{
			get { return "Customers"; }
		}
		
		#endregion		
		
		#region String Properties
	
		public virtual string s_CustomerID
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.CustomerID.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.CustomerID.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.CustomerID.FieldName);
				else
					this.CustomerID = base.SetStringAsString(CustomersSchema.CustomerID.FieldName, value);
			}
		}

		public virtual string s_CompanyName
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.CompanyName.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.CompanyName.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.CompanyName.FieldName);
				else
					this.CompanyName = base.SetStringAsString(CustomersSchema.CompanyName.FieldName, value);
			}
		}

		public virtual string s_ContactName
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.ContactName.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.ContactName.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.ContactName.FieldName);
				else
					this.ContactName = base.SetStringAsString(CustomersSchema.ContactName.FieldName, value);
			}
		}

		public virtual string s_ContactTitle
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.ContactTitle.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.ContactTitle.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.ContactTitle.FieldName);
				else
					this.ContactTitle = base.SetStringAsString(CustomersSchema.ContactTitle.FieldName, value);
			}
		}

		public virtual string s_Address
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.Address.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.Address.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.Address.FieldName);
				else
					this.Address = base.SetStringAsString(CustomersSchema.Address.FieldName, value);
			}
		}

		public virtual string s_City
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.City.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.City.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.City.FieldName);
				else
					this.City = base.SetStringAsString(CustomersSchema.City.FieldName, value);
			}
		}

		public virtual string s_Region
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.Region.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.Region.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.Region.FieldName);
				else
					this.Region = base.SetStringAsString(CustomersSchema.Region.FieldName, value);
			}
		}

		public virtual string s_PostalCode
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.PostalCode.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.PostalCode.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.PostalCode.FieldName);
				else
					this.PostalCode = base.SetStringAsString(CustomersSchema.PostalCode.FieldName, value);
			}
		}

		public virtual string s_Country
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.Country.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.Country.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.Country.FieldName);
				else
					this.Country = base.SetStringAsString(CustomersSchema.Country.FieldName, value);
			}
		}

		public virtual string s_Phone
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.Phone.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.Phone.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.Phone.FieldName);
				else
					this.Phone = base.SetStringAsString(CustomersSchema.Phone.FieldName, value);
			}
		}

		public virtual string s_Fax
	    {
			get
	        {
				return this.IsColumnNull(CustomersSchema.Fax.FieldName) ? string.Empty : base.GetStringAsString(CustomersSchema.Fax.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(CustomersSchema.Fax.FieldName);
				else
					this.Fax = base.SetStringAsString(CustomersSchema.Fax.FieldName, value);
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
				
				
				public WhereParameter CustomerID
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.CustomerID);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter CompanyName
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.CompanyName);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter ContactName
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.ContactName);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter ContactTitle
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.ContactTitle);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Address
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.Address);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter City
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.City);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Region
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.Region);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter PostalCode
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.PostalCode);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Country
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.Country);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Phone
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.Phone);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter Fax
				{
					get
					{
							WhereParameter wp = new WhereParameter(CustomersSchema.Fax);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter CustomerID
		    {
				get
		        {
					if(_CustomerID_W == null)
	        	    {
						_CustomerID_W = TearOff.CustomerID;
					}
					return _CustomerID_W;
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

			private WhereParameter _CustomerID_W = null;
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

			public void WhereClauseReset()
			{
				_CustomerID_W = null;
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
				
				
				public AggregateParameter CustomerID
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.CustomerID);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter CompanyName
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.CompanyName);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter ContactName
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.ContactName);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter ContactTitle
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.ContactTitle);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Address
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.Address);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter City
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.City);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Region
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.Region);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter PostalCode
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.PostalCode);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Country
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.Country);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Phone
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.Phone);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter Fax
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(CustomersSchema.Fax);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter CustomerID
		    {
				get
		        {
					if(_CustomerID_W == null)
	        	    {
						_CustomerID_W = TearOff.CustomerID;
					}
					return _CustomerID_W;
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

			private AggregateParameter _CustomerID_W = null;
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

			public void AggregateClauseReset()
			{
				_CustomerID_W = null;
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
