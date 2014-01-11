using NUnit.Framework;
using System;

namespace ADO.Connections.Tests
{
	[TestFixture ()]
	public class ConnectionStringBuilderExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var isOpen = ConnectionStringBuilderExample.Example ();
			Assert.IsTrue (isOpen);
		}
	}
}