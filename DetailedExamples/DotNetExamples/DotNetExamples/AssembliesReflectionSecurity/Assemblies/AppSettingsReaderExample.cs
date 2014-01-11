using System;
using System.Configuration;

namespace AssembliesReflectionSecurity.Assembilies
{
	public class AppSettingsReaderExample
	{
		public static T GetAppSettingValue<T> (string name)
		{
			// To help figure out which machine.config is in used.
			var machineConigLocation = ConfigurationManager.OpenMachineConfiguration ().FilePath;

			var reader = new AppSettingsReader ();

			return (T)reader.GetValue (name, typeof(T));
		}
	}
}