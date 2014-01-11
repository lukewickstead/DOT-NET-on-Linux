using System;
using System.Threading;

namespace MultiThreading.Spawning
{
	public class ThreadPoolExample
	{
		public bool IsSet { get ; private set; }

		public ThreadPoolExample ()
		{
			var wcb = new WaitCallback (DoMethod);     

			ThreadPool.QueueUserWorkItem (wcb, new object ());  

			while(!IsSet)
			{
				Thread.Sleep (25);
			}
		}

		private void DoMethod (object obj)
		{
			IsSet = true;
		}
	}
}