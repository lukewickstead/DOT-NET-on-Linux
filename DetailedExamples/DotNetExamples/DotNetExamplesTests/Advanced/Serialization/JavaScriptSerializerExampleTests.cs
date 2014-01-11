using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Advanced.Serialization.Tests
{
	[TestFixture ()]
	public class JavaScriptSerializerExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var models = new List<MyModel> () {
				new MyModel () { AnInt = 1, AString = "A", ABool = true },
				new MyModel () { AnInt = 2, AString = "B", ABool = false },
				new MyModel () { AnInt = 3, AString = "C", ABool = false },
				new MyModel () { AnInt = 4, AString = "D", ABool = true },
			};	

			var aString = JavaScriptSerializerExample.Serialize (models);
			var outModels = JavaScriptSerializerExample.Deserialize<MyModel> (aString);

			Assert.AreEqual (models, outModels);
		}
	}
}