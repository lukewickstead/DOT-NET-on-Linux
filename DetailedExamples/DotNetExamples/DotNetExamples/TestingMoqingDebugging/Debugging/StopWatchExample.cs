using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace TestingMoqingDebugging.Debugging
{
	public class StopwatchExample
	{
		public static TimeSpan Example ()
		{             

			Stopwatch sw = new Stopwatch ();             
			sw.Start ();             
			sw.Stop ();             
			sw.Reset ();             
			sw.Start ();    
			Thread.Sleep (1);  
			sw.Stop ();                          
			return sw.Elapsed;                          
		}
	}
} 