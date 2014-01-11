using System;
using System.Threading;

namespace MultiThreading.ThreadSynchronization
{
	public class LockRegion
	{
		private System.Object lockControl = new System.Object ();

		public int Counter { get; private set; }

		public LockRegion ()
		{
			var aThread = new Thread (new ThreadStart (OtherThreadMethod));

			aThread.Start ();
			Thread.Sleep (10);

			AMethod ();
		}

		private void AMethod ()
		{
			lock (lockControl) {
				Counter++;
				Thread.Sleep (10);
			}
		}

		void OtherThreadMethod ()
		{
			Thread.Sleep (1);
			AMethod ();
			Thread.Sleep (1);
		}
	}
}