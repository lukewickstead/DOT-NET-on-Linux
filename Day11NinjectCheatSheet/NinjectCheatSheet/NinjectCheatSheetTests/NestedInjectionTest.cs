using System;
using Ninject;
using NinjectCheatSheet;
using NUnit.Framework;

namespace NinjectCheatSheetTests
{
	[TestFixture()]
	public class NestedInjection
	{
		[Test()]
		public void CanResolveNestedInjects ()
		{
			var aKernel = new StandardKernel();

			var aClass = aKernel.Get<Outter>();

			Assert.That (aClass.ConstructorArgInject, Is.Not.Null.And.InstanceOf<Middle>());
			Assert.That (aClass.PropertyInject, Is.Not.Null.And.InstanceOf<Middle>());

			Assert.That (aClass.ConstructorArgInject.ConstructorArgInject, Is.Not.Null.And.InstanceOf<Inner>());
			Assert.That (aClass.ConstructorArgInject.PropertyInject, Is.Not.Null.And.InstanceOf<Inner>());

			Assert.That (aClass.PropertyInject.ConstructorArgInject, Is.Not.Null.And.InstanceOf<Inner>());
			Assert.That (aClass.PropertyInject.PropertyInject, Is.Not.Null.And.InstanceOf<Inner>());
		}
	}
}

