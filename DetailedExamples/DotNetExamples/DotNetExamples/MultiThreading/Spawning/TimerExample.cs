using System;
using System.Threading;

namespace MultiThreading.Spawning
{
	public class TimerExample
	{
		public int Count { get; private set; }

		public TimerExample ()
		{
			using (var t = new Timer (new TimerCallback (MyMethod), new object (), 2, 1)) {
				Thread.Sleep (1);
			} 
		}

		private void MyMethod (object obj)
		{
			Count++;
		}
	}
}