using System;
using Ninject;

namespace NinjectCheatSheet
{
	public class InjectWithIsNotSomething
	{
		public IClass InjectedClass{ get; set; }

		public InjectWithIsNotSomething([IsNotSomething] IClass aClass)
		{
			InjectedClass = aClass;
		}
	}	
}
