using System;
using NUnit.Framework;
using Ninject;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	[TestFixture()]
	public class BindToConstantTest
	{
		[Test()]
		public void CanBindToConstant ()
		{
			var kernel = new StandardKernel();
			var firstKnownC = new KnownC();

			kernel.Bind<IClass>().ToConstant( firstKnownC);

			var secondKnownC = kernel.Get<IClass>();

			Assert.That (secondKnownC, Is.InstanceOf<IClass>());
			Assert.That (secondKnownC, Is.InstanceOf<KnownC>());
			Assert.That (secondKnownC, Is.SameAs(firstKnownC));
		}
	}
}

