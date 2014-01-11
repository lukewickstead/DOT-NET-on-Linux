using System;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;

namespace AssembliesReflectionSecurity.Assembilies
{
	public class ConfigurationManagerExample
	{
		public static int GetIterCount ()
		{
			NameValueCollection appSettings = ConfigurationManager.AppSettings;

			foreach (var aValue in appSettings) {
			}

			return appSettings.AllKeys.Length;
		}

		public static int GetValuesCount ()
		{
			NameValueCollection appSettings = ConfigurationManager.AppSettings;

			var values = appSettings.GetValues ("TheString");

			if (values == null)
				return 0;
			 
			return values.Length;
		}
	}
}