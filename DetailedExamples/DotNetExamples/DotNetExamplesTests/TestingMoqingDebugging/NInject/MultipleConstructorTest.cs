using System;
using Ninject;
using NUnit.Framework;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
{
	/// <summary>
	/// Multiple constructor test: demonstrates the determined order of picking a constructor
	/// Known parameters are explicitly bound
	/// Unknown parameters are implicitly bound
	/// As long as no constructor hs been marked with the Inject parameter the used constructor is the one with the most Known parameters
	/// </summary>
	[TestFixture()]
	public class MultipleConstructorTest
	{
		[Test()]
		public void CanSelectCorrectConstructor ()
		{
			IKernel aKernel = new StandardKernel (new MultipleConstructorModule ());

			var aClass = aKernel.Get<MultipleConstructorExample> ();

			Assert.IsInstanceOfType (typeof(MultipleConstructorExample), aClass);
			Assert.AreEqual (aClass.CalledBy, CalledBy.TwoParametersNoneUnknown); 
		}
	}
}

