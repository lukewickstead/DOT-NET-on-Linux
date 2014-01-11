using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace MultiThreading.ConcurrentCollections
{
	public class BlockingCollectionExample
	{
		public int Run ()
		{
			var collection = new BlockingCollection<int> ();             

			var taker = Task<int>.Run (() => {                     
				var take = 0;
				while (take < 10) {				
					take = collection.Take ();
				}
				return take;
			});

			var adder = Task.Run (() => {

				for (int x = 0; x <= 10; x++) {
					collection.Add (x);
				}
			});

			adder.Wait ();
			return taker.Result;
		}

		public int ConsumingEnumerablexample ()
		{

			var collection = new BlockingCollection<int> ();             

			var taker = Task<int>.Run (() => {                     
				var take = 0;
				foreach (var aTake in collection.GetConsumingEnumerable()) {
					take = aTake;
				}

				return take;
			});

			var adder = Task.Run (() => {

				for (int x = 0; x <= 10; x++) {
					collection.Add (x);
					System.Threading.Thread.Sleep (1);
				}
				collection.CompleteAdding ();
			});

			Task.WaitAll (taker, adder);
			return taker.Result;
		}
	}
}