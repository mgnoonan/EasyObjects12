//===============================================================================
// NCI.EasyObjects library
// DynamicQuerySettings
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
using System.Xml.Serialization;

namespace NCI.EasyObjects.Configuration
{
	/// <summary>
	/// <para>Represents the root configuration for data.</para>
	/// </summary>
	/// <remarks>
	/// <para>The class maps to the <c>dynamicQuerySettings</c> element in configuration.</para>
	/// </remarks>
	[XmlRoot("easyObjects.dynamicQuerySettings", Namespace=DynamicQuerySettings.ConfigurationNamespace)]
	public class DynamicQuerySettings
	{
		/// <summary>
		/// The name of the data configuration section.
		/// </summary>
		public const string SectionName = "dynamicQuerySettings";
		private DatabaseTypeDataCollection databaseTypes;
		private InstanceDataCollection instances;
		private string defaultInstance;

		/// <summary>
		/// <para>Gets the Xml namespace for this root node.</para>
		/// </summary>
		/// <value>
		/// <para>The Xml namespace for this root node.</para>
		/// </value>
		public const string ConfigurationNamespace = "http://www.noonanconsultinginc.com/practices/easyobjects.net/05-01-2005/data";

		/// <summary>
		/// <para>Initialize a new instance of the <see cref="DynamicQuerySettings"/> class.</para>
		/// </summary>
		public DynamicQuerySettings()
		{
			this.databaseTypes = new DatabaseTypeDataCollection();
			this.instances = new InstanceDataCollection();
		}

		/// <summary>
		/// <para>Gets the <see cref="DatabaseTypeDataCollection"/>.</para>
		/// </summary>
		/// <value>
		/// <para>The database types available in configuration.</para>
		/// </value>
		/// <remarks>
		/// <para>This property maps to the <c>databaseTypes</c> element in configuration.</para>
		/// </remarks>
		[XmlArray(ElementName="databaseTypes", Namespace=DynamicQuerySettings.ConfigurationNamespace)]
		[XmlArrayItem(ElementName="databaseType", Type=typeof(DatabaseTypeData), Namespace=DynamicQuerySettings.ConfigurationNamespace)]
		public DatabaseTypeDataCollection DatabaseTypes
		{
			get { return this.databaseTypes; }
		}

		/// <summary>
		/// <para>Gets the <see cref="InstanceDataCollection"/>.</para>
		/// </summary>
		/// <value>
		/// <para>The database instances available in configuration.</para>
		/// </value>
		/// <remarks>
		/// <para>This property maps to the <c>instances</c> element in configuration.</para>
		/// </remarks>
		[XmlArray(ElementName="instances", Namespace=DynamicQuerySettings.ConfigurationNamespace)]
		[XmlArrayItem(ElementName="instance", Type=typeof(InstanceData), Namespace=DynamicQuerySettings.ConfigurationNamespace)]
		public InstanceDataCollection Instances
		{
			get { return this.instances; }
		}

		/// <summary>
		/// <para>Gets or sets the default database instance.</para>
		/// </summary>
		/// <value>
		/// <para>The default database instance.</para>
		/// </value>
		/// <remarks>
		/// <para>This property maps to the <c>defaultInstance</c> element in configuration.</para>
		/// </remarks>
		[XmlAttribute("defaultInstance")]
		public string DefaultInstance
		{
			get { return this.defaultInstance; }
			set { this.defaultInstance = value; }
		}
	}
}