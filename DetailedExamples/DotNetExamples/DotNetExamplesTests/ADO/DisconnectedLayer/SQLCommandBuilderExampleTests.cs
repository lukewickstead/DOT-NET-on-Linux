using System;
using ADO.DisconnectedLayer;
using NUnit.Framework;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class SQLCommandBuilderExampleTests
	{
		[Test ()]
		public void Test ()
		{
			var sut = new SQLCommandBuilderExample ();

			Assert.IsTrue(sut.Example ());
		}
	}
}