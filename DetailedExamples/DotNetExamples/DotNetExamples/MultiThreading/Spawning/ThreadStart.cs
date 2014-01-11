using System;
using System.Threading;

namespace MultiThreading.Spawning
{
	public class ThreadStartExample
	{
		public bool IsSet { get; private set; }

		public ThreadStartExample ()
		{
			var aThread = new Thread (new ThreadStart (MyMethod)) {
				Name = "My Thread",     
				Priority = ThreadPriority.Highest
			};      
	
			aThread.Start ();
			aThread.Join ();
		}

		private void MyMethod ()
		{
			IsSet = true;
		}
	}
}