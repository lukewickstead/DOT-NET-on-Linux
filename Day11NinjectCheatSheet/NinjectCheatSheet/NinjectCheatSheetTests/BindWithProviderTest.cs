using System;
using Ninject;
using NinjectCheatSheet;
using Ninject.Activation;
using NUnit.Framework;
namespace NinjectCheatSheetTests
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

			Assert.That(aClass, Is.InstanceOf<IClass>());
			Assert.That(aClass, Is.InstanceOf<KnownC>());
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
