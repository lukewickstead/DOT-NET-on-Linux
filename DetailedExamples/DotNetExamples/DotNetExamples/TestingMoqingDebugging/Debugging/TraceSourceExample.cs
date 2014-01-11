#define TRACE // TODO: Synch

using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace TestingMoqingDebugging.Debugging
{
	public class TraceSourceExample
	{
		public string FilePath { get; private set; }

		private TraceSource TraceSource;

		public TraceSourceExample ()
		{
			FilePath = Path.GetTempFileName ();

			TraceSource = new TraceSource ("Source", SourceLevels.Information); 
			TraceSource.Listeners.Clear (); 
			TraceSource.Listeners.Add (new TextWriterTraceListener (FilePath));
		}

		public void Example ()
		{
			TraceSource.TraceInformation ("Adding a trace"); 
			
			TraceSource.TraceEvent (TraceEventType.Critical, 1, "Critical trace"); 
			TraceSource.TraceEvent (TraceEventType.Information, 1, "Critical trace"); 
			TraceSource.TraceEvent (TraceEventType.Error, 1, "Critical trace"); 

			TraceSource.TraceData (TraceEventType.Information, 1, new object[] { 1, 2, 3 }); 

			TraceSource.Flush (); 
			TraceSource.Close (); 
		}

		public List<string> ReadFile ()
		{
			return File.ReadLines (FilePath).ToList ();
		}
	}
}