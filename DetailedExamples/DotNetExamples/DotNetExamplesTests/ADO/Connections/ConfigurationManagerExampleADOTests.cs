using NUnit.Framework;
using System;

namespace ADO.Connections.Tests
{
	[TestFixture ()]
	public class ConfigurationManagerExampleADOTests
	{
		[Test ()]
		public void TestCase ()
		{
			string connection;
			string provider;

			ConfigurationManagerExampleADO.GetConnectionString (out connection, out provider);

			Assert.IsTrue (connection.Contains("localhost"));
			Assert.IsTrue (connection.Contains("AdminUser"));
			Assert.IsTrue (connection.Contains("MyDatabase"));
			Assert.IsTrue( provider.Contains("MySql"));
		}
	}
}