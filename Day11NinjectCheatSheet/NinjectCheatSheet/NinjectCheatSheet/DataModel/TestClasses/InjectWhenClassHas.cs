using System;
using Ninject;

namespace NinjectCheatSheet
{
	[WhenClassHas]	
	public class InjectWhenClassHas
	{
		[Inject]
		public IClass WhenClassHas { get; set; }
	}
}

