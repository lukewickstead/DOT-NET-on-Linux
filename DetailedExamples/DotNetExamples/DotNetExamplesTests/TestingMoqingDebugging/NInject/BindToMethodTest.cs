using System;
using NUnit.Framework;
using Ninject;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
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

			Assert.IsInstanceOfType (typeof(IClass), aClass);
			Assert.IsInstanceOfType (typeof(KnownC), aClass);
		}
	}
}