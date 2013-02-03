using System;
using GenericsExample.Serialisation;
using NUnit.Framework;

namespace GenericsExampleTests
{
	[TestFixture()]
	public class SerialisationTests
	{
		[Test()]
		public void CanSerialiseAndDeserialise ()
		{
			// Arrange
			var sampleClass = new SampleClass(){ Name = "Foo!" };
			var serializedString = Serializer.Serialize(sampleClass);

			// Act
			var deserializedClass = Serializer.DeSerialize<SampleClass>(serializedString);

			// Assert
			Assert.That( deserializedClass, Is.InstanceOf<SampleClass>());
			Assert.That(deserializedClass.Name, Is.EqualTo(sampleClass.Name));
		}
	}
}

