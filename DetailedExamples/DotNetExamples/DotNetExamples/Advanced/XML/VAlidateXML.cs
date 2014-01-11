using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace Advanced.XML
{
	public class VAlidateXML
	{
		public bool HasError { get; set; }

		public bool HasWarning { get; set; }

		public void ValidateXML ()
		{			      
			XmlReader reader = XmlReader.Create ("MyModels.xml");     
			XmlDocument document = new XmlDocument ();     

			document.Schemas.Add ("", "MyModels.xsd");     
			document.Load (reader);     

			document.Validate (new 
				ValidationEventHandler (ValidationEventHandler)); 
		}

		public void ValidationEventHandler (object sender, ValidationEventArgs e)
		{     
			switch (e.Severity) {         
			case XmlSeverityType.Error:             
				HasError = true;
				break;         
			case XmlSeverityType.Warning:             
				HasWarning = true;
				break;     
			} 
		}
	}
}