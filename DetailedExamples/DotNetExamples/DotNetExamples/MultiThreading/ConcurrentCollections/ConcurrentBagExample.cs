using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace MultiThreading.ConcurrentCollections
{
	public class ConcurrentBag
	{
		public int Count { get; private set; }

		public void Run ()
		{
			var collection = new ConcurrentBag<int> (){ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };         
	
			Action taker = () => {

				int result;
				bool more = true;

				while (more) {
					Thread.Sleep(1);
					more = collection.TryTake (out result);
					if (more && result >= 0) {
						Count++;
					} 	
				}
			};

			var t1 = Task.Run (taker);
			var t2 = Task.Run (taker);

			Task.WaitAll (t1, t2);
		}
	}
}