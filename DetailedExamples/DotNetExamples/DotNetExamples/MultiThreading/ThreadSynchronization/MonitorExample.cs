using System;
using System.Threading;

namespace MultiThreading.ThreadSynchronization
{
	public class MonitorExample
	{
		private Object lockControl = new Object ();

		public int Counter { get; private set; }

		public void EnterExample ()
		{
			var aThread = new Thread (new ThreadStart (DoEnter));
			aThread.Start ();

			Thread.Sleep (1);
			DoEnter ();
			Thread.Sleep (1);
		}

		void DoEnter ()
		{
			try {
				Monitor.Enter (lockControl);
				try {
					Thread.Sleep (100);
					Counter++;
				} finally {
					Monitor.Exit (lockControl);
				}
			} catch (SynchronizationLockException ex) {
				throw ex;
			}
		}

		void DoTryEnter ()
		{
			if (Monitor.TryEnter (lockControl, 1)) {
				try {
					Thread.Sleep (200);
					Counter++;
				} finally {
					Monitor.Exit (lockControl);
				}
			} else {
				throw new SynchronizationLockException ();
			}
		}

		public void TryEnterExampple ()
		{
			var aThread = new Thread (new ThreadStart (DoEnter));
			aThread.Start ();
			DoTryEnter ();
		}
	}
}