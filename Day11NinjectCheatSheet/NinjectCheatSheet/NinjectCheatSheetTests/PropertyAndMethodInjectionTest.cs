using System;
using Ninject;
using NUnit.Framework;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
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

			Assert.That(aClass, Is.InstanceOf<PropertyAndMethodInjectionExample>());
			Assert.That(aClass.IsMethodInjected, Is.True);
		}

		[Test()]
		public void CanInjectProperty ()
		{
			IKernel aKernel = new StandardKernel();

			var aClass = aKernel.Get<PropertyAndMethodInjectionExample>();

			Assert.That(aClass, Is.InstanceOf<PropertyAndMethodInjectionExample>());
			Assert.That(aClass.IsPropertyInjected, Is.True);
		}
	}
}

