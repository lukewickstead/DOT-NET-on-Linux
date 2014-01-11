using System;
using NUnit.Framework;
using Ninject;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
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

			Assert.IsInstanceOfType (typeof(IClass), aClass);
			Assert.IsInstanceOfType (typeof(KnownC), aClass);
		}
	}
}