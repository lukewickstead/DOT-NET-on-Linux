using System;
using System.Threading;

namespace MultiThreading.ThreadSynchronization
{
	public class AutoResetEventExample
	{
		public int Counter { get; private set; }

		private AutoResetEvent autoResetEvent = new AutoResetEvent (false);

		public AutoResetEventExample ()
		{
			var aThread = new Thread (new ThreadStart (OtherThreadMethod));

			aThread.Start ();

			autoResetEvent.Set ();		
			Thread.Sleep (1);

			autoResetEvent.Set ();
			Thread.Sleep (1);
		}

		void OtherThreadMethod ()
		{
			Counter++;
			autoResetEvent.WaitOne (); // pauses until set is called by main thread
			Counter++;
			autoResetEvent.WaitOne ();
			Counter++;
		}
	}
}