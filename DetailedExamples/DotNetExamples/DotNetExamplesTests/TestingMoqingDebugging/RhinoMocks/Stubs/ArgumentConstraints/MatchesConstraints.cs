namespace TestingMoqingDebugging.RhinoMocks.Tests
{
    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    
    [TestFixture]
    public class MatchesConstraints
    {
        [Test]
        public void IsMatching()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<int>.Matches(y => y > 5))).Return(1);
            sut.Stub(x => x.Do(Arg<int>.Matches(y => y <= 5))).Return(0);

            Assert.That(sut.Do(4).Equals(0));
            Assert.That(sut.Do(6).Equals(1));
        }
    }
}