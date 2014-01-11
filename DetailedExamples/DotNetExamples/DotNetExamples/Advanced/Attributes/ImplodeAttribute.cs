using System;

namespace Advanced.Attributes
{
	[AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method, Inherited = false)] 
	public class ImplodeAttribute : Attribute
	{
		public bool Big { get; private set;}
		public bool Now { get; private set;}

		public ImplodeAttribute (bool big, bool now)
		{
			this.Big = big;
			this.Now = now;
		}		
	}
}