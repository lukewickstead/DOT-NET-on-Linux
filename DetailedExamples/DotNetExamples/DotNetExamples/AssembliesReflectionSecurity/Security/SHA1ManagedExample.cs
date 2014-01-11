using System;
using System.Text;
using System.Security.Cryptography;

namespace AssembliesReflectionSecurity.Security
{
	public class SHA1ManagedExample
	{
		public static byte[] HashData (string text)
		{
			using (var hashAlgorithm = new SHA1Managed ()) {

				var encoding = new UnicodeEncoding ();
				
				return hashAlgorithm.ComputeHash (encoding.GetBytes (text));
			}
		}
	}
}