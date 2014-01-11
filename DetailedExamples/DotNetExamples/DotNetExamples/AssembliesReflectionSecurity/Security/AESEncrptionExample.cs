using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace AssembliesReflectionSecurity.Security
{
	public class AESEncrptionExample
	{
		public static byte[] Encrypt (string plainText, out byte[] key, out byte[] iV)
		{     
			using (var aesManaged = new AesManaged ()) {  

				key = aesManaged.Key;
				iV = aesManaged.IV;

				var encryptor = aesManaged.CreateEncryptor (key, iV);     

				using (var ms = new MemoryStream ()) {         
					using (var cs = new CryptoStream (ms, encryptor, CryptoStreamMode.Write)) {             
						using (var sw = new StreamWriter (cs)) {
							sw.Write (plainText);
						}

						return ms.ToArray ();
					}
				}
			}
		}

		public static string Decrypt (byte[] cipherText, byte[] key, byte[] iV)
		{
			using (var aesManaged = new AesManaged ()) {  

				var decryptor = aesManaged.CreateDecryptor (key, iV);

				using (var ms = new MemoryStream (cipherText)) {
					using (var cs = new CryptoStream (ms, decryptor, CryptoStreamMode.Read)) {
						using (var sr = new StreamReader (cs)) {

							return sr.ReadToEnd ();
						}
					}
				}
			}
		}
	}
}