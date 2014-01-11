using System;

namespace Advanced.AdvancedFeatures
{
	public class CheckedUncheckedAdder
	{
		public static int IncrementWithCheckedRegion (int input)
		{
			checked {
				return ++input;
			}
		}

		public static int IncrementWithCheckedFunction(int input)
		{
			return checked (++input);
		}


		public static int IncrementWithUncheckedRegion (int input)
		{
			unchecked {
				return ++input;
			}
		}

		public static int IncrementWithUncheckedFunction(int input)
		{
			return unchecked (++input);
		}
	}
}