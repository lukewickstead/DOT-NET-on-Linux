using System;
using NUnit.Framework;
using Ninject;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
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

			Assert.IsInstanceOfType (typeof(IClass), secondKnownC);
			Assert.IsInstanceOfType (typeof(KnownC), secondKnownC);
			Assert.AreSame (secondKnownC, firstKnownC);
		}
	}
}

