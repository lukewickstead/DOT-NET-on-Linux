using System;

namespace Advanced.Attributes
{
	[Serializable] 
	[Implode (true, false)]
	public class AnnotatedClass
	{
		[NonSerialized, Obsolete ("Don’t go there!!")] 
		public string AProperty;
		[NonSerialized] [Obsolete ("Don’t go there!!")] 
		public string AnotherProperty;

		[Obsolete ("Don’t go there!!")] 
		public void MyMethod ()
		{
		}

		[Implode (true, false)]
		public void TheMethod ()
		{
			// Attributes are simply classes; you invoke constructors on them.
			// Named parameters and object initializers can be used.
		}
	}
}