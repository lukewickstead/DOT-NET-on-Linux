using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace MultiThreading.Spawning
{
	public class PLINQExample
	{
		public List<int> WithExtensions ()
		{
			var myData = new List<int> () { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			return myData.AsParallel ().Select (x => x).ToList ();
		}

		public List<int>  WithNatural ()
		{
			var myData = new List<int> () { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			var data =
				(from value in myData.AsParallel ()
				 select value);

			return data.ToList ();
		}

		public List<int> WithDegreeOfParallelism ()
		{
			var myData = new List<int> () { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			return myData.AsParallel ().WithDegreeOfParallelism (2).Select (x => x).ToList ();
		}

		public List<int>  AsOrdered ()
		{
			var myData = new List<int> () { 9, 8, 7, 1, 2, 3, 4, 5, 6 };

			return myData.AsParallel ().Select (x => x).AsOrdered ().ToList ();
		}

		public List<int> AsSequential ()
		{
			var myData = new List<int> () { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

			return myData.AsParallel ().OrderBy (x => x).AsSequential ().Select (x => x).ToList ();
		}

		public List<int> ForAll ()
		{
			var myData = new List<int> () { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			var ints = new List<int> ();

			myData.AsParallel ().ForAll (x => ints.Add (x));

			return ints;
		}

		public List<int> CancellationExtension ()
		{
			var cs = new CancellationTokenSource ();
			var myData = new List<int> () { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			var data = myData.AsParallel ().
			           Select (x => PauseSelect (x)).
				WithCancellation (cs.Token);

			Thread.Sleep (1);
			cs.Cancel ();

			return data.ToList ();
		}

		public List<int>  CancellatioNatural ()
		{
			var cs = new CancellationTokenSource ();
			var myData = new List<int> () { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			var data =
				(from Value in myData.AsParallel ().WithCancellation (cs.Token)
				 select PauseSelect (Value));

			Thread.Sleep (1);
			cs.Cancel ();

			return data.ToList ();
		}

		public List<int> WithExecutionMode ()
		{
			var myData = new List<int> () { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			return myData.AsParallel ().Select (x => x).WithExecutionMode (ParallelExecutionMode.ForceParallelism).ToList ();
		}

		private int PauseSelect (int x)
		{
			Thread.Sleep (100);
			return x;
		}
	}
}