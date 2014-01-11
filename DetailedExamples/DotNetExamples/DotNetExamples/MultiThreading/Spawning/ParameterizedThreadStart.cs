using System;
using System.Threading;

namespace MultiThreading.Spawning
{
	public class ParameterizedThreadStartExample
	{
		public bool IsSet { get; private set; }

		public ParameterizedThreadStartExample ()
		{
			var aThread = new Thread (new ParameterizedThreadStart (MyMethod)) {
				Name = "My Thread",     
				Priority = ThreadPriority.Highest
			};      

			aThread.Start (new object ());
		}

		private void MyMethod (object foo)
		{
			IsSet = true;
		}
	}
}