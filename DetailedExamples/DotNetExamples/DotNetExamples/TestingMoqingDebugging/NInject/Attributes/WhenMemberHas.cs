using System;
using Ninject;
using Ninject.Planning.Bindings;

namespace TestingMoqingDebugging.NInject
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, 
	                AllowMultiple = true, Inherited = true)]
	public class WhenMemberHas : Attribute
	{
	}
}

