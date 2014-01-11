using NUnit.Framework;
using System;

namespace Advanced.Serialization.Tests
{
	[TestFixture ()]
	public class DataContractJsonSerializerExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var model = new MyModelDC (){ AnInt = 1, AString = "A", ABool = true };

			var aFileName = DataContractJsonSerializerExample.WriteObject (model);
			var outModel = DataContractJsonSerializerExample.ReadObject<MyModelDC> (aFileName);

			Assert.AreEqual (model, outModel);
		}
	}
}