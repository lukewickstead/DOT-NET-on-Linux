using System;

namespace Advanced.AdvancedFeatures
{
	public class ClassB
	{
		public int Value { get; set; }
	}

	public class ClassC
	{
		public int Value { get; set; }
	}

	public class ClassA :  IComparable<ClassA>
	{
		public int Value { get; set; }

		public ClassA (int value)
		{
			Value = value;
		}

		public static ClassA operator + (ClassA dataOne, ClassA dataTwo)
		{ 
			return new ClassA (dataOne.Value + dataTwo.Value);
		}

		public static ClassA operator + (ClassA data, int increase)
		{ 
			return new ClassA (data.Value + increase);
		}

		public static ClassA operator + (int increase, ClassA data)
		{ 
			return new ClassA (data.Value + increase);
		}

		public static ClassA operator++ (ClassA data)
		{
			return new ClassA (++data.Value);
		}

		public static ClassA operator-- (ClassA data)
		{
			return new ClassA (--data.Value);
		}

		public override bool Equals (object oDataTwo)
		{ 
			ClassA dataTwo = (ClassA)oDataTwo;

			return this.Value == dataTwo.Value;
		}

		public override int GetHashCode ()
		{ 
			return this.Value.ToString ().GetHashCode (); 
		}

		public static bool operator == (ClassA dataOne, ClassA dataTwo)
		{ 
			return dataOne.Equals (dataTwo); 
		}

		public static bool operator != (ClassA dataOne, ClassA dataTwo)
		{ 
			return !dataOne.Equals (dataTwo); 
		}

		public int CompareTo (ClassA other)
		{
			return this.Value.CompareTo (other.Value);
		}

		public static bool operator < (ClassA dataOne, ClassA dataTwo)
		{ 
			return (dataOne.CompareTo (dataTwo) < 0); 
		}

		public static bool operator > (ClassA dataOne, ClassA dataTwo)
		{ 
			return (dataOne.CompareTo (dataTwo) > 0); 
		}

		public static bool operator <= (ClassA dataOne, ClassA dataTwo)
		{ 
			return (dataOne.CompareTo (dataTwo) <= 0); 
		}

		public static bool operator >= (ClassA dataOne, ClassA dataTwo)
		{ 
			return (dataOne.CompareTo (dataTwo) >= 0); 
		}

		public static explicit operator ClassB (ClassA f)
		{
			return new ClassB () { Value = f.Value };
		}

		public static implicit operator ClassC (ClassA f)
		{ 
			return new ClassC () { Value = f.Value };
		}
	}
}