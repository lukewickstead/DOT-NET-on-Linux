using System;
using NUnit.Framework;
using Ninject;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	[TestFixture()]
	public class BindToMethodTest
	{
		[Test()]
		public void CanBindToMethod ()
		{
			var kernel = new StandardKernel();
			kernel.Bind<IClass>().ToMethod( x => new KnownC());

			var aClass = kernel.Get<IClass>();

			Assert.That (aClass, Is.InstanceOf<IClass>());
			Assert.That (aClass, Is.InstanceOf<KnownC>());
		}
	}
}

