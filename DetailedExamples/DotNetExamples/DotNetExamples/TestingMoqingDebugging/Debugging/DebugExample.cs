using System;
using System.Diagnostics;

namespace TestingMoqingDebugging.Debugging
{
	public class DebugExample
	{
		public static void  Run ()
		{
			Debug.WriteLine("Starting application"); 
			Debug.Indent(); 
			int i = 1 + 2; 
			Debug.Assert(i == 0); 
			Debug.WriteLineIf(i > 0, "i is greater than 0");
			Debug.Fail ("Ohh noo");
		}
	}
}