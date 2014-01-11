using NUnit.Framework;
using System;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class CallingAStoredProcesureExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aDS = CallingAStoredProcesureExample.Example ();

			Assert.AreEqual (2, aDS.Tables.Count);

			Assert.Greater (aDS.Tables[0].Rows.Count, 0);			 
			Assert.Greater (aDS.Tables[1].Rows.Count, 0);
		}
	}
}