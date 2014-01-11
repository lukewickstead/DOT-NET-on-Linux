using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace MultiThreading.ConcurrentCollections
{
	public class ConcurrentStackExample
	{
		public int Take { get; private set; }

		public void Example ()
		{
			var stack = new ConcurrentStack<int> (); 

			for (var x = 0; x < 10; x++) {
				stack.Push (x);
			}

			Action taker = () => {
				var take = 0;
				while (stack.TryPop (out take)) {			
						Take++;
				}
			};

			var t1 = Task.Run (taker);
			var t2 = Task.Run (taker);

			Task.WaitAll (t1, t2);
		}

		public int ConcurrentStackExampleRange ()
		{
			var stack = new ConcurrentStack<int> (); 

			stack.PushRange (new int[] { 1, 2, 3 }); 
		
			return stack.TryPopRange (new int[2]); 
		}
	}
}