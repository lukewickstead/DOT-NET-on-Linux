using System;

public class DisposableClass : IDisposable
{
	private bool disposed = false;

	protected virtual void Dispose (bool disposing)
	{
		if (!disposed) {
			if (disposing) {
				// Clear up here.
			}

			disposed = true;
		}
	}

	public void Dispose ()
	{
		Dispose (true);
		GC.SuppressFinalize (this);
	}

	~DisposableClass ()
	{
		Dispose (false);
	}
}