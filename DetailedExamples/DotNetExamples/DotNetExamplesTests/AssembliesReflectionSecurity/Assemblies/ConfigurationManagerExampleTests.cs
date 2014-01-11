using NUnit.Framework;
using System;
using AssembliesReflectionSecurity.Assembilies;

namespace AssembliesReflectionSecurity.Assembilies.Tests
{
	[TestFixture ()]
	public class ConfigurationManagerExampleTests
	{
		[Test ()]
		public void TestIterCount ()
		{
			Assert.AreEqual (2, ConfigurationManagerExample.GetIterCount ());
		}

		[Test ()]
		public void TestValuesCount ()
		{
			Assert.AreEqual (1, ConfigurationManagerExample.GetValuesCount ());
		}
	}
}