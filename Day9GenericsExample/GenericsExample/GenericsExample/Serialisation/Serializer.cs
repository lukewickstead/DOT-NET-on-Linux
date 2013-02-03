using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GenericsExample.Serialisation
{
	public class Serializer
	{
		private static XmlSerializer GetXmlSerializer<T> ()
		{
			return new XmlSerializer (typeof(T));
		}

		public static string Serialize<T> (T anObject) where T : new()
		{
			var xmlSerialiser = GetXmlSerializer<T> ();
			var stringBuilder = new StringBuilder ();

			using (var stringWriter = new StringWriter (stringBuilder)) {

				xmlSerialiser.Serialize (stringWriter, anObject);

				return stringBuilder.ToString ();
			}
		}

		public static T DeSerialize<T> (string XmlString) where T : new()
		{
			var xmlDocument = new XmlDocument ();
			var xmlSerializer = GetXmlSerializer<T> ();

			xmlDocument.LoadXml (XmlString);

			return (T)xmlSerializer.Deserialize (new XmlNodeReader (xmlDocument.DocumentElement));
		}
	}
}