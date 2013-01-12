using System;
using Ninject.Modules;

namespace NinjectCheatSheet
{
	public class DerrivedAtrributeModule  : NinjectModule
	{
		public override void Load()
		{
			Bind<IClass>().To<KnownC>().WhenClassHas<WhenClassHas>();
			Bind<IClass>().To<KnownD>().WhenTargetHas<WhenTargetHas>();
			Bind<IClass>().To<KnownE>().WhenMemberHas<WhenMemberHas>();
		}
	}
}

