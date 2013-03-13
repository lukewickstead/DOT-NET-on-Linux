namespace RhinoMocksExample.Mocks
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Rhino;
    using Rhino.Mocks;
    using RhinoMocksExample.Model;

    [TestFixture]
    public class AssertWasCalledTests
    {        
        [Test]
        public void WhenArgumentsIsAnything()
        {
            IModelRepository mock = MockRepository.GenerateMock<IModelRepository>();

            var modelCreator = new ModelCreator(mock);
            var theModel = new AnotherModel() { FieldA = 1, FieldB = "Test" };

            modelCreator.CreateModel(theModel);

            mock.AssertWasCalled(p => p.Add(Arg<AnotherModel>.Is.Anything));
        }
        
        [Test]
        public void WhenArgumentsIsNotNull()
        {
            IModelRepository mock = MockRepository.GenerateMock<IModelRepository>();

            var modelCreator = new ModelCreator(mock);
            var theModel = new AnotherModel() { FieldA = 1, FieldB = "Test" };

            modelCreator.CreateModel(theModel);

            mock.AssertWasCalled(p => p.Add(Arg<AnotherModel>.Is.NotNull));
        }

        [Test]
        public void WhenArgumentsIsEqual()
        {
            IModelRepository mock = MockRepository.GenerateMock<IModelRepository>();

            var modelCreator = new ModelCreator(mock);
            var theModel = new AnotherModel() { FieldA = 1, FieldB = "Test" };

            modelCreator.CreateModel(theModel);

            mock.AssertWasCalled(p => p.Add(Arg<AnotherModel>.Is.Equal(theModel)));
        }

         [Test]
        public void WhenNotCalled()
        {
            IModelRepository mock = MockRepository.GenerateMock<IModelRepository>();

            var modelCreator = new ModelCreator(mock);
            var theModel = new AnotherModel() { FieldA = 1, FieldB = "Test" };

            modelCreator.CreateModel(theModel);

            mock.AssertWasNotCalled(p => p.Add(Arg<AnotherModel>.Is.Null));       
        }

        [Test]
        public void WhenReadonlyProperty()
        {
            var sut = MockRepository.GenerateMock<ISimpleModel>();

            var foo = sut.AReadonlyPropery;

            Assert.That(foo.Equals(0));
            sut.AssertWasCalled(x => x.AReadonlyPropery);
        }

        [Test]
        public void WhenProperyGetCalled()
        {
            var sut = MockRepository.GenerateMock<ISimpleModel>();                        
      
            Assert.That(sut.AProperty, Is.EqualTo(0));

            sut.AssertWasCalled(x => x.AProperty);
        }

        [Test]
        public void WhenProperySetCalled()
        {
            var sut = MockRepository.GenerateMock<ISimpleModel>();                       

            sut.AProperty = 9;

            Assert.That(sut.AProperty, Is.EqualTo(0));

            sut.AssertWasCalled(x => x.AProperty = 9);
        }       
    }
}