//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Resources;
using System.Reflection;

// -----------------------------------------------------------------------------
//  <autogeneratedinfo>
//      This code was generated by:
//        SR Resource Generator custom tool for VS.NET, by Martin Granell, Readify
// 
//      It contains classes defined from the contents of the resource file:
//        C:\Projects\EasyObjects\QuickStarts\CS\SR.resx
// 
//      Generated: Sunday, November 20, 2005 8:35 PM
//  </autogeneratedinfo>
// -----------------------------------------------------------------------------
namespace EasyObjectsQuickStart
{
    
    
    internal class SR
    {
        
        internal static System.Globalization.CultureInfo Culture
        {
            get
            {
                return Keys.Culture;
            }
            set
            {
                Keys.Culture = value;
            }
        }
        
        internal static string ApplicationErrorMessage
        {
            get
            {
                return Keys.GetString(Keys.ApplicationErrorMessage);
            }
        }
        
        internal static string DbRequirementsMessage
        {
            get
            {
                return Keys.GetString(Keys.DbRequirementsMessage);
            }
        }
        
        internal static string SimpleMessage
        {
            get
            {
                return Keys.GetString(Keys.SimpleMessage);
            }
        }
        
        internal static string TransferCompletedMessage
        {
            get
            {
                return Keys.GetString(Keys.TransferCompletedMessage);
            }
        }
        
        internal static string TransferFailedMessage
        {
            get
            {
                return Keys.GetString(Keys.TransferFailedMessage);
            }
        }
        
        internal static string AffectedRowsMessage(int rows)
        {
            return Keys.GetString(Keys.AffectedRowsMessage, new object[] {
                        rows});
        }
        
        internal static string FileOpenError(object filename, object description)
        {
            return Keys.GetString(Keys.FileOpenError, new object[] {
                        filename,
                        description});
        }
        
        internal static string GeneralExceptionMessage(object message)
        {
            return Keys.GetString(Keys.GeneralExceptionMessage, new object[] {
                        message});
        }
        
        internal static string ProgressMessage(int iterationCount)
        {
            return Keys.GetString(Keys.ProgressMessage, new object[] {
                        iterationCount});
        }
        
        internal class Keys
        {
            
            static System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(SR));
            
            static System.Globalization.CultureInfo _culture = null;
            
            internal const string AffectedRowsMessage = "AffectedRowsMessage";
            
            internal const string ApplicationErrorMessage = "ApplicationErrorMessage";
            
            internal const string DbRequirementsMessage = "DbRequirementsMessage";
            
            internal const string FileOpenError = "FileOpenError";
            
            internal const string GeneralExceptionMessage = "GeneralExceptionMessage";
            
            internal const string ProgressMessage = "ProgressMessage";
            
            internal const string SimpleMessage = "SimpleMessage";
            
            internal const string TransferCompletedMessage = "TransferCompletedMessage";
            
            internal const string TransferFailedMessage = "TransferFailedMessage";
            
            internal static System.Globalization.CultureInfo Culture
            {
                get
                {
                    return _culture;
                }
                set
                {
                    _culture = value;
                }
            }
            
            internal static string GetString(string key)
            {
                return resourceManager.GetString(key, _culture);
            }
            
            internal static string GetString(string key, object[] args)
            {
                string msg = resourceManager.GetString(key, _culture);
                msg = string.Format(msg, args);
                return msg;
            }
        }
    }
}