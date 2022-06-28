//===============================================================================
// NCI.EasyObjects library
// DynamicQueryProviderFactory
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
using Microsoft.Practices.EnterpriseLibrary.Configuration;

using NCI.EasyObjects.Configuration;

namespace NCI.EasyObjects
{
	/// <summary>
	/// Represents a factory pattern which generates a provider-specific <see cref="DynamicQuery"/> object from configuration settings.
	/// </summary>
	public class DynamicQueryProviderFactory : ProviderFactory
	{
		/// <summary>
		/// <para>Initialize a new instance of the <see cref="DynamicQueryProviderFactory"/> class.</para>
		/// </summary>
		public DynamicQueryProviderFactory() : this(ConfigurationManager.GetCurrentContext())
		{}

		/// <summary>
		/// <para>
		/// Initializes a new instance of the <see cref="DynamicQueryProviderFactory"/> class with the specified <see cref="ConfigurationContext"/>.
		/// </para>
		/// </summary>
		/// <param name="configurationContext">
		/// <para>Configuration context to use when creating factory</para>
		/// </param>
		public DynamicQueryProviderFactory(ConfigurationContext configurationContext) : base("DynamicQuery", configurationContext, typeof(DynamicQuery))
		{}
	
		/// <summary>
		/// <para>Creates the <see cref="DynamicQuery"/> object from the configuration data associated with the specified name.</para>
		/// </summary>
		/// <param name="instanceName">Instance name as defined in configuration</param>
		/// <returns><para>A <see cref="DynamicQuery"/> object.</para></returns>
		public DynamicQuery CreateDynamicQuery(string instanceName)
		{
			return (DynamicQuery)base.CreateInstance(instanceName);
		}
	
		/// <summary>
		/// <para>Creates the <see cref="DynamicQuery"/> object from the configuration data associated with the default database instance.</para>
		/// </summary>
		/// <returns><para>A <see cref="DynamicQuery"/> object.</para></returns>
		public DynamicQuery CreateDefaultDynamicQuery()
		{
			return (DynamicQuery)CreateDefaultInstance();
		}
	
		/// <summary>
		/// <para>Gets the default DynamicQuery instance type.</para>
		/// </summary>
		/// <returns>
		/// <para>The default DynamicQuery instance type.</para>
		/// </returns>
		protected override string GetDefaultInstanceName()
		{
			DynamicQueryConfigurationView view = (DynamicQueryConfigurationView)CreateConfigurationView();
			return view.GetDefaultInstanceName();
		}
	
		/// <summary>
		/// <para>Publish an instrumentation event that indicates there was an error while attempting to create a provider.</para>
		/// </summary>
		/// <param name="name"><para>The name of the configuration object.</para></param>
		/// <param name="e"><para>The <see cref="Exception"/> to publish.</para></param>
		protected override void PublishFailureEvent(string name, Exception e)
		{
			string errorMsg = string.Format("Error creating EasyObjects.DynamicQuery data provider \"{0}\".", name);
			//DynamicQueryFailureEvent.Fire(errorMsg, e);
		}
	
		/// <summary>
		/// <para>Creates the <see cref="DynamicQueryConfigurationView"/> object to navigate the <see cref="DynamicQuerySettings"/>.</para>
		/// </summary>
		/// <returns>
		/// <para>A <see cref="DynamicQueryConfigurationView"/> object.</para>
		/// </returns>
		protected override ConfigurationView CreateConfigurationView()
		{
			return new DynamicQueryConfigurationView(ConfigurationContext);
		}
	
		/// <summary>
		/// <para>Gets the <see cref="Type"/> of <see cref="DynamicQuery"/> to create based on the name of the <see cref="InstanceData"/>.</para>
		/// </summary>
		/// <param name="instanceName">
		/// <para>The name of the <see cref="InstanceData"/> to get the <see cref="Type"/>.</para>
		/// </param>
		/// <returns>
		/// <para>The <see cref="Type"/> of the <see cref="DynamicQuery"/> to create.</para>
		/// </returns>
		protected override Type GetConfigurationType(string instanceName)
		{
			DynamicQueryConfigurationView view = (DynamicQueryConfigurationView)CreateConfigurationView();
			DatabaseTypeData databaseTypeData = view.GetDatabaseTypeData(instanceName);
			return GetType(databaseTypeData.TypeName);
		}
	}
}
