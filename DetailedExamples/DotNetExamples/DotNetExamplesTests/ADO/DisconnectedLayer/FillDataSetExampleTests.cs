using NUnit.Framework;
using System;
using  ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class FillDataSetExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var ds = FillDataSetExample.Example ();

			Assert.Greater (ds.Tables.Count, 0);
			Assert.Greater (ds.Tables[0].Rows.Count, 0);
			Assert.Greater (ds.Tables[0].Columns.Count, 0);
		}
	}
}