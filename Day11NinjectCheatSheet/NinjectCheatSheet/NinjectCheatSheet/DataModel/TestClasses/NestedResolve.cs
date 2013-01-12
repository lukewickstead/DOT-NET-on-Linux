using System;
using Ninject;

namespace NinjectCheatSheet
{
	public class Outter
	{
		[Inject]
		public Middle PropertyInject{ get; set; }

		public Middle ConstructorArgInject { get; set; }

		public Outter (Middle middle)
		{
			ConstructorArgInject = middle;
		}
	}

	public class Middle
	{
		[Inject]
		public Inner PropertyInject{ get; set; }

		public Inner ConstructorArgInject { get; set; }

		public Middle (Inner middle)
		{
			ConstructorArgInject = middle;
		}
	}

	public class Inner
	{
	}
}

