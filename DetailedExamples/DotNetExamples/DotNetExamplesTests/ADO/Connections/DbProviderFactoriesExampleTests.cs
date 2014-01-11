using NUnit.Framework;
using System;
using ADO.Connections;

namespace ADO.Connections.Tests
{
	[TestFixture ()]
	public class DbProviderFactoriesExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var isOpen = DbProviderFactoriesExample.Example ();
			Assert.IsTrue (isOpen);
		}
	}
}