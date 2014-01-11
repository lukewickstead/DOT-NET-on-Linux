using System;
using System.Threading;

namespace MultiThreading.Spawning
{
	public class ParameterizedThreadStartCancelExample
	{
		public bool IsCancelled { get; private set; }

		public ParameterizedThreadStartCancelExample ()
		{
			var cts = new CancellationTokenSource ();

			var aThread = new Thread (new ParameterizedThreadStart (MyMethod)) {
				Name = "My Thread",     
				Priority = ThreadPriority.Highest
			};      


			aThread.Start (cts.Token);
			Thread.Sleep (10);

			cts.Cancel ();
			Thread.Sleep (10);
			Thread.Sleep (10);
		}

		private void MyMethod (object obj)
		{
			Thread.Sleep (10);

			CancellationToken token = (CancellationToken)obj;

			for (int i = 0; i < Int32.MaxValue; i++) {	

				Thread.Sleep (10);

				//token.ThrowIfCancellationRequested ();
				if (token.IsCancellationRequested) {
					//	throw new OperationCanceledException (token);
					IsCancelled = true;
					return;
				}
			}
		}
	}
}