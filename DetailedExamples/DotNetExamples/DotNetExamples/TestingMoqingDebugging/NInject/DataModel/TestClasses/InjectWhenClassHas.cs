using System;
using Ninject;

namespace TestingMoqingDebugging.NInject
{
	[WhenClassHas]	
	public class InjectWhenClassHas
	{
		[Inject]
		public IClass WhenClassHas { get; set; }
	}
}

