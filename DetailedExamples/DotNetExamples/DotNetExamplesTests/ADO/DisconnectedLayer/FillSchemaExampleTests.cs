using NUnit.Framework;
using System;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class FillSchemaExampleTests
	{
		[Test ()]
		public void TestFill ()
		{
			var aDataSet = FillSchemaExample.Example ();

			Assert.IsNotEmpty (aDataSet.Tables [0].PrimaryKey);
		}
	}
}