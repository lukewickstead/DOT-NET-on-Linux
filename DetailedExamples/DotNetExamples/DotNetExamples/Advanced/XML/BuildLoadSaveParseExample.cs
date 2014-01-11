using System;
using System.IO;
using System.Xml.Linq;

namespace Advanced.XML
{
	public class BuildLoadSaveParseExample
	{
		public static XDocument GetXDocument ()
		{
			return new XDocument (
				new XElement ("MyModels", 
					new XElement ("ModelOne", 
						new XAttribute ("AnInt", 1),                 
						new XElement ("AString", "A"),                 
						new XElement ("ABool", true))));
		}

		public static string Save (XDocument xDocument)
		{
			var aFileName = Path.GetTempFileName ();

			xDocument.Save (aFileName);

			return aFileName;
		}

		public static XDocument Load (string aFileName)
		{
			return XDocument.Load (aFileName);   
		}

		public static XDocument Parse (string aXMLString)
		{
			return XDocument.Parse (aXMLString);
		}
	}
}