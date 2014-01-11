using System;
using NUnit.Framework;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture()]
	public class RowVersionExampleTest
	{
		[Test()]
		public void  Test ()
		{
			Assert.IsTrue (RowVersionExample.Example ());
		}
	}
}

