using System;
using Ninject;
using Ninject.Modules;

namespace NinjectCheatSheet
{
	public class MultipleConstructorModule : NinjectModule
	{
		public override void Load()
		{
			Bind<KnownC>().ToSelf();
			Bind<KnownD>().ToSelf();
			//Bind<KnownC>().To(KnownD);			 
		}
	}
}