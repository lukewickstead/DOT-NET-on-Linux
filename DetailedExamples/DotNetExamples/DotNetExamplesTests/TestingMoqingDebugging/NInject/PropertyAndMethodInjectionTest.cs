using System;
using Ninject;
using NUnit.Framework;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
{
	/// <summary>
	/// Property and method injection test: DI can be applied to methods and properties marked with the Inject attribute.
	/// </summary>
	[TestFixture()]
	public class PropertyAndMethodInjectionTest
	{
		[Test()]
		public void CanInjectMethod ()
		{
			IKernel aKernel = new StandardKernel();

			var aClass = aKernel.Get<PropertyAndMethodInjectionExample>();

			Assert.IsInstanceOfType(typeof(PropertyAndMethodInjectionExample), aClass);
			Assert.IsTrue(aClass.IsMethodInjected);
		}

		[Test()]
		public void CanInjectProperty ()
		{
			IKernel aKernel = new StandardKernel();

			var aClass = aKernel.Get<PropertyAndMethodInjectionExample>();

			Assert.IsInstanceOfType(typeof(PropertyAndMethodInjectionExample), aClass);
			Assert.IsTrue(aClass.IsPropertyInjected);
		}
	}
}