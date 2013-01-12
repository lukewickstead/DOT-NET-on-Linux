using System;
using Ninject;
using Ninject.Modules;

namespace NinjectCheatSheet
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