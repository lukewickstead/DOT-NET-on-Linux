using System;
using Ninject;

namespace NinjectCheatSheet
{
	public class InjectWhenMemberAndTargetHas
	{
		[Inject, WhenMemberHas]
		public IClass WhenMemberHas { get; set; }

		public IClass WhenTargetHas { get; set; }

		public InjectWhenMemberAndTargetHas([WhenTargetHas] IClass aClass)
		{
			WhenTargetHas = aClass;
		}
	}
}

