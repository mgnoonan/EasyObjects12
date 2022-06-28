//===============================================================================
// NCI.EasyObjects library
// DynamicQueryConfigurationView
//===============================================================================
// Copyright 2005 © Noonan Consulting Inc. All rights reserved.
// Adapted from Mike Griffin's dOOdads architecture. Used by permission.
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Configuration;

using NCI.EasyObjects.Configuration;

namespace NCI.EasyObjects
{
	/// <summary>
	/// <para>Represents a view for navigating the <see cref="DynamicQuerySettings"/> configuration data.</para>
	/// </summary>
	public class DynamicQueryConfigurationView : ConfigurationView
	{
		/// <summary>
		/// <para>Initialize a new instance of the <see cref="DynamicQueryConfigurationView"/> class with a <see cref="ConfigurationContext"/> object.</para>
		/// </summary>
		/// <param name="configurationContext">
		/// <para>A <see cref="ConfigurationContext"/> object.</para>
		/// </param>
		public DynamicQueryConfigurationView(ConfigurationContext configurationContext) : base(configurationContext)
		{}
	
		/// <summary>
		/// <para>Gets the <see cref="DynamicQuerySettings"/> configuration data.</para>
		/// </summary>
		/// <returns>
		/// <para>The <see cref="DynamicQuerySettings"/> configuration data.</para>
		/// </returns>
		public virtual DynamicQuerySettings GetDynamicQuerySettings()
		{
			return (DynamicQuerySettings)ConfigurationContext.GetConfiguration(DynamicQuerySettings.SectionName);
		}
	
		/// <summary>
		/// <para>Gets the name of the default <see cref="InstanceData"/>.</para>
		/// </summary>
		/// <returns>
		/// <para>The name of the default <see cref="InstanceData"/>.</para>
		/// </returns>
		public virtual string GetDefaultInstanceName()
		{
			DynamicQuerySettings settings = GetDynamicQuerySettings();
			string instanceName = settings.DefaultInstance;
			if (instanceName == null)
			{
				throw new ConfigurationException("A default instance was not defined in configuration so no dynamic query can be created.");
			}
			return instanceName;
		}

		/// <summary>
		/// <para>Gets the <see cref="DatabaseTypeData"/> for the named <see cref="InstanceData"/>.</para>
		/// </summary>
		/// <param name="instanceName">
		/// <para>The name of the <see cref="InstanceData"/> to get the data.</para>
		/// </param>
		/// <returns>
		/// <para>The <see cref="DatabaseTypeData"/> for the named <see cref="InstanceData"/>.</para>
		/// </returns>
		public virtual DatabaseTypeData GetDatabaseTypeData(string instanceName)
		{
			DynamicQuerySettings settings = GetDynamicQuerySettings();
			InstanceData instance = settings.Instances[instanceName];
			if (null == instance)
			{
				throw new ConfigurationException(string.Format("'{0}' is not a named instance in configuration.", instanceName));
			}

			DatabaseTypeData databaseType = settings.DatabaseTypes[instance.DatabaseTypeName];
			if (null == databaseType)
			{
				throw new ConfigurationException(string.Format("'{0}' is not a named database type in configuration.", instance.DatabaseTypeName));
			}

			return databaseType;
		}
	}
}
