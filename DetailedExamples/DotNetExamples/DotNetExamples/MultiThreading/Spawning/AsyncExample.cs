using System;
using System.Threading;
using System.Threading.Tasks;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning
{
	public class AsyncExample
	{
		public bool IsSet { get; private set; }

		public async Task<bool> RunWithReturn ()
		{
			//Task<bool> t = TaskWithReturn ();
			return await TaskWithReturn ();
		}

		public async Task RunNoReturn ()
		{
			//Task t = TaskNoReturn ();
			await TaskNoReturn ();
		}

		private Task<bool>  TaskWithReturn ()
		{
			var t = new Task<bool> (() => {
				Thread.Sleep (1);
				return true;
			});

			t.Start ();
			return t;
		}

		private Task TaskNoReturn ()
		{
			var t = new Task (() => {
				Thread.Sleep (1);
				IsSet = true;

			});

			t.Start ();
			return t;
		}
	}
}