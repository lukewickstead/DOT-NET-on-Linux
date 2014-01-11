using System;
using System.Text;
using System.Security.Cryptography;

namespace AssembliesReflectionSecurity.Security
{
	public class SHA256Example
	{
		public static byte[] Hash (string data)
		{
			UnicodeEncoding byteConverter = new UnicodeEncoding (); 

			using (var sha256 = SHA256.Create ()) {
				return sha256.ComputeHash (byteConverter.GetBytes (data)); 
			} 						
		}
	}
}