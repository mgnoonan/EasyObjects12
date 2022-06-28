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

	public class TerritoriesSchema : NCI.EasyObjects.Schema
	{
		private static ArrayList _entries;
		public static SchemaItem TerritoryID = new SchemaItem("TerritoryID", DbType.String, SchemaItemJustify.None, 20, false, true, true, false);
		public static SchemaItem TerritoryDescription = new SchemaItem("TerritoryDescription", DbType.StringFixedLength, SchemaItemJustify.None, 50, false, false, false, false);
		public static SchemaItem RegionID = new SchemaItem("RegionID", DbType.Int32, false, false, false, false, true, false);

		public override ArrayList SchemaEntries
		{
			get
			{
				if (_entries == null )
				{
					_entries = new ArrayList();
					_entries.Add(TerritoriesSchema.TerritoryID);
					_entries.Add(TerritoriesSchema.TerritoryDescription);
					_entries.Add(TerritoriesSchema.RegionID);
				}
				return _entries;
			}
		}
	}
	#endregion

	public abstract class _Territories : EasyObject
	{

		public _Territories()
		{
			TerritoriesSchema _schema = new TerritoriesSchema();
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
		/// <param name="TerritoryID"></param>
		/// <returns>A Boolean indicating success or failure of the query</returns>
		public bool LoadByPrimaryKey(string TerritoryID)
		{
			switch(this.DefaultCommandType)
			{
				case CommandType.StoredProcedure:
					ListDictionary parameters = new ListDictionary();

					// Add in parameters
					parameters.Add(TerritoriesSchema.TerritoryID.FieldName, TerritoryID);

					return base.LoadFromSql(this.SchemaStoredProcedureWithSeparator + "daab_GetTerritories", parameters, CommandType.StoredProcedure);

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					this.Where.TerritoryID.Value = TerritoryID;
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
					return base.LoadFromSql(this.SchemaStoredProcedureWithSeparator + "daab_GetAllTerritories", null, CommandType.StoredProcedure);

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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_AddTerritories";
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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_UpdateTerritories";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);

					dbCommandWrapper.AddInParameter("TerritoryID", DbType.String, "TerritoryID", DataRowVersion.Current);
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
					this.Where.TerritoryID.Operator = WhereParameter.Operand.Equal;
					dbCommandWrapper = this.Query.GetUpdateCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					CreateParameters(dbCommandWrapper);
					dbCommandWrapper.AddInParameter("TerritoryID", DbType.String, "TerritoryID", DataRowVersion.Current);
					
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
					string sqlCommand = this.SchemaStoredProcedureWithSeparator + "daab_DeleteTerritories";
					dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);
					dbCommandWrapper.AddInParameter("TerritoryID", DbType.String, "TerritoryID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				case CommandType.Text:
					this.Query.ClearAll();
					this.Where.WhereClauseReset();
					this.Where.TerritoryID.Operator = WhereParameter.Operand.Equal;
					dbCommandWrapper = this.Query.GetDeleteCommandWrapper();

					dbCommandWrapper.Command.Parameters.Clear();
					dbCommandWrapper.AddInParameter("TerritoryID", DbType.String, "TerritoryID", DataRowVersion.Current);
					
					return dbCommandWrapper;

				default:
					throw new ArgumentException("Invalid CommandType", "commandType");
			}
		}

		private void CreateParameters(DBCommandWrapper dbCommandWrapper)
		{
			dbCommandWrapper.AddInParameter("TerritoryID", DbType.String, "TerritoryID", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("TerritoryDescription", DbType.StringFixedLength, "TerritoryDescription", DataRowVersion.Current);
			dbCommandWrapper.AddInParameter("RegionID", DbType.Int32, "RegionID", DataRowVersion.Current);
		}
		
		#region Properties
		public virtual string TerritoryID
		{
			get
			{
				return this.GetString(TerritoriesSchema.TerritoryID.FieldName);
	    	}
			set
			{
				this.SetString(TerritoriesSchema.TerritoryID.FieldName, value);
			}
		}
		public virtual string TerritoryDescription
		{
			get
			{
				return this.GetString(TerritoriesSchema.TerritoryDescription.FieldName);
	    	}
			set
			{
				this.SetString(TerritoriesSchema.TerritoryDescription.FieldName, value);
			}
		}
		public virtual int RegionID
		{
			get
			{
				return this.GetInteger(TerritoriesSchema.RegionID.FieldName);
	    	}
			set
			{
				this.SetInteger(TerritoriesSchema.RegionID.FieldName, value);
			}
		}

		public override string TableName
		{
			get { return "Territories"; }
		}
		
		#endregion		
		
		#region String Properties
	
		public virtual string s_TerritoryID
	    {
			get
	        {
				return this.IsColumnNull(TerritoriesSchema.TerritoryID.FieldName) ? string.Empty : base.GetStringAsString(TerritoriesSchema.TerritoryID.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(TerritoriesSchema.TerritoryID.FieldName);
				else
					this.TerritoryID = base.SetStringAsString(TerritoriesSchema.TerritoryID.FieldName, value);
			}
		}

		public virtual string s_TerritoryDescription
	    {
			get
	        {
				return this.IsColumnNull(TerritoriesSchema.TerritoryDescription.FieldName) ? string.Empty : base.GetStringAsString(TerritoriesSchema.TerritoryDescription.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(TerritoriesSchema.TerritoryDescription.FieldName);
				else
					this.TerritoryDescription = base.SetStringAsString(TerritoriesSchema.TerritoryDescription.FieldName, value);
			}
		}

		public virtual string s_RegionID
	    {
			get
	        {
				return this.IsColumnNull(TerritoriesSchema.RegionID.FieldName) ? string.Empty : base.GetIntegerAsString(TerritoriesSchema.RegionID.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(TerritoriesSchema.RegionID.FieldName);
				else
					this.RegionID = base.SetIntegerAsString(TerritoriesSchema.RegionID.FieldName, value);
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
				
				
				public WhereParameter TerritoryID
				{
					get
					{
							WhereParameter wp = new WhereParameter(TerritoriesSchema.TerritoryID);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter TerritoryDescription
				{
					get
					{
							WhereParameter wp = new WhereParameter(TerritoriesSchema.TerritoryDescription);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}

				public WhereParameter RegionID
				{
					get
					{
							WhereParameter wp = new WhereParameter(TerritoriesSchema.RegionID);
							this._clause._entity.Query.AddWhereParameter(wp);
							return wp;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter TerritoryID
		    {
				get
		        {
					if(_TerritoryID_W == null)
	        	    {
						_TerritoryID_W = TearOff.TerritoryID;
					}
					return _TerritoryID_W;
				}
			}

			public WhereParameter TerritoryDescription
		    {
				get
		        {
					if(_TerritoryDescription_W == null)
	        	    {
						_TerritoryDescription_W = TearOff.TerritoryDescription;
					}
					return _TerritoryDescription_W;
				}
			}

			public WhereParameter RegionID
		    {
				get
		        {
					if(_RegionID_W == null)
	        	    {
						_RegionID_W = TearOff.RegionID;
					}
					return _RegionID_W;
				}
			}

			private WhereParameter _TerritoryID_W = null;
			private WhereParameter _TerritoryDescription_W = null;
			private WhereParameter _RegionID_W = null;

			public void WhereClauseReset()
			{
				_TerritoryID_W = null;
				_TerritoryDescription_W = null;
				_RegionID_W = null;

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
				
				
				public AggregateParameter TerritoryID
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(TerritoriesSchema.TerritoryID);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter TerritoryDescription
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(TerritoriesSchema.TerritoryDescription);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}

				public AggregateParameter RegionID
				{
					get
					{
							AggregateParameter ap = new AggregateParameter(TerritoriesSchema.RegionID);
							this._clause._entity.Query.AddAggregateParameter(ap);
							return ap;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter TerritoryID
		    {
				get
		        {
					if(_TerritoryID_W == null)
	        	    {
						_TerritoryID_W = TearOff.TerritoryID;
					}
					return _TerritoryID_W;
				}
			}

			public AggregateParameter TerritoryDescription
		    {
				get
		        {
					if(_TerritoryDescription_W == null)
	        	    {
						_TerritoryDescription_W = TearOff.TerritoryDescription;
					}
					return _TerritoryDescription_W;
				}
			}

			public AggregateParameter RegionID
		    {
				get
		        {
					if(_RegionID_W == null)
	        	    {
						_RegionID_W = TearOff.RegionID;
					}
					return _RegionID_W;
				}
			}

			private AggregateParameter _TerritoryID_W = null;
			private AggregateParameter _TerritoryDescription_W = null;
			private AggregateParameter _RegionID_W = null;

			public void AggregateClauseReset()
			{
				_TerritoryID_W = null;
				_TerritoryDescription_W = null;
				_RegionID_W = null;

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
