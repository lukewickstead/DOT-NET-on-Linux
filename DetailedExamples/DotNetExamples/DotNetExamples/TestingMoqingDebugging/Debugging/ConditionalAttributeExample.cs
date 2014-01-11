using System;
using System.Diagnostics;

namespace TestingMoqingDebugging.Debugging
{
	public class ConditionalAttributeExample
	{
		public bool? Hit { get; private set;}

		public ConditionalAttributeExample ()
		{
			Log ();
		}

		[Conditional("DEBUG")] 
		private void Log() 
		{     
			Hit = true;
		}
	}
}