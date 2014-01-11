using System;
using System.Collections.Generic;
using System.Reflection;

namespace Advanced.Generics
{
	public static class PrimativeTypeParsingBinder<T>
	{
		public delegate bool TryParseHandler<Y> (string value,out Y result);

		static TryParseHandler<T> tryParser;

		public static TryParseHandler<T> GetTryParse ()
		{
			if (tryParser == null)
				tryParser = GetTryParseMethod ();

			return tryParser;
		}

		private static TryParseHandler<T> GetTryParseMethod ()
		{

			MethodInfo methodInfo = typeof(T).GetMethod ("TryParse", new[] {
				typeof(String),
				typeof(T).MakeByRefType ()
			});

			if (methodInfo == null)
				throw new Exception (string.Format ("No TryParse exists for Type {0}", Type.GetTypeCode (typeof(T))));

			return (TryParseHandler<T>)Delegate.CreateDelegate (typeof(TryParseHandler<T>), methodInfo);
		}
	}

}