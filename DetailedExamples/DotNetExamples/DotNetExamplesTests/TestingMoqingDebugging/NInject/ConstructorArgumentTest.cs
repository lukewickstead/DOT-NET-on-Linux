using System;
using NUnit.Framework;
using Ninject;
using Ninject.Parameters;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
{
	[TestFixture()]
	public class ConstructorArgumentTest
	{
		[Test()]
		public void CanResolveConstructorArguments ()
		{
			var anKnownE = new KnownE ();

			var kernel = new StandardKernel ();
			kernel.Bind<ConstructorWithArguments> ()
				.ToSelf ()
					.WithConstructorArgument ("anInt", 1)  
					.WithConstructorArgument ("aString", "Hello")  
					.WithConstructorArgument ("aClass", anKnownE);  		

			var aClass = kernel.Get<ConstructorWithArguments> ();

			Assert.IsInstanceOfType (typeof(ConstructorWithArguments), aClass);
			Assert.AreEqual (aClass.AnInt, 1);
			Assert.AreEqual (aClass.AString, "Hello");
			Assert.IsInstanceOfType (typeof(IClass), aClass.AClass);
			Assert.IsInstanceOfType (typeof(KnownE), aClass.AClass);
			Assert.AreSame (aClass.AClass, anKnownE);
		}

		[Test()]
		public void CanResolveConstructorArgumentsAtGet ()
		{
			var kernel = new StandardKernel ();
			kernel.Bind<ConstructorWithArguments> ()
				.ToSelf ();

			var aClass = kernel.Get<ConstructorWithArguments> (
				new [] { 
				new ConstructorArgument ("anInt", 1),
				new ConstructorArgument ("aString", "Foo"),
				new ConstructorArgument ("aClass", new KnownD ())
			}
			);


			Assert.AreEqual (aClass.AnInt, 1);
			Assert.AreEqual (aClass.AString, "Foo");
			Assert.IsInstanceOfType (typeof(IClass), aClass.AClass);
			Assert.IsInstanceOfType (typeof(KnownD), aClass.AClass);
		}
	}
}

