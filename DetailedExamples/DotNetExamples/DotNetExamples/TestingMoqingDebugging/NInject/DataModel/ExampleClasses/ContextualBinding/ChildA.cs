using System;

namespace TestingMoqingDebugging.NInject
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