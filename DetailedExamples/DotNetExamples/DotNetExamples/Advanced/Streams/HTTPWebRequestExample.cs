using System;
using System.IO;
using System.Net;

namespace Advanced.Streams
{
	public class HTTPWebRequestExample
	{
		public static string Get (string aURL)
		{
			WebRequest webRequest = WebRequest.Create (aURL); 

			using (WebResponse webResponse = webRequest.GetResponse ()) {
				using (StreamReader streamReader = new StreamReader (webResponse.GetResponseStream ())) {
					return streamReader.ReadToEnd (); 
				}
			}
		}
	}
}