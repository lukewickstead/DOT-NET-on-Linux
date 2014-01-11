namespace TestingMoqingDebugging.RhinoMocks.Tests
{
    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    
    [TestFixture]
    public class IsConstraints
    {
        [Test]
        public void IsAnything()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<int>.Is.Anything)).Return(1);
       
            Assert.That(sut.Do(10).Equals(1));
            Assert.That(sut.Do(-10).Equals(1));
        }

        [Test]
        public void IsEqualIsNotEqual()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.Do(Arg<int>.Is.Equal(1))).Return(1);
            sut.Stub(x => x.Do(Arg<int>.Is.NotEqual(1))).Return(10);
       
            Assert.That(sut.Do(1).Equals(1));
            Assert.That(sut.Do(-10).Equals(10));
        }

        [Test]
        public void IsNullIsNotNull()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();
            sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.Null)).Return(1);
            sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.NotNull)).Return(2);      

            Assert.That(sut.DoIFoo(null).Equals(1));
            Assert.That(sut.DoIFoo(new Foo()).Equals(2));
        }

        [Test]
        public void IsTypeOf()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();

            sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.TypeOf)).Return(1);
            sut.Stub(x => x.DoIFoo(Arg<Moo>.Is.TypeOf)).Return(2);
       
            Assert.That(sut.DoIFoo(new Foo()).Equals(1));
            Assert.That(sut.DoIFoo(new Moo()).Equals(2));
        }

        [Test]
        public void LessThanGreaterThan()
        {
            var sut = MockRepository.GenerateStub<ISimpleModel>();

            sut.Stub(x => x.Do(Arg<int>.Is.LessThanOrEqual(10))).Return(1);
            sut.Stub(x => x.Do(Arg<int>.Is.GreaterThan(10))).Return(2);

            Assert.That(sut.Do(10).Equals(1));
            Assert.That(sut.Do(11).Equals(2));
        }

        [Test]
        public void IsSameNotSame()
        {
            var foo = new Foo();

            var sut = MockRepository.GenerateStub<ISimpleModel>();

            sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.Same(foo))).Return(1);
            sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.NotSame(foo))).Return(2);
                       
            Assert.That(sut.DoIFoo(foo).Equals(1));
            Assert.That(sut.DoIFoo(new Foo()).Equals(2));
        }       
    }
}