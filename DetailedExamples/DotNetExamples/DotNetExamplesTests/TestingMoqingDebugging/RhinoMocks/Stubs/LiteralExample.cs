using NUnit.Framework;
using System;
using Rhino.Mocks;

namespace TestingMoqingDebugging.RhinoMocks.Tests
{
	[TestFixture ()]
	public class LiteralExample
	{
		private ISimpleModel sut;

		public LiteralExample()
		{
			this.sut = MockRepository.GenerateStub<ISimpleModel>();
			this.sut.Stub(x => x.Do(1)).Return(1);
			this.sut.Stub(x => x.Do("Foo")).Return(2);
		}

		[Test ()]
		public void TestCase ()
		{

			Assert.AreEqual (0, sut.Do ("Moo"));
			Assert.AreEqual (1, sut.Do (1));
			Assert.AreEqual (2, sut.Do ("Foo"));
		}
	}
}