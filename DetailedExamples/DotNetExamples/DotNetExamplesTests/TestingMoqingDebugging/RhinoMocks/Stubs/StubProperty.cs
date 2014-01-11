namespace TestingMoqingDebugging.RhinoMocks.Tests
{
    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    
    [TestFixture]   
    public class StubProperty
    {   
        [Test]
        public void WhenGetCalled()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();

            sut.Stub(x => x.AReadonlyPropery).Return(1);

            Assert.That(sut.AReadonlyPropery.Equals(1));
        }

        [Test]
        public void WhenSetCalled()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();

            sut.AProperty = 2;

            Assert.That(sut.AProperty.Equals(2));
        }
    }
}