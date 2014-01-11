using NUnit.Framework;
using System;

namespace Advanced.Serialization.Tests
{
	[TestFixture ()]
	public class SerializeEventsExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var model = new SerializeEventsExample ();
			
			var aFileName = BinaryFormatterExample.Serialize (model);
			var outModel = BinaryFormatterExample.Deserialize<SerializeEventsExample> (aFileName);

			Assert.IsFalse (model.OnDeserializedFire);
			Assert.IsTrue (model.OnSerializingFire);

			Assert.IsTrue (outModel.OnSerializingFire);
			Assert.IsTrue (outModel.OnDeserializedFire);
		}
	}
}