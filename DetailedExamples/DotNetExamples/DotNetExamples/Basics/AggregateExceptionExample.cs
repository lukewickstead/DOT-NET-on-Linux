using System;
using System.Collections.Generic;

public class AggregateExceptionExample
{
	public delegate void ADelegate ();

	public void ThrowException ()
	{
		throw new Exception ();
	}

	public void TheThrowPart ()
	{	

		ADelegate handler = new ADelegate (ThrowException);
		handler += new ADelegate (ThrowException);

		List<Exception> exceptions = null;

		foreach (var d in handler.GetInvocationList()) { 
			try { 
				// DoSomething….
			} catch (Exception exc) { 
				if (exceptions == null)
					exceptions = new List<Exception> ();
				exceptions.Add (exc);
			} 
		} 

		if (exceptions != null)
			throw new AggregateException (exceptions);
	}

	public void TheCatchPart ()
	{
		try {
			TheThrowPart ();
			// do something..  
		} catch (AggregateException ae) {
			foreach (var ex in ae.InnerExceptions) {
				// do something….
			}
		}

	}
}
