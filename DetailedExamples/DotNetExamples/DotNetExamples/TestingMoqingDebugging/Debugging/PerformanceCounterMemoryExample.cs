using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace TestingMoqingDebugging.Debugging
{
	public class PerformanceCounterMemoryExample
	{
		public static List<float> Example ()
		{
			var data = new List<float> ();

			// Various counters exist; little overlap between .NET and Mono
			// .NET: http://msdn.microsoft.com/en-us/library/w8f5kw2e(v=vs.110).aspx
			// MONO: http://www.mono-project.com/Mono_Performance_Counters

			using (var pCounter = new PerformanceCounter ("Mono Memory", "Total Physical Memory")) {
				for (var x = 0; x < 1000; x++) {
					data.Add (pCounter.NextValue ());
				}
			}

			return data;
		}
	}
}