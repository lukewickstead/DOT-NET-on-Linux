using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.ThreadSynchronization
{
	public class ThreadStaticLocalExample
	{
		[ThreadStatic] static int previous = 0;

		public int DoThreadStatic ()
		{
			for (int x = 0; x < 10; x++) {

				Thread.Sleep (1);
				Thread t = new Thread (() => { 
					previous += 1;
				});

				t.Start ();

				Thread.Sleep (1);
			}

			Thread.Sleep (10);
			return previous;
		}

		public int DoThreadLocal ()
		{
			var threadLocal = new ThreadLocal<int> (() => {
				return 0;
			});

			for (int x = 0; x < 10; x++) {
				Thread t = new Thread (() => { 
					threadLocal.Value += 1;
				});

				t.Start ();
				Thread.Sleep (1);
			}

			Thread.Sleep (10);

			var isIsValueCreated = threadLocal.IsValueCreated;
			return threadLocal.Value;
		}
	}
}