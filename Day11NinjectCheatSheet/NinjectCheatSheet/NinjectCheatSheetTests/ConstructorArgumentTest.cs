using System;
using NUnit.Framework;
using Ninject;
using Ninject.Parameters;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
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

			Assert.That (aClass, Is.InstanceOf<ConstructorWithArguments> ());

			Assert.That (aClass.AnInt, Is.EqualTo (1));
			Assert.That (aClass.AString, Is.EqualTo ("Hello"));
			Assert.That (aClass.AClass, Is.InstanceOf<IClass> ());
			Assert.That (aClass.AClass, Is.InstanceOf<KnownE> ());
			Assert.That (aClass.AClass, Is.SameAs (anKnownE));
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


			Assert.That (aClass.AnInt, Is.EqualTo (1));
			Assert.That (aClass.AString, Is.EqualTo ("Foo"));
			Assert.That (aClass.AClass, Is.InstanceOf<IClass> ());
			Assert.That (aClass.AClass, Is.InstanceOf<KnownD> ());
		}
	}
}

