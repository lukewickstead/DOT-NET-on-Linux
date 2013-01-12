using System;
using Ninject;

namespace NinjectCheatSheet
{
	public class PropertyAndMethodInjectionExample
	{
		public bool IsMethodInjected { get; private set; }
		public bool IsPropertyInjected { get; private set; }

		public PropertyAndMethodInjectionExample ()
		{
		}

		[Inject]
		public void InjectionMethod( KnownC c )
		{
			IsMethodInjected = true;
		}


		[Inject]
		public KnownC InjectionProperty
		{
			set { IsPropertyInjected = true; }
		}
	}
}

