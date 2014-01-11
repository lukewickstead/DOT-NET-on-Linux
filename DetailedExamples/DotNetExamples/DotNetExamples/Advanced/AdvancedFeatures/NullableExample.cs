using System;

namespace Advanced.AdvancedFeatures
{
	public class NullableExample
	{
		public static int Coalesce(int? aValue, int aNull)
		{
			return aValue ?? aNull;
		}
	}
}