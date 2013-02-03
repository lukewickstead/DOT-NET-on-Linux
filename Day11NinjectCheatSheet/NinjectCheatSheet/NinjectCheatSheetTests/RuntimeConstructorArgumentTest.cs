using System;
using NUnit.Framework;
using NinjectCheatSheet;
using Ninject;
using Ninject.Parameters;

namespace NinjectCheatSheetTests
{
	[TestFixture()]
	public class RuntimeConstructorArgumentTest
	{
		[Test()]
		public void TestCase ()
		{

			var kernel = new StandardKernel( );
			kernel.Bind<RuntimeConstructorArgumentExample>();

			var nameArg = new ConstructorArgument("Name", "Foo");
			var isAliveArg = new ConstructorArgument("IsAlive", true );

			var runtimeArgExample = kernel.Get<RuntimeConstructorArgumentExample>(nameArg, isAliveArg);

			Assert.That (runtimeArgExample, Is.InstanceOf<RuntimeConstructorArgumentExample>());
			Assert.That(runtimeArgExample.Name, Is.EqualTo("Foo") );
			Assert.That(runtimeArgExample.IsAlive, Is.True);
		}
	}
}

