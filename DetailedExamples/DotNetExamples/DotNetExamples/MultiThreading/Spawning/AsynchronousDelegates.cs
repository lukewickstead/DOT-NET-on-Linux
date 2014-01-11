using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace MultiThreading.Spawning
{
	public class AsynchronousDelegatesExamples
	{
		delegate bool AnAction (bool paramA, int param2);

		public bool CallBackCalled { get; private set; }

		public bool IsCompleted ()
		{
			var d = new AnAction (DoAction);   

			IAsyncResult ar = d.BeginInvoke (true, 1, null, null);   

			do {  
				Thread.Sleep (10);
			} while(!ar.IsCompleted);   

			return d.EndInvoke (ar);
		}

		public bool AsyncWaitHandle ()
		{
			var d = new AnAction (DoAction);  

			IAsyncResult ar = d.BeginInvoke (true, 1, null, null);   

			do {
			} while (!ar.AsyncWaitHandle.WaitOne (10, true));

			return d.EndInvoke (ar);
		}

		public bool AsyncCallbackWithState ()
		{
			var d = new AnAction (DoAction);  

			var ar = d.BeginInvoke (true, 10, 
				         new AsyncCallback (MyCallback), 
				         new object ());

			do {  
				Thread.Sleep (10);
			} while(!ar.IsCompleted && !CallBackCalled);  

			return true;
		}

		public void MyCallback (IAsyncResult iar)
		{   
			AsyncResult ar = (AsyncResult)iar;   

			var d = (AnAction)ar.AsyncDelegate;
			var obj = (object)ar.AsyncState;

			CallBackCalled = d.EndInvoke (ar);
		}

		public bool DoAction (bool paramA, int param2)
		{
			return true;
		}
	}
}

