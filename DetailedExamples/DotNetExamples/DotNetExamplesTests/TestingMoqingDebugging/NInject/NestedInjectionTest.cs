using System;
using Ninject;
using TestingMoqingDebugging.NInject;
using NUnit.Framework;

namespace TestingMoqingDebugging.NInject.Tests
{
	[TestFixture()]
	public class NestedInjection
	{
		[Test()]
		public void CanResolveNestedInjects ()
		{
			var aKernel = new StandardKernel();

			var aClass = aKernel.Get<Outter>();

			Assert.IsInstanceOfType (typeof(Middle), aClass.ConstructorArgInject);
			Assert.IsInstanceOfType (typeof(Middle), aClass.PropertyInject);

			Assert.IsInstanceOfType (typeof(Inner), aClass.ConstructorArgInject.ConstructorArgInject);
			Assert.IsInstanceOfType (typeof(Inner), aClass.ConstructorArgInject.PropertyInject);

			Assert.IsInstanceOfType (typeof(Inner), aClass.PropertyInject.ConstructorArgInject);
			Assert.IsInstanceOfType (typeof(Inner), aClass.PropertyInject.PropertyInject);
		}
	}
}