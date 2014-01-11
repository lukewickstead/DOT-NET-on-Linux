namespace TestingMoqingDebugging.RhinoMocks.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Rhino.Mocks;
    using RIS = Rhino.Mocks.Constraints.Is;

    [TestFixture]
    public class ListConstraints
    {
        [Test]
        public void Count()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<List<int>>.List.Count(RIS.Equal(0)))).Return(0);
            sut.Stub(x => x.Do(Arg<List<int>>.List.Count(RIS.Equal(1)))).Return(1);

            Assert.That(sut.Do(new List<int>()).Equals(0));
            Assert.That(sut.Do(new List<int> { 1 }).Equals(1));
        }

        [Test]
        public void Element()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<List<int>>.List.Element(0, RIS.Equal(1)))).Return(1);
            sut.Stub(x => x.Do(Arg<List<int>>.List.Element(1, RIS.GreaterThanOrEqual(2)))).Return(2);

            Assert.That(sut.Do(new List<int> { 0, 0 }).Equals(0));
            Assert.That(sut.Do(new List<int> { 1, 0 }).Equals(1));
            Assert.That(sut.Do(new List<int> { 0, 2 }).Equals(2));
            Assert.That(sut.Do(new List<int> { 0, 20 }).Equals(2));
        }

        [Test]
        public void Equal()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<List<int>>.List.Equal(new int[] { 1, 2, 3 }))).Return(1);
            sut.Stub(x => x.Do(Arg<List<int>>.List.Equal(new int[] { 4, 5, 6 }))).Return(2);
         
            Assert.That(sut.Do(new List<int> { 1, 2, 3 }).Equals(1));
            Assert.That(sut.Do(new List<int> { 4, 5, 6 }).Equals(2));
        }

        [Test]
        public void IsIn()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<List<int>>.List.IsIn(1))).Return(1);
            sut.Stub(x => x.Do(Arg<List<int>>.List.IsIn(4))).Return(2);

            Assert.That(sut.Do(new List<int> { 1, 2, 3 }).Equals(1));
            Assert.That(sut.Do(new List<int> { 4, 5, 6 }).Equals(2));
        }

        [Test]
        public void OneOf()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<int>.List.OneOf(new int[] { 1, 2, 3 }))).Return(1);
            sut.Stub(x => x.Do(Arg<int>.List.OneOf(new int[] { 4, 5, 6 }))).Return(2);

            Assert.That(sut.Do(1).Equals(1));
            Assert.That(sut.Do(4).Equals(2));
        }  
    }
}