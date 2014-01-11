using NUnit.Framework;
using System;
using Advanced.Serialization;

namespace Advanced.Serialization.Tests
{
	[TestFixture ()]
	public class ExampleISerializableTests
	{
		[Test ()]
		public void TestCase ()
		{
			var model = new ExampleISerializable () { MyField = "Hello" };

			var aFileName = BinaryFormatterExample.Serialize (model);
			var outModel = BinaryFormatterExample.Deserialize<ExampleISerializable> (aFileName);

			Assert.AreEqual ("Hello", outModel.MyField);
		}
	}
}