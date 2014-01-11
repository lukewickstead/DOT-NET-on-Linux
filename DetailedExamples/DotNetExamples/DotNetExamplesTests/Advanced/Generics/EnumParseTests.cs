using System;
using NUnit.Framework;
using Advanced.Generics;

namespace Advanced.Generics.Tests
{
	[TestFixture()]
	public class EnumParseTests
	{
		[Test()]
		public void ReturnsDefaultValueWhenCanNotParse ()
		{
			Assert.AreEqual( SampleEnum.Unknown, "Hello".Parse<SampleEnum>());
		}

		[Test()]
		public void ReturnsDefaultValueWhenEmptyString ()
		{
			Assert.AreEqual( SampleEnum.Unknown, "".Parse<SampleEnum>());
		}

		[Test()]
		public void ReturnsDefaultValueWhenEmptyString2 ()
		{
			Assert.AreEqual( SampleEnum.Unknown, string.Empty.Parse<SampleEnum>());
		}

		[Test()]
		public void ReturnsCorrectEnumWhenCorrectCase ()
		{
			Assert.AreEqual( SampleEnum.Foo, "Foo".Parse<SampleEnum>());
		}

		[Test()]
		public void ReturnsCorrectEnumWhenInCorrectCase ()
		{
			Assert.AreEqual( SampleEnum.Foo, "fOO".Parse<SampleEnum>());
		}
	}
}

