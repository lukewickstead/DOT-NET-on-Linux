using NUnit.Framework;
using System;
using AssembliesReflectionSecurity.Assembilies;

namespace AssembliesReflectionSecurity.Assembilies.Tests
{
	[TestFixture ()]
	public class AppSettingsReaderExampleTests
	{
		[Test ()]
		public void TestGetString ()
		{
			var aValue = AppSettingsReaderExample.GetAppSettingValue<string> ("TheString");
			Assert.AreEqual ("AString", aValue);
		}

		[Test ()]
		public void TestGetInt ()
		{
			var aValue = AppSettingsReaderExample.GetAppSettingValue<int> ("TheInt");
			Assert.AreEqual (1, aValue);
		}
	}
}