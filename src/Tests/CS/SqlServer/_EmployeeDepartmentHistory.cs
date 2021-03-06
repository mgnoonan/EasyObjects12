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

// Generated by MyGeneration Version # (1.1.6.0)

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using System.IO;

using Microsoft.Practices.EnterpriseLibrary.Data;
using NCI.EasyObjects;

namespace NCI.EasyObjects.Tests.SQL
{

	#region Schema

	public class EmployeeDepartmentHistorySchema : NCI.EasyObjects.Schema
	{
		private static ArrayList _entries;
		public static SchemaItem EmployeeID = new SchemaItem("EmployeeID", DbType.Int32, false, false, false, true, false, false);
		public static SchemaItem DepartmentID = new SchemaItem("DepartmentID", DbType.Int16, false, false, false, true, false, false);
		public static SchemaItem StartDate = new SchemaItem("StartDate", DbType.DateTime, false, false, false, false, false, false);
		public static SchemaItem EndDate = new SchemaItem("EndDate", DbType.DateTime, false, true, false, false, false, false);
		public static SchemaItem ModifiedDate = new SchemaItem("ModifiedDate", DbType.DateTime, false, false, false, false, false, true);

		public override ArrayList SchemaEntries
		{
			get
			{
				if (_entries == null )
				{
					_entries = new ArrayList();
					_entries.Add(EmployeeDepartmentHistorySchema.EmployeeID);
					_entries.Add(EmployeeDepartmentHistorySchema.DepartmentID);
					_entries.Add(EmployeeDepartmentHistorySchema.StartDate);
					_entries.Add(EmployeeDepartmentHistorySchema.EndDate);
					_entries.Add(EmployeeDepartmentHistorySchema.ModifiedDate);
				}
				return _entries;
			}
		}
	}
	#endregion

	public abstract class _EmployeeDepartmentHistory : EasyObject
	{

