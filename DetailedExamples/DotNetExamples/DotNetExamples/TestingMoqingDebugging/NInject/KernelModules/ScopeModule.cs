using System;
using Ninject;
using Ninject.Modules;

namespace TestingMoqingDebugging.NInject
{
	public class ScopeModule : NinjectModule
	{
		public override void Load()
		{
			Bind<KnownC>().ToSelf().InSingletonScope();
			Bind<KnownD>().ToSelf().InTransientScope();			 
		}
	}
}