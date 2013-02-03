using System;

namespace NinjectCheatSheet
{
	public class ChildB : ParentB, IChild 
	{
		public IInject Inject { get; set; }

		public ChildB ( IInject inject)
		{
			Inject = inject;
		}
	}
}

