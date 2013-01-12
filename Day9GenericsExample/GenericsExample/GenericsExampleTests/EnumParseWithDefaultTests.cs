using System;
using NUnit.Framework;
using GenericsExample;

namespace GenericsExampleTests
{
	[TestFixture()]
	public class EnumParsewithDefaultTests
	{
		[Test()]
		public void ReturnsDefaultValueWhenCanNotParse ()
		{
			Assert.AreEqual( SampleEnum.Bar, "Hello".Parse<SampleEnum>(SampleEnum.Bar));
		}

		[Test()]
		public void ReturnsDefaultValueWhenEmptyString ()
		{
			Assert.AreEqual( SampleEnum.Bar, "".Parse<SampleEnum>(SampleEnum.Bar));
		}

		[Test()]
		public void ReturnsDefaultValueWhenEmptyString2 ()
		{
			Assert.AreEqual( SampleEnum.Bar, string.Empty.Parse<SampleEnum>(SampleEnum.Bar));
		}

		[Test()]
		public void ReturnsCorrectEnumWhenCorrectCase ()
		{
			Assert.AreEqual( SampleEnum.Foo, "Foo".Parse<SampleEnum>(SampleEnum.Bar));
		}

		[Test()]
		public void ReturnsCorrectEnumWhenInCorrectCase ()
		{
			Assert.AreEqual( SampleEnum.Foo, "fOO".Parse<SampleEnum>(SampleEnum.Bar));
		}
	}
}

