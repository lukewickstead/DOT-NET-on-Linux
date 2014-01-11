using System;

namespace TestingMoqingDebugging.NInject
{
	public class ConstructorWithArguments
	{
		public int AnInt { get; set; }
		public string AString{ get; set; }
		public IClass AClass { get; set; }

		public ConstructorWithArguments (int anInt, string aString, IClass aClass)
		{
			AnInt = anInt;
			AString = aString;
			AClass = aClass;
		}
	}
}