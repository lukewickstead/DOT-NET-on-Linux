using System;
using Ninject;

namespace NinjectCheatSheet
{
	public class InjectWithIsSomething
	{
		public IClass InjectedClass{ get; set; }

		public InjectWithIsSomething([IsSomething] IClass aClass)
		{
			InjectedClass = aClass;
		}
	}	
}
