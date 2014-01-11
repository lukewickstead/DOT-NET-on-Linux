namespace TestingMoqingDebugging.RhinoMocks.Tests
{
    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    
    [TestFixture]
    public class IgnoreArguments
    {
        [Test]
        public void IgnoreArgumentsTest()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<int>.Is.Equal(1))).IgnoreArguments().Return(1);
       
            Assert.That(sut.Do(10).Equals(1));
            Assert.That(sut.Do(-10).Equals(1));
        }
    }
}