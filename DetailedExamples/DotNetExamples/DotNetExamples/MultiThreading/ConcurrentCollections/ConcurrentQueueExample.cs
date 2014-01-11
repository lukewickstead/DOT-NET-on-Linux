using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace MultiThreading.ConcurrentCollections
{
	public class ConcurrentQueueExample
	{
		public int Put { get; private set; }

		public int Take { get; private set; }

		public void Run ()
		{
			var queue = new ConcurrentQueue<int> (); 

			for (var x = 0; x < 10; x++) {
				queue.Enqueue (x); 
				Put++;
			}

			Action taker = () => {
				var take = 0;
				while (queue.TryDequeue (out take)) {
					Take++;
				}
			};

			var t1 = Task.Run (taker);
			var t2 = Task.Run (taker);

			Task.WaitAll (t1, t2);
		}
	}
}