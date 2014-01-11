using System;
using Ninject;
using TestingMoqingDebugging.NInject;
using Ninject.Activation;
using NUnit.Framework;

namespace TestingMoqingDebugging.NInject.Tests
{
	[TestFixture()]
	public class BindToProvider
	{
		[Test()]
		public void CanBindToProvider ()
		{
			var kernel = new StandardKernel();

			kernel.Bind<IClass>().ToProvider( new KnownCProvider());

			var aClass = kernel.Get<IClass>();

			Assert.IsInstanceOfType (typeof(IClass), aClass);
			Assert.IsInstanceOfType (typeof(KnownC), aClass);
		}
	}

	public class KnownCProvider : Provider<KnownC>
	{
	    protected override KnownC CreateInstance(IContext context)
	    {
	        var aClass = new KnownC(); // We could do some complex initialisation here.
			return aClass;
	    }
	}
}
