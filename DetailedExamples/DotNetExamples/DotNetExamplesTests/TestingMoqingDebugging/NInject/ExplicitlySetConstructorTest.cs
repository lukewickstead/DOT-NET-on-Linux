using System;
using Ninject;
using NUnit.Framework;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
{
	/// <summary>
	/// Any constructor marked with [Inject] attribute is used prior to any other constructor ordering
	/// </summary>
	[TestFixture()]
	public class ExplicitlySetConstructorTest
	{
		[Test()]
		public void CanSelectCorrectConstructor ()
		{
			IKernel aKernel = new StandardKernel(new MultipleConstructorModule());

			var aClass = aKernel.Get<ExplicitlySetConstructorExample>();

			Assert.IsInstanceOfType(typeof(ExplicitlySetConstructorExample), aClass);
			Assert.AreEqual(aClass.CalledBy, CalledBy.Empty); 
		}
	}
}