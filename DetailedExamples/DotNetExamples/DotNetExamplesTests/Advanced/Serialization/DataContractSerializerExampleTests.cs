using NUnit.Framework;
using System;
using Advanced.Serialization;

namespace Advanced.Serialization.Tests
{
	[TestFixture ()]
	public class DataContractSerializerExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var model = new MyModelDC (){ AnInt = 1, AString = "A", ABool = true };

			var aFileName = DataContractSerializerExample.WriteObject (model);
			var outModel = DataContractSerializerExample.ReadObject<MyModelDC> (aFileName);

			Assert.AreEqual (model, outModel);
		}
	}
}