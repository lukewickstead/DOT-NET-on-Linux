using System;
using Ninject;

namespace TestingMoqingDebugging.NInject
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
