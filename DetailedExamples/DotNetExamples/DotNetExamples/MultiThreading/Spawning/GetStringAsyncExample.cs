using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultiThreading.Spawning
{
	public class GetStringAsyncExample
	{
		public GetStringAsyncExample ()
		{
		}

		public async Task<string> ReadAsyncHttpRequest ()
		{     
			HttpClient client = new HttpClient ();     
			return await client.GetStringAsync ("http://www.google.com");
		}

		public async Task<string> ExecuteMultipleRequestsInParallel ()
		{     
			HttpClient client = new HttpClient ();     

			Task<string> one = client.GetStringAsync ("http://www.google.co.uk/");     
			Task<string> two = client.GetStringAsync ("http://monodevelop.com/");     

			await Task.WhenAll (one, two); 

			return one.Result + two.Result;
		}
	}
}