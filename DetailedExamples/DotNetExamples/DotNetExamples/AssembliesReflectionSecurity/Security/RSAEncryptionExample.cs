using System;
using System.Text;
using System.Security.Cryptography;

namespace AssembliesReflectionSecurity.Security
{
public class RSAEncryptionExample : IDisposable
{
	UnicodeEncoding ByteConverter = new UnicodeEncoding ();
	RSACryptoServiceProvider rsa = new RSACryptoServiceProvider ();

	public string CreateKey (bool includePrivate)
	{
		return rsa.ToXmlString (includePrivate);
	}

	public byte[] Encrypt (string data)
	{
		byte[] dataToEncrypt = ByteConverter.GetBytes (data); 

		rsa.FromXmlString (CreateKey (false));
		     
		return rsa.Encrypt (dataToEncrypt, false); 
	}

	public string Decrypt (byte[] data)
	{
		byte[] decryptedData; 

		rsa.FromXmlString (CreateKey (true));     
		decryptedData = rsa.Decrypt (data, false); 

		return ByteConverter.GetString (decryptedData); 
	}

	public void Dispose ()
	{
		rsa.Dispose ();
	}
}
}