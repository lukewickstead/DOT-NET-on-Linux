using NUnit.Framework;
using System;
using ADO.ConnectedLayer;

namespace ADO.ConnectedLayer.Tests
{
	[TestFixture ()]
	public class ExecutingAStoredProcedureExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var outParam = 0;
			var count = ExecutingAStoredProcedureExample.Example (out outParam);

			Assert.AreEqual (count, outParam);
			Assert.Greater (count, 0);
			Assert.Greater (outParam, 0);
		}


		[Test ()]
		public void TestExampleWithDataReader ()
		{
			var setCount  = 0;
			var recordCount = 0;

			ExecutingAStoredProcedureExample.ExampleWithDataReader (out setCount, out recordCount);

			Assert.Greater (setCount, 0);
			Assert.Greater (recordCount, 0);
		}
	}
}