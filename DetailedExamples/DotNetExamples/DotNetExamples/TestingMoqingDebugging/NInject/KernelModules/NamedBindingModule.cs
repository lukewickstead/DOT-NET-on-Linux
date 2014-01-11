using System;
using Ninject;
using Ninject.Modules;

namespace TestingMoqingDebugging.NInject
{
	public class NamedBindingModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IClass>().To<KnownC>().Named("NameknownC");
			Bind<IClass>().To<KnownD>().Named("NameknownD");
		}
	}
}