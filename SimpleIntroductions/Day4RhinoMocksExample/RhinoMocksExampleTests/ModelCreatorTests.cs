using System;
using NUnit.Framework;
using Ninject;
using RhinoMocksExample;

//using Rhino;
using Rhino.Mocks;
using Rhino;


using System.Linq;
using System.Collections.Generic;

namespace RhinoMocksExampleTests
{
	[TestFixture()]
	public class ModelCreatorTests
	{

		StandardKernel ninjectKernel;
		List<Model> mockedModels;

		public ModelCreatorTests ()
		{
			ninjectKernel = new StandardKernel ();
		}


		[TestFixtureSetUp]
		public void PreTestInitialize ()
		{
        
			mockedModels = new List<Model> () {
				new Model() { FieldA = 1, FieldB = "Mock 1"},
            	new Model() { FieldA = 2, FieldB = "Mock 2"},
            	new Model() { FieldA = 3, FieldB = "Mock 3"},
            	new Model() { FieldA = 4, FieldB = "Mock 4"}
        	};

			IModelRepository mock = MockRepository.GenerateStub<IModelRepository> ();

			mock.Stub (m => m.GetModels ()).Return (mockedModels);
			mock.Stub (m => m.IsMock).Return (true);			
		//	mock.Stub( m => m.Add()).SetPropertyWithArgument(

			ninjectKernel.Bind<IModelRepository> ().ToConstant (mock);
		}


		[Test()]
		public void CanMockMethodTest ()
		{
			var modelCreator = ninjectKernel.Get<ModelCreator> ();

			var models = modelCreator.GetModels ();	

			Assert.AreEqual (models.FirstOrDefault ().FieldA, mockedModels.First ().FieldA);
			Assert.AreEqual (models.FirstOrDefault ().FieldB, mockedModels.First ().FieldB);
		}


		[Test()]
		public void CanMockCreate ()
		{
			var modelCreator = ninjectKernel.Get<ModelCreator> ();
			var modelRepository = ninjectKernel.Get<IModelRepository> ();

			var aModel = new Model () { FieldA = 1, FieldB = "Test"};
			modelCreator.CreateModel (aModel);


			modelRepository.AssertWasCalled (p => p.Add (aModel));
		}

		[Test()]
		public void CanMockRemove ()
		{
			var modelCreator = ninjectKernel.Get<ModelCreator> ();
			var modelRepository = ninjectKernel.Get<IModelRepository> ();

			var aModel = new Model () { FieldA = 1, FieldB = "Test"};
			modelCreator.RemoveModel (aModel);


			modelRepository.AssertWasCalled (p => p.Remove (aModel));
		}

		[Test()]
		public void CanMockProperty ()
		{
			var modelCreator = ninjectKernel.Get<ModelCreator> ();
		
			Assert.IsTrue( modelCreator.IsMock);
		}
	}
}

