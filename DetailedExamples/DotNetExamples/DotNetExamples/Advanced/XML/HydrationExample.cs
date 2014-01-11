using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Advanced.Serialization;

namespace Advanced.XML
{
	public class HydrationExample
	{
		public static XElement BuildXElement ()
		{
			return new XElement ("Models",     
				new XComment ("My models!!!"),       
				new XElement ("Model", 
					new XAttribute ("AnInt", "1"),           
					new XElement ("AString", "A"),
					new XElement ("ABool", true)),
				new XElement ("Model", 
					new XAttribute ("AnInt", "2"),           
					new XElement ("AString", "B"),
					new XElement ("ABool", false))
			);    
		}

		public static XElement BuildXElementWithLinq ()
		{

			var models = new List<MyModel> () {
				new MyModel () { AnInt = 1, AString = "A", ABool = true },
				new MyModel () { AnInt = 2, AString = "B", ABool = false }
			};	

			return new XElement ("Models",
				new XComment ("My models!!!"),       
				from x in models
				select new XElement ("Model", 
					    new XAttribute ("AnInt", x.AnInt),                               
					    new XElement ("AString", x.AString),
					    new XElement ("ABool", x.ABool)));
		}
	}
}