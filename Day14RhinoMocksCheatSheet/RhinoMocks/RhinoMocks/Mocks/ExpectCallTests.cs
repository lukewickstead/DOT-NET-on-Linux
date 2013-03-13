namespace RhinoMocksExample.Mocks
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Rhino;
    using Rhino.Mocks;
    using RhinoMocksExample.Model;

    [TestFixture]
    public class ExpectCallTests
    {        
        [Test]
        public void WhenArgumentIsAnything()
        {
            IModelRepository mock = MockRepository.GenerateMock<IModelRepository>();

            var modelCreator = new ModelCreator(mock);
            var theModel = new AnotherModel() { FieldA = 1, FieldB = "Test" };

            mock.Expect(p => p.Add(Arg<AnotherModel>.Is.Anything));
            modelCreator.CreateModel(theModel);

            mock.VerifyAllExpectations();
        }
        
        [Test]
        public void WhenArgumentIsNotNull()
        {
            IModelRepository mock = MockRepository.GenerateMock<IModelRepository>();

            var modelCreator = new ModelCreator(mock);
            var theModel = new AnotherModel() { FieldA = 1, FieldB = "Test" };

            mock.Expect(p => p.Add(Arg<AnotherModel>.Is.NotNull));
       
            modelCreator.CreateModel(theModel);

            mock.VerifyAllExpectations();
        }

        [Test]
        public void WhenArgumentIsEqualTo()
        {
            IModelRepository mock = MockRepository.GenerateMock<IModelRepository>();

            var modelCreator = new ModelCreator(mock);
            var theModel = new AnotherModel() { FieldA = 1, FieldB = "Test" };
                      
            mock.Expect(p => p.Add(Arg<AnotherModel>.Is.Equal(theModel)));

            modelCreator.CreateModel(theModel);

            mock.VerifyAllExpectations();
        }

        [Test]
        public void WhenReadonlyPropertyCalled()
        {
            var sut = MockRepository.GenerateMock<ISimpleModel>();

            sut.Expect(x => x.AReadonlyPropery).Return(9);

            Assert.That(sut.AReadonlyPropery, Is.EqualTo(9));

            sut.VerifyAllExpectations();
        }

        [Test]
        public void WhenPropertyGetCalled()
        {
            var sut = MockRepository.GenerateMock<ISimpleModel>();

            sut.Expect(x => x.AProperty).Return(9);

            Assert.That(sut.AProperty, Is.EqualTo(9));

            sut.VerifyAllExpectations();
        }

        [Test]
        public void WhenPropertySetCalledWithIgnoreArguments()
        {
            var sut = MockRepository.GenerateMock<ISimpleModel>();

            sut.Expect(x => x.AProperty).SetPropertyAndIgnoreArgument();
                    
            sut.AProperty = 1;
           
            sut.VerifyAllExpectations();
        }

        [Test]
        public void WhenPropertySetCalledWithArguments()
        {
            var sut = MockRepository.GenerateMock<ISimpleModel>();

            sut.Expect(x => x.AProperty).SetPropertyWithArgument(11);
                     
            sut.AProperty = 11;

            sut.VerifyAllExpectations();
        }
    }
}