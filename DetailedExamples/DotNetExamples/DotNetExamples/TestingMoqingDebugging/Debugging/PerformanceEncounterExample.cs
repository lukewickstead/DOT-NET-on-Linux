using System;
using System.Diagnostics;

namespace TestingMoqingDebugging.Debugging
{
	public class PerformanceEncounterCustomExample
	{
		public PerformanceEncounterCustomExample ()
		{	
			InitCounters ();
		}

		public void WriteCounters ()
		{
			using (var hitCounter = new PerformanceCounter ("Category", "Hits")) {
				using (var rateCounter = new PerformanceCounter ("Category", "Rate")) {
					for (var x = 0; x < 5; x++) {
						hitCounter.Increment ();
						rateCounter.IncrementBy (x + 10);
					}
				}
			}
		}

		public void ReadCounters (out long hit, out long rate)
		{
			using (var hitCounter = new PerformanceCounter ("Category", "Hits")) {
				hit = hitCounter.RawValue;
			}

			using (var rateCounter = new PerformanceCounter ("Category", "Rate")) {
				rate = rateCounter.RawValue;
			}			
		}

		private void InitCounters ()
		{
			if (PerformanceCounterCategory.Exists ("Category")) {
				return;
			}

			var counters = new CounterCreationDataCollection {
				new CounterCreationData ("Hits", "Total hits", PerformanceCounterType.NumberOfItems32),
				new CounterCreationData ("Rate", "Hits per second", PerformanceCounterType.RateOfCountsPerSecond32)
			};

			PerformanceCounterCategory.Create ("Category", "Example Counter", PerformanceCounterCategoryType.SingleInstance, counters);
		}
	}
}