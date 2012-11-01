using System;
using Ninject;
using NUnit.Framework;
using NinjectExample;
using NinjectExample.Interfaces;
using NinjectExample.Models;

namespace NinjectExampleTests
{
	[TestFixture()]
	public class Test
	{

		private IKernel kernel;

		[TestFixtureSetUp]
		public void Init ()
		{
			kernel = InjectionFactory.Instance.kernel;
		}

		[Test()]
		public void CanTestInterfaceInjection ()
		{

			var myClass = kernel.Get<ISimpleClass>();
			
			Assert.IsInstanceOf<SimpleClass>(myClass);
			Assert.AreEqual(myClass.WhoAmI(), "SimpleClass");
		}

		[Test()]
		public void CanTestInjectionWithDependancy ()
		{
			var myClass = kernel.Get<IClassWithDependancy>();

			Assert.IsInstanceOf<ClassWithDependancy>(myClass);
			Assert.AreEqual(myClass.WhoAmI(), "ClassWithDependancy of SimpleClass");

			Assert.IsInstanceOf<SimpleClass>(myClass.SimpleClass);
			Assert.AreEqual(myClass.SimpleClass.WhoAmI(), "SimpleClass");
		}

		
		[Test()]
		public void CanTestInjectionWithConstructorParameters ()
		{
			var myClass = kernel.Get<IClassWithConstructorParameters>();

			Assert.IsInstanceOf<ClassWithConstructorParameters>(myClass);
			Assert.AreEqual(myClass.WhoAmI(), "ClassWithConstructorParameters with messageOne:Hello and messageTwo:There");
		}

		[Test()]
		public void CanTestDerrivedClassInjecction ()
		{
			var myClass = kernel.Get<ClassWithDependancyAlso>();

			Assert.IsInstanceOf<ClassWithDependancyAlso>(myClass);
			Assert.AreEqual(myClass.WhoAmI(), "ClassWithDependancyAlso of SimpleClassAlso");

			Assert.IsInstanceOf<SimpleClassAlso>(myClass.SimpleClass);
			Assert.AreEqual(myClass.SimpleClass.WhoAmI(), "SimpleClassAlso");
		}
	}
}

