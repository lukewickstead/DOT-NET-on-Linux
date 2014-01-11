using NUnit.Framework;
using System;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class SerializationExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new SerializationExample ();

			Assert.AreEqual (sut.PostDataSet, sut.PostDataSet);
		}
	}
}