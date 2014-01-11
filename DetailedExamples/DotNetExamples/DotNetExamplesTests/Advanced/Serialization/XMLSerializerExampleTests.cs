using NUnit.Framework;
using System;
using Advanced.Serialization;

namespace Advanced.Serialization.Tests
{
	[TestFixture ()]
	public class XMLSerializerExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var model = new MyModel (){ AnInt = 1, AString = "A", ABool = true };

			var aFileName = XMLSerializerExample.Serialize (model);
			var outModel = XMLSerializerExample.Deserialize<MyModel> (aFileName);

			Assert.AreEqual (model, outModel);
		}
	}
}