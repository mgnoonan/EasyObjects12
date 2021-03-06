//===============================================================================
// NCI.EasyObjects library
// OracleDynamicQuery
//===============================================================================
// Copyright 2005 ? Noonan Consulting Inc. All rights reserved.
// Adapted from Mike Griffin's dOOdads architecture. Used by permission.
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace NCI.EasyObjects.DynamicQueryProvider
{
	/// <summary>
	/// Represents provider-specific <see cref="DynamicQuery"/> functions for Oracle.
	/// </summary>
	public class OracleDynamicQuery : DynamicQuery
	{
		/// <summary>
		/// Initializes a new instance of <see cref="OracleDynamicQuery"/>.
		/// </summary>
		public OracleDynamicQuery() : base()
		{}

		/// <summary>
		/// Initialize a new instance of the <see cref="OracleDynamicQuery"/> class.
		/// </summary>
		public OracleDynamicQuery(EasyObject entity) : base(entity)
		{}
	
		/// <summary>
		/// <para>Gets the parameter token used to delimit parameters for the Oracle database.</para>
		/// </summary>
		/// <value>
		/// <para>The ':' symbol.</para>
		/// </value>
		protected override char ParameterToken
		{
			get { return ':'; }
		}
	
		/// <summary>
		/// <para>Gets the string format used to delimit fieldnames for the Oracle Database.</para>
		/// </summary>
		/// <value>
		/// <para>'{0}' is the field format string for Oracle.</para>
		/// </value>
		protected override string FieldFormat { get { return "{0}"; } }
	
		/// <summary>
		/// <para>Gets the string format used to separate schema names and database objects for the Oracle.</para>
		/// </summary>
		/// <value>
		/// <para>'.' is the schema separator string for Oracle.</para>
		/// </value>
		protected override string SchemaSeparator { get { return "."; } }

		/// <summary>
		/// <para>Gets the string format used to delimit aliases for the Oracle Database.</para>
		/// </summary>
		/// <value>
		/// <para>"\"{0}\"" is the alias format string for Oracle.</para>
		/// </value>
		protected override string AliasFormat { get { return "\"{0}\""; } }

		/// <summary>
		/// Adds a field to the SELECT clause of the query
		/// </summary>
		/// <param name="fieldName">The field to add to the SELECT clause</param>
		public override void AddResultColumn(string fieldName)
		{
			base.AddResultColumnFormat(fieldName);
		}

		/// <summary>
		/// Adds a field to the ORDER BY clause of the query
		/// </summary>
		/// <param name="fieldName">The field to add to the ORDER BY clause</param>
		/// <param name="direction">A <seealso cref="WhereParameter.Dir"/> indicating which direction to sort the results</param>
		public override void AddOrderBy(string fieldName, NCI.EasyObjects.WhereParameter.Dir direction)
		{
			base.AddOrderByFormat(fieldName, direction);
		}

		/// <summary>
		/// Adds a COUNT(*) to the ORDER BY clause of the query
		/// </summary>
		/// <param name="countAll">A reference to a <seealso cref="DynamicQuery"/> object</param>
		/// <param name="direction">A <seealso cref="WhereParameter.Dir"/> indicating which direction to sort the results</param>
		public override void AddOrderBy(DynamicQuery countAll, NCI.EasyObjects.WhereParameter.Dir direction)
		{
			if(countAll.CountAll)
			{
				base.AddOrderBy("COUNT(*)", direction);
			}
		}

		/// <summary>
		/// Adds an aggregate parameter to the ORDER BY clause of the query
		/// </summary>
		/// <param name="aggregate">An <seealso cref="AggregateParameter"/> to add to the GROUP BY clause</param>
		/// <param name="direction">A <seealso cref="WhereParameter.Dir"/> indicating which direction to sort the results</param>
		public override void AddOrderBy(AggregateParameter aggregate, NCI.EasyObjects.WhereParameter.Dir direction)
		{
			base.AddOrderBy(GetAggregate(aggregate, false), direction);
		}

		/// <summary>
		/// Adds a GROUP BY parameter to the query
		/// </summary>
		/// <param name="aggregate">An <seealso cref="AggregateParameter"/> to add to the GROUP BY clause</param>
		public override void AddGroupBy(AggregateParameter aggregate)
		{
			// Common method
			base.AddGroupBy(GetAggregate(aggregate, false));
		}

		/// <summary>
		/// Builds a provider-specific SELECT query against the <see cref="EasyObject.QuerySource"/>.
		/// <seealso cref="EasyObject.QuerySource"/>
		/// </summary>
		/// <param name="dbCommandWrapper">An wrapper for an Enterprise Library command object</param>
		/// <param name="conjunction">The conjunction to use between multiple <see cref="WhereParameter"/>s</param>
		protected override void BuildSelectQuery(DBCommandWrapper dbCommandWrapper, string conjunction)
		{
			bool hasColumn = false;
			bool selectAll = true;
			StringBuilder query = new StringBuilder("SELECT ");

			if( this.Distinct) query.Append("DISTINCT ");

			if(this.ResultColumns.Length > 0)
			{
				query.Append(this.ResultColumns);
				hasColumn = true;
				selectAll = false;
			}
	 
			if(this._countAll)
			{
				if(hasColumn)
				{
					query.Append(", ");
				}
				
				query.Append("COUNT(*)");

				if(this._countAllAlias != string.Empty)
				{
					query.Append(" AS ");
					// Need DBMS string delimiter here
					query.AppendFormat(AliasFormat, this._countAllAlias);
				}
				
				hasColumn = true;
				selectAll = false;
			}
			
			if(_aggregateParameters != null && _aggregateParameters.Count > 0)
			{
				bool isFirst = true;
				
				if(hasColumn)
				{
					query.Append(", ");
				}
				
				AggregateParameter wItem;
	
				foreach(object obj in _aggregateParameters)
				{
					wItem = obj as AggregateParameter;
	
					if(wItem.IsDirty)
					{
						if(isFirst)
						{
							query.Append(GetAggregate(wItem, true));
							isFirst = false;
						}
						else
						{
							query.Append(", " + GetAggregate(wItem, true));
						}
					}
				}
				
				selectAll = false;
			}
			
			if(selectAll)
			{
				query.Append("*");
			}

			query.AppendFormat(" FROM {0}", this.QuerySourceWithSchema);

			BuildWhereClause(dbCommandWrapper, conjunction, query);

			// Special Oracle TOP logic
			if(this.TopN >= 0)
			{
				if(query.ToString().ToUpper().IndexOf(" WHERE ") > 0)
				{
					query.Append(" AND ");
				}
				else
				{
					query.Append(" WHERE ");
				}
				query.AppendFormat("rownum <= {0}", this.TopN.ToString());
			}

			if(_groupBy.Length > 0) 
			{
				query.Append(" GROUP BY ");
				
				if(this._withRollup)
				{
					query.Append(" ROLLUP(" + _groupBy + ")");
				}
				else
				{
					query.Append(_groupBy);
				}
			}
		
			if(this.OrderBy.Length > 0) 
			{
				query.AppendFormat(" ORDER BY {0}", this.OrderBy);
			}

			dbCommandWrapper.Command.CommandText = query.ToString();
		}

		/// <summary>
		/// Builds a provider-specific UPDATE query against the <see cref="EasyObject.QuerySource"/>.
		/// <seealso cref="EasyObject.QuerySource"/>
		/// </summary>
		/// <param name="dbCommandWrapper">A wrapper for an Enterprise Library command object</param>
		/// <param name="conjunction">The conjunction to use between multiple <see cref="WhereParameter"/>s</param>
		protected override void BuildUpdateQuery(DBCommandWrapper dbCommandWrapper, string conjunction)
		{
			ArgumentValidation.CheckForEmptyString(this.UpdateColumns, "Update Columns");
			ArgumentValidation.CheckForNullReference(this.ParameterValues, "Update Values");

			StringBuilder query = new StringBuilder();
			StringBuilder computedColumns = new StringBuilder();
			StringBuilder keyColumns = new StringBuilder();

			foreach (object entry in this._entity.SchemaEntries)
			{
				SchemaItem item = (SchemaItem)entry;
				if (item.IsRowID)
				{
					//query.AppendFormat("p{1} {2}%type := {0}{1}; ", this.ParameterToken, item.FieldName, this.TableNameWithSchema);
				}
			}

			query.Append("BEGIN ");
			query.AppendFormat("UPDATE {0}", this.TableNameWithSchema);
			query.Append(" SET ");
			query.Append(this.UpdateColumns);

			foreach (ValueParameter param in this.ParameterValues)
			{
				dbCommandWrapper.AddInParameter(ParameterToken + param.SchemaItem.FieldName, param.SchemaItem.DBType, param.Value);
			}

			BuildWhereClause(dbCommandWrapper, conjunction, query);
			query.Append("; ");

			// Check for concurrency violation
			query.Append("IF SQL%ROWCOUNT = 0 THEN ");
			query.Append("Raise_application_error(-20101, 'NO RECORDS WERE UPDATED'); ");
			query.Append("END IF; ");

			foreach (object entry in this._entity.SchemaEntries)
			{
				SchemaItem item = (SchemaItem)entry;
				
				if (item.IsComputed)
				{
					computedColumns.AppendFormat("{0}{1} = {2}, ", ParameterToken, item.FieldName, string.Format(this.FieldFormat, item.FieldName));
				}
				else if (item.IsInPrimaryKey)
				{
					keyColumns.AppendFormat("{0} = {1}{2} AND ", string.Format(this.FieldFormat, item.FieldName), ParameterToken, item.FieldName);
				}
				else if (item.IsRowID)
				{
					query.AppendFormat("{0}{1} := {0}{1} + 1; ", this.ParameterToken, item.FieldName);
				}
			}

			if (computedColumns.Length > 0)
			{
				// Get rid of trailing separators
				computedColumns.Length -= 2;
				keyColumns.Length -= 5;

				query.AppendFormat("SELECT {0} FROM {1}", computedColumns.ToString(), this.TableNameWithSchema);
				query.AppendFormat(" WHERE {0};", keyColumns.ToString());
			}

			query.Append("END;");

			dbCommandWrapper.Command.CommandText = query.ToString();
		}
		
		/// <summary>
		/// Adds a column to the UPDATE query
		/// </summary>
		/// <param name="item">A SchemaItem to add to the UPDATE statement</param>
		/// <remarks>This is overridden because Oracle has to watch for the RowID (similar to a timestamp) for concurrency</remarks>
		public override void AddUpdateColumn(SchemaItem item)
		{
			// If this item is not a rowID, then just call the base method
			if(!item.IsRowID)
			{
				base.AddUpdateColumn(item);
				return;
			}

			if(this.UpdateColumns.Length > 0)
			{
				this.UpdateColumns += ", ";
			}

			this.UpdateColumns += string.Format("{0} = {0} + 1", string.Format(this.FieldFormat, item.FieldName));
		}

		/// <summary>
		/// Builds a provider-specific INSERT query against the <see cref="EasyObject.QuerySource"/>.
		/// <seealso cref="EasyObject.QuerySource"/>
		/// </summary>
		/// <param name="dbCommandWrapper">A wrapper for an Enterprise Library command object</param>
		/// <param name="conjunction">The conjunction to use between multiple <see cref="WhereParameter"/>s</param>
		protected override void BuildInsertQuery(DBCommandWrapper dbCommandWrapper, string conjunction)
		{
			ArgumentValidation.CheckForEmptyString(this.InsertColumns, "Insert Columns");
			ArgumentValidation.CheckForNullReference(this.ParameterValues, "Query Values");

			StringBuilder query = new StringBuilder();
			StringBuilder computedColumns = new StringBuilder();
			StringBuilder keyColumns = new StringBuilder();

			query.Append("BEGIN ");

			foreach (object entry in this._entity.SchemaEntries)
			{
				SchemaItem item = (SchemaItem)entry;

				if (item.IsAutoKey && !this._entity.IdentityInsert)
				{
					query.AppendFormat("SELECT {0}.NEXTVAL INTO {2}{1} FROM DUAL; ", item.Properties["SEQ:I"].ToString(), item.FieldName, this.ParameterToken);
					this.AddInsertColumn(item);
				}

				if (item.IsRowID)
				{
					query.AppendFormat("{0}{1} := 1; ", this.ParameterToken, item.FieldName);
				}
			}

			query.AppendFormat("INSERT INTO {0}", this.TableNameWithSchema);
			query.Append(" (");
			query.Append(this.InsertColumns);
			query.Append(") VALUES (");
			query.Append(this.InsertColumnValues);
			query.Append(");");

			foreach (ValueParameter param in this.ParameterValues)
			{
				dbCommandWrapper.AddInParameter(ParameterToken + param.SchemaItem.FieldName, param.SchemaItem.DBType, param.Value);
			}

			BuildWhereClause(dbCommandWrapper, conjunction, query);

			foreach (object entry in this._entity.SchemaEntries)
			{
				SchemaItem item = (SchemaItem)entry;
				if (item.IsComputed)
				{
					computedColumns.AppendFormat("{0}{1} = {2}, ", ParameterToken, item.FieldName, string.Format(this.FieldFormat, item.FieldName));
				}
				else if (item.IsInPrimaryKey)
				{
					keyColumns.AppendFormat("{0} = {1}{2} AND ", string.Format(this.FieldFormat, item.FieldName), ParameterToken, item.FieldName);
				}
			}

			if (computedColumns.Length > 0)
			{
				// Get rid of trailing separators
				computedColumns.Length -= 2;
				keyColumns.Length -= 5;

				query.AppendFormat(" SELECT {0} FROM ", computedColumns.ToString());
				query.Append(this.TableNameWithSchema);
				query.AppendFormat(" WHERE {0};", keyColumns.ToString());
				
			}

			query.Append(" END;");

			dbCommandWrapper.Command.CommandText = query.ToString();
		}

		/// <summary>
		/// Builds a provider-specific DELETE query against the <see cref="EasyObject.QuerySource"/>.
		/// <seealso cref="EasyObject.QuerySource"/>
		/// </summary>
		/// <param name="dbCommandWrapper">A wrapper for an Enterprise Library command object</param>
		/// <param name="conjunction">The conjunction to use between multiple <see cref="WhereParameter"/>s</param>
		protected override void BuildDeleteQuery(DBCommandWrapper dbCommandWrapper, string conjunction)
		{
			StringBuilder query = new StringBuilder();
			
			query.AppendFormat("DELETE FROM {0}", this.TableNameWithSchema);

			BuildWhereClause(dbCommandWrapper, conjunction, query);

			dbCommandWrapper.Command.CommandText = query.ToString();
		}

		/// <summary>
		/// Construct the correct WHERE clause using the PL/SQL syntax (generic Oracle)
		/// </summary>
		/// <param name="dbCommandWrapper">A wrapper for an Enterprise Library command object</param>
		/// <param name="conjunction">The conjunction to use between parameters, usually AND or OR</param>
		/// <param name="query">The query string to append the WHERE clause to</param>
		protected virtual void BuildWhereClause(DBCommandWrapper dbCommandWrapper, string conjunction, StringBuilder query)
		{
		
			if(_whereParameters != null && _whereParameters.Count > 0)
			{
				query.Append(" WHERE ");

				bool first = true;

				bool requiresParam;

				WhereParameter wItem;
				bool skipConjunction = false;

				string paramName;
				string columnName;

				foreach(object obj in _whereParameters)
				{
					// Maybe we injected text or a WhereParameter
					if(obj.GetType().ToString() == "System.String")
					{
						string text = obj as string;
						query.Append(text);

						if(text == "(")
						{
							skipConjunction = true;
						}
					}
					else
					{
						wItem = obj as WhereParameter;

						if(wItem.IsDirty)
						{
							if(!first && !skipConjunction)
							{
								if(wItem.Conjunction != WhereParameter.Conj.UseDefault)
								{
									if(wItem.Conjunction == WhereParameter.Conj.And)
										query.Append(" AND ");
									else
										query.Append(" OR ");
								}
								else
								{
									query.Append(" " + conjunction + " ");
								}
							}

							requiresParam = true;

							columnName = string.Format(FieldFormat, wItem.SchemaItem.FieldName);
							paramName = ParameterToken + wItem.SchemaItem.FieldName;

							string originalParamName = paramName;
							int count = 1;

							while (dbCommandWrapper.Command.Parameters.Contains(paramName))
							{
								paramName = originalParamName + count++;
							}

							switch(wItem.Operator)
							{
								case WhereParameter.Operand.Equal:
									query.AppendFormat("{0} = {1} ", columnName, paramName);
									break;
								case WhereParameter.Operand.NotEqual:
									query.AppendFormat("{0} <> {1} ", columnName, paramName);
									break;
								case WhereParameter.Operand.GreaterThan:
									query.AppendFormat("{0} > {1} ", columnName, paramName);
									break;
								case WhereParameter.Operand.LessThan:
									query.AppendFormat("{0} < {1} ", columnName, paramName);
									break;
								case WhereParameter.Operand.LessThanOrEqual:
									query.AppendFormat("{0} <= {1} ", columnName, paramName);
									break;
								case WhereParameter.Operand.GreaterThanOrEqual:
									query.AppendFormat("{0} >= {1} ", columnName, paramName);
									break;
								case WhereParameter.Operand.Like:
									query.AppendFormat("{0} LIKE {1} ", columnName, paramName);
									break;
								case WhereParameter.Operand.NotLike:
									query.AppendFormat("{0} NOT LIKE {1} ", columnName, paramName);
									break;
								case WhereParameter.Operand.IsNull:
									query.AppendFormat("{0} IS NULL ", columnName);
									requiresParam = false;
									break;
								case WhereParameter.Operand.IsNotNull:
									query.AppendFormat("{0} IS NOT NULL ", columnName);
									requiresParam = false;
									break;
								case WhereParameter.Operand.In:
									query.AppendFormat("{0} IN ({1}) ", columnName, wItem.Value);
									requiresParam = false;
									break;
								case WhereParameter.Operand.NotIn:
									query.AppendFormat("{0} NOT IN ({1}) ", columnName, wItem.Value);
									requiresParam = false;
									break;
								case WhereParameter.Operand.Between:
									query.AppendFormat("{0} BETWEEN {1} AND {2}", columnName, paramName + "Begin", paramName + "End");
									dbCommandWrapper.AddInParameter(paramName + "Begin", wItem.SchemaItem.DBType, wItem.BetweenBeginValue.ToString());
									dbCommandWrapper.AddInParameter(paramName + "End", wItem.SchemaItem.DBType, wItem.BetweenEndValue.ToString());
									requiresParam = false;
									break;
							}

							if(requiresParam)
							{
								dbCommandWrapper.AddInParameter(paramName, wItem.SchemaItem.DBType, wItem.Value);
							}

							first = false;
							skipConjunction = false;
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Builds the provider-specific aggregate portion of the query
		/// </summary>
		/// <param name="param">An <seealso cref="AggregateParameter"/> to add to the GROUP BY clause</param>
		/// <param name="withAlias">A flag to indicate if the aggregate should use an alias, if one is present</param>
		/// <returns>A formatted string for the aggregate function</returns>
		/// <remarks>STDDEV and VARIANCE are rounded to 10 decimal places to avoid overflow errors</remarks>
		protected string GetAggregate(AggregateParameter param, bool withAlias)
		{
			StringBuilder query = new StringBuilder();
			bool roundResult = false;

			switch(param.Function)
			{
				case AggregateParameter.Func.Avg:
					query.Append("AVG(");
					break;
				case AggregateParameter.Func.Count:
					query.Append("COUNT(");
					break;
				case AggregateParameter.Func.Max:
					query.Append("MAX(");
					break;
				case AggregateParameter.Func.Min:
					query.Append("MIN(");
					break;
				case AggregateParameter.Func.Sum:
					query.Append("SUM(");
					break;
				case AggregateParameter.Func.StdDev:
					query.Append("ROUND(STDDEV(");
					roundResult = true;
					break;
				case AggregateParameter.Func.Var:
					query.Append("ROUND(VARIANCE(");
					roundResult = true;
					break;
			}
			
			if(param.Distinct)
			{
				query.Append("DISTINCT ");
			}

			query.AppendFormat(FieldFormat, param.Column);
			query.Append(")");
			
			if(roundResult)
			{
				query.Append(", 10)");
			}
			
			if(withAlias && param.Alias != string.Empty)
			{
				query.Append(" AS ");
				// Need DBMS string delimiter here
				query.AppendFormat(this.AliasFormat, param.Alias);
			}
			
			return query.ToString();
		}
	}
}
