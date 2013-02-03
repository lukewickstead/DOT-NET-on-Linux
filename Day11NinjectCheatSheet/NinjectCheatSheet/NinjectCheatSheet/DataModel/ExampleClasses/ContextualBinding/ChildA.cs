using System;

namespace NinjectCheatSheet
{
	public class ChildA : ParentA, IChild
	{
		public IInject Inject { get; set; }

		public ChildA ( IInject inject  )
		{
			Inject = inject;
		}
	}
}

