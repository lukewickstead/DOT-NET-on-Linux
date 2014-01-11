using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace MultiThreading.ThreadSynchronization
{
	[Synchronization] 
	public class SynchronizedClass : ContextBoundObject
	{
		public int Counter { get; set; }
	}

	public class SynchronizedAttributeExample
	{
		public SynchronizedClass SAE = new SynchronizedClass ();

		public void DoBombCounter ()
		{
			var threads = new List<Thread> ();

			for (int x = 0; x < 4; x++) {

				Thread t = new Thread (() => { 
					SAE.Counter++;
					Thread.Sleep (10);
				});

				t.Start ();
				Thread.Sleep (10);
				threads.Add (t);
			}

			foreach (var t in threads) {
				Thread.Sleep (10);
				t.Join ();

			}
		}
	}
}