using System;
using System.Globalization;

public class  MyFormatter : ICustomFormatter, IFormatProvider
{
	public string Format (string format, Object arg, IFormatProvider formatProvider)
	{
		switch (format.ToUpperInvariant ()) {
		case "A":
			return "This would be format A"; 
		case "B":
			return "This would be format B";
		default:
			return "No one is home";
		
		}
	}

	object IFormatProvider.GetFormat (Type formatType)
	{
		throw new NotImplementedException ();
	}
}