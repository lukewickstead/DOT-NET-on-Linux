using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace AssembliesReflectionSecurity.Security
{
	public class X509Example
	{
		public static bool SignAndVerify (string textToSign)
		{     
			var signedHash = signHash (textToSign);

			return verifyHash (textToSign, signedHash);
		}

		private static byte[] signHash (string text)
		{
			var provider = (RSACryptoServiceProvider)getCertificate ().PrivateKey;     

			var hash = SHA1ManagedExample.HashData (text);     

			return provider.SignHash (hash, CryptoConfig.MapNameToOID ("SHA1")); 
		}

		private static bool verifyHash (string text, byte[] signature)
		{			
			var provider = (RSACryptoServiceProvider)getCertificate ().PublicKey.Key;     

			var hash = SHA1ManagedExample.HashData (text);

			return provider.VerifyHash (hash, CryptoConfig.MapNameToOID ("SHA1"), signature);
		}

		private static X509Certificate2 getCertificate ()
		{
			var my = new X509Store ("storeName", StoreLocation.CurrentUser);

			my.Open (OpenFlags.ReadOnly);		

			return my.Certificates [0];
		}
	}
}