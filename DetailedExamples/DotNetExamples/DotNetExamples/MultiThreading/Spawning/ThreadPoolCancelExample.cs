using System;
using System.Threading;

namespace MultiThreading.Spawning
{
	public class ThreadPoolCancelExample
	{
		public bool IsSet { get; private set; }

		public ThreadPoolCancelExample ()
		{
			CancellationTokenSource cts = new CancellationTokenSource ();
			ThreadPool.QueueUserWorkItem (new WaitCallback (DoMethod), cts.Token);

			Thread.Sleep (10);
			cts.Cancel ();
			Thread.Sleep (10);
		}

		private void DoMethod (object obj)
		{
			CancellationToken token = (CancellationToken)obj;

			for (int i = 0; i < Int32.MaxValue; i++) {	
				//token.ThrowIfCancellationRequested (); // TODO: Raises RemotingException: Unix transport error.
				if (token.IsCancellationRequested) {
					IsSet = true;
				}		
			}
		}
	}
}