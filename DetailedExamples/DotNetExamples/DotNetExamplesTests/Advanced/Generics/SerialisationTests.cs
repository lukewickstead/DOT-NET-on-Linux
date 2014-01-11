using System;
using NUnit.Framework;
using Advanced.Generics;

namespace Advanced.Generics.Tests
{
	[TestFixture ()]
	public class SerialisationTests
	{
		[Test ()]
		public void CanSerialiseAndDeserialise ()
		{
			// Arrange
			var sampleClass = new SampleClass (){ Name = "Foo!" };
			var serializedString = Serializer.Serialize (sampleClass);

			// Act
			var deserializedClass = Serializer.DeSerialize<SampleClass> (serializedString);

			// Assert
			Assert.IsInstanceOfType (typeof(SampleClass), deserializedClass);
			Assert.AreEqual (deserializedClass.Name, sampleClass.Name);
		}
	}
}