using NUnit.Framework;
using System;
using Advanced.Serialization;

namespace Advanced.Serialization.Tests
{
	[TestFixture ()]
	public class SoapFormatterExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var model = new MyModel (){ AnInt = 1, AString = "A", ABool = true };

			var aFileName = SoapFormatterExample.Serialize (model);
			var outModel = SoapFormatterExample.Deserialize<MyModel> (aFileName);

			Assert.AreEqual (model, outModel);
		}
	}
}