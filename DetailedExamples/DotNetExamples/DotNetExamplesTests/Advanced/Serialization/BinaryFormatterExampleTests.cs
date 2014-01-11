using NUnit.Framework;
using System;

namespace Advanced.Serialization.Tests
{
	[TestFixture ()]
	public class BinaryFormatterExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var model = new MyModel (){ AnInt = 1, AString = "A", ABool = true };

			var aFileName = BinaryFormatterExample.Serialize (model);
			var outModel = BinaryFormatterExample.Deserialize<MyModel> (aFileName);

			Assert.AreEqual (model, outModel);
		}
	}
}