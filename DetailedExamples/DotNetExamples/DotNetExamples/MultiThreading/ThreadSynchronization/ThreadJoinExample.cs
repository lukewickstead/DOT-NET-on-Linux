using System;
using System.Threading;

namespace MultiThreading.ThreadSynchronization
{
	public class ThreadJoinExample
	{
		public int Counter { get; private set; }

		public ThreadJoinExample ()
		{
			Thread t1 = new Thread (() => { 
				Counter++;
				Thread.Sleep (1);
			});

			Thread t2 = new Thread (() => { 
				Counter++;
				Thread.Sleep (2);
			});

			t1.Start ();
			t2.Start ();

			t1.Join ();
			t2.Join ();
		}
	}
}