//===============================================================================
// NCI.EasyObjects library
// Schema class
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
using System.Collections;

namespace NCI.EasyObjects
{
	/// <summary>
	/// Represents a database Schema for an EasyObject.
	/// </summary>
	public abstract class Schema
	{
		/// <summary>
		/// The default constructor
		/// </summary>
		public Schema() {}

		/// <summary>
		/// An internal collection of <see cref="SchemaEntries"/>.
		/// <seealso cref="SchemaEntries"/>
		/// </summary>
		/// <remarks>Used in derived classes.</remarks>
		public virtual ArrayList SchemaEntries 
		{
			get 
			{
				return null;
			}
		}
	}
}
