using System;
using NUnit.Framework;
using GenericsExample;

namespace GenericsExampleTests
{
	[TestFixture()]
	public class EnumTryParsewithDefaultTests
	{
		[Test()]
		public void ReturnsNullWhenCanNotParse ()
		{
			Assert.AreEqual( new Nullable<SampleEnum>(), "Hello".TryParse<SampleEnum>());
		}

		[Test()]
		public void ReturnsNullWhenEmptyString ()
		{
			Assert.AreEqual( new Nullable<SampleEnum>(), "".TryParse<SampleEnum>());
		}

		[Test()]
		public void ReturnsNullWhenEmptyString2 ()
		{
			Assert.AreEqual( new Nullable<SampleEnum>(), string.Empty.TryParse<SampleEnum>());
		}

		[Test()]
		public void ReturnsCorrectEnumWhenCorrectCase ()
		{
			Assert.AreEqual( SampleEnum.Foo, "Foo".TryParse<SampleEnum>());
		}

		[Test()]
		public void ReturnsCorrectEnumWhenInCorrectCase ()
		{
			Assert.AreEqual( SampleEnum.Foo, "fOO".TryParse<SampleEnum>());
		}
	}
}

