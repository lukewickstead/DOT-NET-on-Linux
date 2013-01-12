using System;
using Ninject;
using Ninject.Planning.Bindings;

namespace NinjectCheatSheet
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, 
	                AllowMultiple = true, Inherited = true)]
	public class IsNotSomething : ConstraintAttribute
	{
		public override bool Matches (IBindingMetadata metadata)
		{
			return metadata.Has ("IsSomething") && !metadata.Get<bool> ("IsSomething");
		}
	}
}

