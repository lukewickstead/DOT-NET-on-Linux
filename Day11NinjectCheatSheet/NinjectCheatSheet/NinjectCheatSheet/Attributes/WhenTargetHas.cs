using System;
using Ninject;
using Ninject.Planning.Bindings;

namespace NinjectCheatSheet
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, 
	                AllowMultiple = true, Inherited = true)]
	public class WhenTargetHas : Attribute
	{
	}
}

