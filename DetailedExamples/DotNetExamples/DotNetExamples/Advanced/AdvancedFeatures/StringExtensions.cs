using System;

namespace Advanced.AdvancedFeatures
{
	public static class StringExtensions
	{
		public static string Reverse (this string foo)
		{
			var stringArray = foo.ToCharArray ();
			Array.Reverse (stringArray);
			return new string (stringArray);
		}

		public static bool IsPalindrome (this String input)
		{
			return input.Equals (input.Reverse (), StringComparison.InvariantCultureIgnoreCase);
		}
	}
}