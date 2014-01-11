using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Spawning
{
	public class TaskExample
	{
		public bool IsSet { get; private set; }

		public bool IsContinueSet { get; private set; }

		public void StartNew ()
		{
			Task.Factory.StartNew (() => {
				/* Do Something */
				IsSet = true;
			});  

			Thread.Sleep (1);
		}

		public void StartAndWait ()
		{
			var aTask = new Task (() => {
				/* Do Something */
				IsSet = true;
			});

			aTask.Start ();
			aTask.Wait ();
		}

		public void RunSynchronously ()
		{
			var aTask = new Task (() => {
				/* Do Something */
				IsSet = true;
				Thread.Sleep (1);
			});

			aTask.RunSynchronously ();
		}

		public bool Result ()
		{
			var aTask = new Task<bool> (() => {
				Thread.Sleep (10);
				IsSet = true;
				return true;
			});

			aTask.Start ();
			Thread.Sleep (1);
			aTask.Wait ();

			return aTask.Result;
		}

		public bool ContinuationTask ()
		{
			Task<bool> t = Task.Run (() => {
				IsSet = true;
				return true;
			}).ContinueWith ((x) => {
				IsContinueSet = true;
				return !x.Result;
			}); 

			return t.Result;
		}

		public string ContinuationTaskAgain ()
		{
			Task<string> t = Task.Run (() => {
				IsSet = true;
				return "Nothing";
			}); 

			t.ContinueWith ((i) => {
				return "OnlyOnCanceled";
			}, TaskContinuationOptions.OnlyOnCanceled); 

			t.ContinueWith ((i) => {
				return "OnlyOnFaulted";
			}, TaskContinuationOptions.OnlyOnFaulted); 

			t = t.ContinueWith ((i) => {
				return "OnlyOnRanToCompletion";
			}, TaskContinuationOptions.OnlyOnRanToCompletion); 

			return t.Result;
		}

		public int ChildTasks ()
		{
			Task<int[]> parent = Task.Run (() => {
				var results = new int[2]; 
				new Task (() => results [0] = 1,                     
					TaskCreationOptions.AttachedToParent).Start ();                 
				new Task (() => results [1] = 2, 
					TaskCreationOptions.AttachedToParent).Start ();			           
				return results;
			});             

			Thread.Sleep (1);

			var finalTask = parent.ContinueWith (
				                parentTask => {

					var count = 0;
					foreach (int i in parentTask.Result) {
						count += i;
					}
					return count;              
				});  

			finalTask.Wait ();   	
			return finalTask.Result;		      
		}

		public int TaskFactory ()
		{

			Task<int[]> parent = Task.Run (() => {

				var results = new int[2];                   

				TaskFactory tf = new TaskFactory (
					                 TaskCreationOptions.AttachedToParent,                    
					                 TaskContinuationOptions.ExecuteSynchronously);                 

				Task t1 = tf.StartNew (() => results [0] = 1);                 
				Task t2 = tf.StartNew (() => results [1] = 2);    
				       
				Thread.Sleep(1);
				Task.WaitAll(t1, t2);   
				return results;
			});               

			Thread.Sleep (1);

			var finalTask = parent.ContinueWith (
				                parentTask => { 
					var count = 0;
					foreach (int i in parentTask.Result) {
						count += i;
					}

					return count;                
				});

			finalTask.Wait ();
			return finalTask.Result;		 
		}

		public int WaitAll ()
		{

			var tasks = new Task<int>[3];         // Synch    
			tasks [0] = Task.Run (() => {
				return 1;
			});             

			tasks [1] = Task.Run (() => { 
				return 2;
			}); 

			tasks [2] = Task.Run (() => {
				return 3;
			}
			);

			Task.WaitAll (tasks);	

			int count = 0;

			foreach (var t in tasks) {
				count += t.Result;
			}

			return count;				 			 
		}

		public int WaitAny ()
		{

			Task<int>[] tasks = new Task<int>[3];

			tasks [0] = Task.Run (() => {
				Thread.Sleep (10);
				return 1;
			});

			tasks [1] = Task.Run (() => {
				Thread.Sleep (20);
				return 2;
			});

			tasks [2] = Task.Run (() => {
				Thread.Sleep (30);
				return 3;
			});

			int result = 0;

			while (result < 6) { 
				int i = Task.WaitAny (tasks);
				var completedTask = tasks [i];                 

				result += completedTask.Result;

				var taskList = tasks.ToList ();
				taskList.RemoveAt (i);

				tasks = taskList.ToArray ();
			} 

			return result;
		}

		public int WhenAll ()
		{

			var tasks = new Task<int>[3];

			tasks [0] = Task.Run (() => {
			
				Thread.Sleep (10);
				return 1;
			});

			tasks [1] = Task.Run (() => {
				Thread.Sleep (20);
				return 2;
			});

			tasks [2] = Task.Run (() => {
				Thread.Sleep (30);
				return 3;
			});

			int result = 0;
			var completionTask = Task.WhenAll (tasks);

			var sumTask = completionTask.ContinueWith (x => result += x.Result.Sum (y => y));	
	
			sumTask.Wait ();
			//Thread.Sleep (1);
			return result;
		}

		public int TimingOutATask ()
		{
			var longRunning = Task.Run (() => {
				Thread.Sleep (10000);
				return 1;
			}); 

			Task.WaitAny (new[] { longRunning }, 10); 

			var result = 0;

			if (longRunning.IsCompleted)
				result += longRunning.Result;

			return result;
		}

		public bool CancellingATask ()
		{
			var cts = new CancellationTokenSource ();
			var token = cts.Token;
			var isCancelled = false;

			Task.Run (() => {

				Thread.Sleep (10);

				while (true) {
					cts.Token.ThrowIfCancellationRequested ();
					Thread.Sleep (10);
				}					   
			}, token).ContinueWith ((t) => { 
				isCancelled = true;
			}, TaskContinuationOptions.OnlyOnCanceled);

			Thread.Sleep (10);     

			cts.Cancel ();
			Thread.Sleep (10);     
			Thread.Sleep (10);     

			return isCancelled;	
		}
	}
}