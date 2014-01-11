using NUnit.Framework;
using System;
using ADO.ConnectedLayer;

namespace ADO.ConnectedLayer.Tests
{
	[TestFixture ()]
	public class TextCommandTypeExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var count = TextCommandTypeExample.Example ();
			Assert.Greater (count, 0);
		}
	}
}