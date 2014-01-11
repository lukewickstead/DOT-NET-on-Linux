using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.ConcurrentCollections
{
	public class ConcurrentDictionaryExample
	{
		public int Result;

		public void  Run ()
		{
			var dict = new ConcurrentDictionary<string, int> (StringComparer.InvariantCultureIgnoreCase);

			Action adder = () => {

				for (var x = 0; x < 10; x++) {
					dict.TryAdd (x.ToString (), x);
				}

				for (var x = 0; x < 10; x++) {
					dict.TryUpdate (x.ToString (), x * x, x);
				}

			};
		
			var t1 = Task.Run (adder);
			var t2 = Task.Run (adder);

			Task.WaitAll (t1, t2);

			Result = dict.Values.Sum (x => x);
		}

		public void AddOrUpdate ()
		{
			var dict = new ConcurrentDictionary<string, int> (StringComparer.InvariantCultureIgnoreCase);

			Func<string,int> addFunc = (x) => int.Parse (x);
			Func<string,int, int> updateFunc = (x, y) => y * 2;

			foreach (var x in new int[]{1,2,3}) {
				foreach (var y in new int[]{1,2}) {
					dict.AddOrUpdate (x.ToString (), addFunc, updateFunc);
				}
			}

			Result = dict.Values.Sum (x => x);
		}

		public void GetOrAdd ()
		{
			var dict = new ConcurrentDictionary<string, int> (StringComparer.InvariantCultureIgnoreCase);

			foreach (var x in new int[]{1,2,3}) {
				foreach (var y in new int[]{1,2}) {
					dict.GetOrAdd (x.ToString (), (aVal) => int.Parse (aVal) * 2);
				}
			}

			Result = dict.Values.Sum (x => x);
		}
	}
}