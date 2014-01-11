using System;
using ADO.DisconnectedLayer;
using NUnit.Framework;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class DataAdapterExampleTests
	{
		[Test ()]
		public void Test ()
		{
			var sut = new DataAdapterExample ();

			Assert.IsTrue(sut.Example ());
		}
	}
}