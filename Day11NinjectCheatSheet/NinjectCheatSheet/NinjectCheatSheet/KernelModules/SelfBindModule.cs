using System;
using Ninject;
using Ninject.Modules;

namespace NinjectCheatSheet
{
	public class SelfBindModule : NinjectModule
	{
		public override void Load()
		{
			Bind<SelfBindExample>().ToSelf();
		}
	}
}