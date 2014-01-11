using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MultiThreading.Spawning
{
	public class ParallelExample
	{
		public int count { get; private set; }

		public void ForEach ()
		{
			Parallel.ForEach (new List<int> () { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, anElement => { 
				/*Some Process */ 
				//Thread.Sleep (1);
				count++;
			});
		}

		public void For ()
		{
			Parallel.For (0, 10, i => { 
				//Thread.Sleep (1);
				count++;
				/* Some Process */ 
			});
		}

		public void Stop ()
		{
			Parallel.For (0, Int32.MaxValue, (i, loopState) => { 
			
				count++;
				Thread.Sleep(1);

				if (i > 10) {
					loopState.Stop ();
				}
				/*Some Process */ 
			});
		}

		public void Break ()
		{
			Parallel.For (0, Int32.MaxValue, (i, loopState) => { 

				Thread.Sleep (1);
				count++;
				if (i > 10) {
					loopState.Stop ();
				}
				/* Some Process */ 
			});
		}

		public void Invoke ()
		{
			Parallel.Invoke (
				() => { /* Do something #1 */
					//Thread.Sleep (1);
					count++;
				}, 
				() => { /* Do something #2 */
					//Thread.Sleep (1);
					count++;
				}, 
				() => { /* Do something #3 */	
					//Thread.Sleep (1);
					count++;
				}, 
				() => { /* o something #4  */
					//Thread.Sleep (1);
					count++;
				});

			Thread.Sleep (25);
		}
	}
}