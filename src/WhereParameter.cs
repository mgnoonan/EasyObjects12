//===============================================================================
// NCI.EasyObjects library
// WhereParameter class
//===============================================================================
// Copyright 2005 © Noonan Consulting Inc. All rights reserved.
// Adapted from Mike Griffin's dOOdads architecture. Used by permission.
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;

namespace NCI.EasyObjects
{
	/// <summary>
	/// This class is dynamically created when you add a <see cref="WhereParameter"/> to your EasyObject's  <see cref="DynamicQuery"/> (See the EasyObject.Query).
	/// <seealso cref="EasyObject.Query"/>
	/// </summary>
	/// <remarks>
	/// This will be the extent of your use of the WhereParameter class, this class is mostly used internally by the 
	/// EasyObject architecture.
	/// <example>
	/// <code>
	/// emps.Where.LastName.Value = "%A%";
	/// emps.Where.LastName.Operator = WhereParameter.Operand.Like;
	/// </code>
	/// </example>
	/// </remarks>
	public class WhereParameter : ValueParameter
	{
		private Operand _operator;
		private Conj _conjuction = Conj.UseDefault;
		private bool _isDirty = false;

		private object _betweenBegin = null;
		private object _betweenEnd = null;

		/// <summary>
		/// The type of comparison this parameter should use
		/// </summary>
		/// <remarks>Some database providers may not support all Operands.</remarks>
		public enum Operand
		{
			/// <summary>
			/// Equal Comparison
			/// </summary>
			Equal = 1,
			/// <summary>
			/// Not Equal Comparison
			/// </summary>
			NotEqual,
			/// <summary>
			/// Greater Than Comparison
			/// </summary>
			GreaterThan,
			/// <summary>
			/// Greater Than or Equal Comparison
			/// </summary>
			GreaterThanOrEqual,
			/// <summary>
			/// Less Than Comparison
			/// </summary>
			LessThan,
			/// <summary>
			/// Less Than or Equal Comparison
			/// </summary>
			LessThanOrEqual,
			/// <summary>
			/// Like Comparison, "%s%" does it have an 's' in it? "s%" does it begin with 's'?
			/// </summary>
			Like,
			/// <summary>
			/// Is the value null in the database
			/// </summary>
			IsNull,
			/// <summary>
			/// Is the value non-null in the database
			/// </summary>
			IsNotNull,
			/// <summary>
			/// Is the value between two parameters? see <see cref="BetweenBeginValue"/> and <see cref="BetweenEndValue"/>. 
			/// Note that Between can be for other data types than just dates.
			/// </summary>
			Between,
			/// <summary>
			/// Is the value in a list, ie, "4,5,6,7,8"
			/// </summary>
			In,
			/// <summary>
			/// NOT in a list, ie not in, "4,5,6,7,8"
			/// </summary>
			NotIn,
			/// <summary>
			/// Not Like Comparison, "%s%", anything that does not it have an 's' in it.
			/// </summary>
			NotLike
		};

		/// <summary>
		/// The direction used by DynamicQuery.AddOrderBy
		/// <seealso cref="DynamicQuery.AddOrderBy"/>
		/// </summary>
		public enum Dir
		{
			/// <summary>
			/// Ascending
			/// </summary>
			ASC = 1,
			/// <summary>
			/// Descending
			/// </summary>
			DESC
		};

		/// <summary>
		/// The conjunction used between <see cref="WhereParameter"/>s.
		/// </summary>
		public enum Conj
		{
			/// <summary>
			/// <see cref="WhereParameter"/>s are joined via "And"
			/// </summary>
			And = 1,
			/// <summary>
			/// <see cref="WhereParameter"/>s are joined via "Or"
			/// </summary>
			Or,
			/// <summary>
			/// <see cref="WhereParameter"/>s are used via the default passed into <see cref="DynamicQuery.Load"/>.
			/// </summary>
			UseDefault
		};

		/// <summary>
		/// This is only called internally by the EasyObject architecture.
		/// </summary>
		/// <param name="item">The SchemaItem associated with the WhereParameter</param>
		public WhereParameter(SchemaItem item) : base(item)
		{
			this._operator = Operand.Equal;
		}

		/// <summary>
		/// Used to determine if the <see cref="WhereParameter"/>s has a value
		/// </summary>
		public bool IsDirty
		{
			get
			{
				return _isDirty;
			}
		}

		/// <summary>
		/// The value that will be placed into the Parameter
		/// </summary>
		public override object Value
		{
			get
			{
				return _value;
			}

			set
			{
				_value = value;
				_isDirty = true;
			}
		}

		/// <summary>
		/// The type of comparison desired
		/// </summary>
		public Operand Operator
		{
			get
			{
				return _operator;
			}

			set
			{
				_operator = value;
				_isDirty = true;
			}
		}

		/// <summary>
		/// The type of conjuction to use, "AND" or "OR"
		/// </summary>
		public Conj Conjunction
		{
			get
			{
				return _conjuction;
			}

			set
			{
				_conjuction = value;
				_isDirty = true;
			}
		}

		/// <summary>
		/// Used for the <see cref="Operand.Between"/> comparison
		/// </summary>
		public object BetweenBeginValue
		{
			get
			{
				return _betweenBegin;
			}

			set
			{
				_betweenBegin = value;
				_isDirty = true;
			}
		}

		/// <summary>
		/// Used for the <see cref="Operand.Between"/>comparison
		/// </summary>
		public object BetweenEndValue
		{
			get
			{
				return _betweenEnd;
			}

			set
			{
				_betweenEnd = value;
				_isDirty = true;
			}
		}
	}
}
