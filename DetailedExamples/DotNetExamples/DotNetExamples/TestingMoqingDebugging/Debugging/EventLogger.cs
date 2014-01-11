using System;
using System.Threading;
using System.Diagnostics;

namespace TestingMoqingDebugging.Debugging
{
	// MONO EventLog: 
	// To enable please see
	// http://lukewickstead.wordpress.com/2014/01/04/set-up-enable-the-event-log-under-mono-gnulinux/
	public class EventLogSample
	{
		public static string Source = "TestSource";

		public bool Hit { get; private set; }

		public EventLogSample ()
		{
			if (!EventLog.SourceExists (Source)) {             
				EventLog.CreateEventSource (Source, "NewLog");             
			}
		}

		public void Subscribe ()
		{
			EventLog log = new EventLog ("NewLog", ".", Source);         
			log.EntryWritten += (sender, e) => {             
				Hit = true; 
			};        

			log.EnableRaisingEvents = true;
			Thread.Sleep (1);        
			log.WriteEntry ("The Message", EventLogEntryType.Error); 
		}

		public void Write ()
		{
			EventLog log = new EventLog ("NewLog", ".", Source);    
			log.WriteEntry ("The Message", EventLogEntryType.Error); 
		}

		public string Read ()
		{
			EventLog log = new EventLog ("NewLog", ".", Source);
	
			foreach (EventLogEntry entry in log.Entries) {
				var aString = entry.Message;
			}    
			EventLogEntry lastLog = log.Entries [log.Entries.Count - 1]; 

			return string.Format ("Index: {0}, Source: {1}, Type: {2}, Time: {3}, Message: {4}",
				lastLog.Index, lastLog.Source, lastLog.EntryType, lastLog.TimeWritten, lastLog.Message);
		}
	}
}