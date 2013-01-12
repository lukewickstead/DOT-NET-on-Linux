using System;
using NUnit.Framework;
using Ninject;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	[TestFixture()]
	public class BindToConstructorTest
	{
		[Test()]
		public void CanBindToConstructor ()
		{
			var kernel = new StandardKernel();
			kernel.Bind<IClass>().ToConstructor( x => new KnownC());

			var aClass = kernel.Get<IClass>();

			Assert.That (aClass, Is.InstanceOf<IClass>());
			Assert.That (aClass, Is.InstanceOf<KnownC>());
		}
	}
}