		public _EmployeeDepartmentHistory()
		{
			EmployeeDepartmentHistorySchema _schema = new EmployeeDepartmentHistorySchema();
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
		/// <param name="EmployeeID"></param>
		/// <param name="DepartmentID"></param>
		/// <returns>A Boolean indicating success or failure of the query</returns>
		public bool LoadByPrimaryKey(int EmployeeID, short DepartmentID)
		{
			switch(this.DefaultCommandType)
			{
				case CommandType.StoredProcedure:
					ListDictionary parameters = new ListDictionary();

					// Add in parameters
					parameters.Add(EmployeeDepartmentHistorySchema.EmployeeID.FieldName, EmployeeID);
					parameters.Add(EmployeeDepartmentHistorySchema.DepartmentID.FieldName, DepartmentID);

					return base.LoadFromSql(this.SchemaStoredProcedureWithSeparator + "daab_GetEmployeeDepartmentHistory", parameters, CommandType.StoredProcedure);

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					this.Where.EmployeeID.Value = EmployeeID;
					this.Where.DepartmentID.Value = DepartmentID;
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
					return base.LoadFromSql(this.SchemaStoredProcedureWithSeparator + "daab_GetAllEmployeeDepartmentHistory", null, CommandType.StoredProcedure);

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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_AddEmployeeDepartmentHistory";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);

					CreateParameters(dbCommandWrapper);
					
					return dbCommandWrapper;

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					foreach(SchemaItem item in this.SchemaEntries)
					{
						if (!item.IsComputed)
						{
							if ((item.IsAutoKey && this.IdentityInsert) || !item.IsAutoKey)
							{
								this.Query.AddInsertColumn(item);
							}
						}
					}
					dbCommandWrapper = this.Query.GetInsertCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					if (this.IdentityInsert)
					{
					}
					else
					{
					}
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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_UpdateEmployeeDepartmentHistory";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);

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
					this.Where.EmployeeID.Operator = WhereParameter.Operand.Equal;
					this.Where.DepartmentID.Operator = WhereParameter.Operand.Equal;
					dbCommandWrapper = this.Query.GetUpdateCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					CreateParameters(dbCommandWrapper);
					
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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_DeleteEmployeeDepartmentHistory";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);
					dbCommandWrapper.AddInParameter("EmployeeID", DbType.Int32, "EmployeeID", DataRowVersion.Current);
					dbCommandWrapper.AddInParameter("DepartmentID", DbType.Int16, "DepartmentID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					this.Where.EmployeeID.Operator = WhereParameter.Operand.Equal;
					this.Where.DepartmentID.Operator = WhereParameter.Operand.Equal;
					dbCommandWrapper = this.Query.GetDeleteCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					dbCommandWrapper.AddInParameter("EmployeeID", DbType.Int32, "EmployeeID", DataRowVersion.Current);
					dbCommandWrapper.AddInParameter("DepartmentID", DbType.Int16, "DepartmentID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				default:
					throw new ArgumentException("Invalid CommandType", "commandType");
			}
		}

		private void CreateParameters(DBCommandWrapper dbCommandWrapper)
		{
			dbCommandWrapper.AddInParameter("EmployeeID", DbType.Int32, "EmployeeID", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("DepartmentID", DbType.Int16, "DepartmentID", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("StartDate", DbType.DateTime, "StartDate", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("EndDate", DbType.DateTime, "EndDate", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("ModifiedDate", DbType.DateTime, "ModifiedDate", DataRowVersion.Current);
		}
		
		#region Properties
		public virtual int EmployeeID
		{
			get
			{
				return this.GetInteger(EmployeeDepartmentHistorySchema.EmployeeID.FieldName);
	    	}
			set
			{
				this.SetInteger(EmployeeDepartmentHistorySchema.EmployeeID.FieldName, value);
			}
		}
		public virtual short DepartmentID
		{
			get
			{
				return this.GetShort(EmployeeDepartmentHistorySchema.DepartmentID.FieldName);
	    	}
			set
			{
				this.SetShort(EmployeeDepartmentHistorySchema.DepartmentID.FieldName, value);
			}
		}
		public virtual DateTime StartDate
		{
			get
			{
				return this.GetDateTime(EmployeeDepartmentHistorySchema.StartDate.FieldName);
	    	}
			set
			{
				this.SetDateTime(EmployeeDepartmentHistorySchema.StartDate.FieldName, value);
			}
		}
		public virtual DateTime EndDate
		{
			get
			{
				return this.GetDateTime(EmployeeDepartmentHistorySchema.EndDate.FieldName);
	    	}
			set
			{
				this.SetDateTime(EmployeeDepartmentHistorySchema.EndDate.FieldName, value);
			}
		}
		public virtual DateTime ModifiedDate
		{
			get
			{
				return this.GetDateTime(EmployeeDepartmentHistorySchema.ModifiedDate.FieldName);
	    	}
			set
			{
				this.SetDateTime(EmployeeDepartmentHistorySchema.ModifiedDate.FieldName, value);
			}
		}

		public override string TableName
		{
			get { return "EmployeeDepartmentHistory"; }
		}
		
		#endregion		
		
		#region String Properties
	
		public virtual string s_EmployeeID
	    {
			get
	        {
				return this.IsColumnNull(EmployeeDepartmentHistorySchema.EmployeeID.FieldName) ? string.Empty : base.GetIntegerAsString(EmployeeDepartmentHistorySchema.EmployeeID.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(EmployeeDepartmentHistorySchema.EmployeeID.FieldName);
				else
					this.EmployeeID = base.SetIntegerAsString(EmployeeDepartmentHistorySchema.EmployeeID.FieldName, value);
			}
		}

		public virtual string s_DepartmentID
	    {
			get
	        {
				return this.IsColumnNull(EmployeeDepartmentHistorySchema.DepartmentID.FieldName) ? string.Empty : base.GetShortAsString(EmployeeDepartmentHistorySchema.DepartmentID.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(EmployeeDepartmentHistorySchema.DepartmentID.FieldName);
				else
					this.DepartmentID = base.SetShortAsString(EmployeeDepartmentHistorySchema.DepartmentID.FieldName, value);
			}
		}

		public virtual string s_StartDate
	    {
			get
	        {
				return this.IsColumnNull(EmployeeDepartmentHistorySchema.StartDate.FieldName) ? string.Empty : base.GetDateTimeAsString(EmployeeDepartmentHistorySchema.StartDate.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(EmployeeDepartmentHistorySchema.StartDate.FieldName);
				else
					this.StartDate = base.SetDateTimeAsString(EmployeeDepartmentHistorySchema.StartDate.FieldName, value);
			}
		}

		public virtual string s_EndDate
	    {
			get
	        {
				return this.IsColumnNull(EmployeeDepartmentHistorySchema.EndDate.FieldName) ? string.Empty : base.GetDateTimeAsString(EmployeeDepartmentHistorySchema.EndDate.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(EmployeeDepartmentHistorySchema.EndDate.FieldName);
				else
					this.EndDate = base.SetDateTimeAsString(EmployeeDepartmentHistorySchema.EndDate.FieldName, value);
			}
		}

		public virtual string s_ModifiedDate
	    {
			get
	        {
				return this.IsColumnNull(EmployeeDepartmentHistorySchema.ModifiedDate.FieldName) ? string.Empty : base.GetDateTimeAsString(EmployeeDepartmentHistorySchema.ModifiedDate.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(EmployeeDepartmentHistorySchema.ModifiedDate.FieldName);
				else
					this.ModifiedDate = base.SetDateTimeAsString(EmployeeDepartmentHistorySchema.ModifiedDate.FieldName, value);
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
				
				
				public WhereParameter EmployeeID
				{
					get
					{
							WhereParameter wp = new WhereParameter(EmployeeDepartmentHistorySchema.EmployeeID);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter DepartmentID
				{
					get
					{
							WhereParameter wp = new WhereParameter(EmployeeDepartmentHistorySchema.DepartmentID);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter StartDate
				{
					get
					{
							WhereParameter wp = new WhereParameter(EmployeeDepartmentHistorySchema.StartDate);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter EndDate
				{
					get
					{
							WhereParameter wp = new WhereParameter(EmployeeDepartmentHistorySchema.EndDate);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter ModifiedDate
				{
					get
					{
							WhereParameter wp = new WhereParameter(EmployeeDepartmentHistorySchema.ModifiedDate);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter EmployeeID
		    {
				get
		        {
					if(_EmployeeID_W == null)
	        	    {
						_EmployeeID_W = TearOff.EmployeeID;
					}
					return _EmployeeID_W;
				}
			}

			public WhereParameter DepartmentID
		    {
				get
		        {
					if(_DepartmentID_W == null)
	        	    {
						_DepartmentID_W = TearOff.DepartmentID;
					}
					return _DepartmentID_W;
				}
			}

			public WhereParameter StartDate
		    {
				get
		        {
					if(_StartDate_W == null)
	        	    {
						_StartDate_W = TearOff.StartDate;
					}
					return _StartDate_W;
				}
			}

			public WhereParameter EndDate
		    {
				get
		        {
					if(_EndDate_W == null)
	        	    {
						_EndDate_W = TearOff.EndDate;
					}
					return _EndDate_W;
				}
			}

			public WhereParameter ModifiedDate
		    {
				get
		        {
					if(_ModifiedDate_W == null)
	        	    {
						_ModifiedDate_W = TearOff.ModifiedDate;
					}
					return _ModifiedDate_W;
				}
			}

			private WhereParameter _EmployeeID_W = null;
			private WhereParameter _DepartmentID_W = null;
			private WhereParameter _StartDate_W = null;
			private WhereParameter _EndDate_W = null;
			private WhereParameter _ModifiedDate_W = null;

			public void WhereClauseReset()
			{
				_EmployeeID_W = null;
				_DepartmentID_W = null;
				_StartDate_W = null;
				_EndDate_W = null;
				_ModifiedDate_W = null;

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
				
				
				public AggregateParameter EmployeeID
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(EmployeeDepartmentHistorySchema.EmployeeID);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter DepartmentID
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(EmployeeDepartmentHistorySchema.DepartmentID);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter StartDate
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(EmployeeDepartmentHistorySchema.StartDate);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter EndDate
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(EmployeeDepartmentHistorySchema.EndDate);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter ModifiedDate
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(EmployeeDepartmentHistorySchema.ModifiedDate);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter EmployeeID
		    {
				get
		        {
					if(_EmployeeID_W == null)
	        	    {
						_EmployeeID_W = TearOff.EmployeeID;
					}
					return _EmployeeID_W;
				}
			}

			public AggregateParameter DepartmentID
		    {
				get
		        {
					if(_DepartmentID_W == null)
	        	    {
						_DepartmentID_W = TearOff.DepartmentID;
					}
					return _DepartmentID_W;
				}
			}

			public AggregateParameter StartDate
		    {
				get
		        {
					if(_StartDate_W == null)
	        	    {
						_StartDate_W = TearOff.StartDate;
					}
					return _StartDate_W;
				}
			}

			public AggregateParameter EndDate
		    {
				get
		        {
					if(_EndDate_W == null)
	        	    {
						_EndDate_W = TearOff.EndDate;
					}
					return _EndDate_W;
				}
			}

			public AggregateParameter ModifiedDate
		    {
				get
		        {
					if(_ModifiedDate_W == null)
	        	    {
						_ModifiedDate_W = TearOff.ModifiedDate;
					}
					return _ModifiedDate_W;
				}
			}

			private AggregateParameter _EmployeeID_W = null;
			private AggregateParameter _DepartmentID_W = null;
			private AggregateParameter _StartDate_W = null;
			private AggregateParameter _EndDate_W = null;
			private AggregateParameter _ModifiedDate_W = null;

			public void AggregateClauseReset()
			{
				_EmployeeID_W = null;
				_DepartmentID_W = null;
				_StartDate_W = null;
				_EndDate_W = null;
				_ModifiedDate_W = null;

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
