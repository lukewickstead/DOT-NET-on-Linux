using System;
using System.Threading;

namespace MultiThreading.ThreadSynchronization
{
	public class InterlockedExample
	{

		public int Locksync;
		public int ANumber;
		public int UsingResource;

		public InterlockedExample ()
		{
			var aThread = new Thread (new ThreadStart (OtherThreadMethod));
			aThread.Start ();

			Interlocked.Increment (ref ANumber);
			Interlocked.Decrement (ref ANumber);
			Interlocked.Add (ref ANumber, 10);
			Interlocked.Exchange (ref UsingResource, 1);

			if (Interlocked.Exchange (ref UsingResource, 1) == 0) { 	
				// unlock by setting back to 0
				Interlocked.Exchange (ref UsingResource, 0); 
			}		

			Thread.Sleep (100);
		}

		void OtherThreadMethod ()
		{
			Interlocked.Increment (ref ANumber);
			Interlocked.Decrement (ref ANumber);
			Interlocked.Add (ref ANumber, 10);
			Interlocked.Exchange (ref UsingResource, 1);

			if (Interlocked.Exchange (ref UsingResource, 1) == 0) { 	
				// unlock by setting back to 0
				Interlocked.Exchange (ref UsingResource, 0); 
			}		

		}
	}
}

