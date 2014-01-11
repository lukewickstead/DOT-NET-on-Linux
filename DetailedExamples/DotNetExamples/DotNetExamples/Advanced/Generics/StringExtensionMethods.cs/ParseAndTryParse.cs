using System;
using System.Collections.Generic;
using System.Reflection;
using Advanced.Generics;

namespace Advanced.Generics
{
	public static class PaseAndTryParse
	{
		public static Nullable<T> TryParse<T> (this String toParse) where T : struct
		{        
			if (!typeof(T).IsEnum && !typeof(T).IsPrimitive && Type.GetTypeCode (typeof(T)) != TypeCode.Decimal) 
				throw new ArgumentException ("Non supported type");

			T value;

			if (typeof(T).IsEnum) {
				return Enum.TryParse<T> (toParse, true, out value) ? value : new Nullable<T> ();
			}
		
			return PrimativeTypeParsingBinder<T>.GetTryParse () (toParse, out value) ? value : new Nullable<T> ();
		}
	
		public static T Parse<T> (this String toParse) where T : struct
		{
			return Parse<T> (toParse, default(T));
		}

		public static T Parse<T> (this String toParse, T defaultValue) where T : struct
		{
			T? value = TryParse<T> (toParse);

			return value.HasValue ? value.Value : defaultValue;
		}
	}
}
