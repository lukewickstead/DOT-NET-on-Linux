using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Advanced.Serialization;

namespace Advanced.XML
{
	public class LinqToXMLExample
	{
		public XDocument xDoc;

		public LinqToXMLExample ()
		{
			var models = new List<MyModel> () {
				new MyModel () { AnInt = 1, AString = "A", ABool = true },
				new MyModel () { AnInt = 2, AString = "B", ABool = false },
				new MyModel () { AnInt = 3, AString = "C", ABool = false },
				new MyModel () { AnInt = 4, AString = "D", ABool = true }
			};	

			xDoc = new XDocument (new XElement ("Models",       
				from x in models
				select new XElement ("Model", 
					    new XAttribute ("AnInt", x.AnInt),                               
					    new XElement ("AString", x.AString),
					    new XElement ("ABool", x.ABool))));
		}

		public List<string> GetAStrings ()
		{
			IEnumerable<string> strings =
				from item in xDoc.Descendants (xDoc.Root.Name.Namespace + "Model")
				select (string)item.Attribute ("AString");	

			return strings.ToList ();
		}

		public int GetAnIntes (int anInt)
		{
			IEnumerable<XElement> models =
				from item in xDoc.Descendants (xDoc.Root.Name.Namespace + "Model")
				where (int)item.Attribute ("AnInt") > anInt
				orderby (int)item.Attribute("AnInt")
				select item;

			return models.Count ();			
		}

		public int Add ()
		{
			var newModel = new XElement ("Model", 
				               new XAttribute ("AnInt", 5),           
				               new XElement ("AString", "E"),
				               new XElement ("ABool", true));

			xDoc.Element ("Models").Add (newModel);

			return xDoc.Descendants (xDoc.Root.Name.Namespace + "Model").Count ();
		}

		public int Remove ()
		{
			xDoc.Descendants (xDoc.Root.Name.Namespace + "Model").Last ().Remove ();

			return xDoc.Descendants ("Model").Count ();
		}

		public int Edit ()
		{
			xDoc.Descendants ("Model").First ().Attribute ("AnInt").SetValue (5);

			return (int)xDoc.Descendants ("Model").First ().Attribute ("AnInt");
		}
	}
}