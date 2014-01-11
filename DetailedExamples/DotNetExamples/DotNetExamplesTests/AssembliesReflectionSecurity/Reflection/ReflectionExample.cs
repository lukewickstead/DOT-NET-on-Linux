using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace AssembliesReflectionSecurity.Reflection.Tests
{
	[TestFixture ()]
	public class ReflectionExampleTests
	{
		[Test ()]
		public void TestGetType ()
		{
			Type intType = 1.GetType ();

			Assert.AreEqual ("Int32", intType.Name);
		}

		[Test ()]
		public void TestTypeOf ()
		{
			Type stringType = typeof(string);

			Assert.AreEqual ("String", stringType.Name);
		}

		[Test ()]
		public void TestTypeGetType ()
		{
			Type boolType = Type.GetType ("System.Boolean", false, true);   

			Assert.AreEqual ("Boolean", boolType.Name);
		}

		[Test ()]
		public void TestNestedTypeGetType ()
		{
			Type nestedType = Type.GetType ("AssembliesReflectionSecurity.Reflection.AClass+NestedClass");   

			Assert.IsNull (nestedType);
			//Assert.AreEqual ("Boolean", nestedType.Name); // TODO: can not pick up nested type
		}

		[Test ()]
		public void TestTypeProperties ()
		{
			Assert.IsTrue (typeof(int).IsPrimitive);
			Assert.IsTrue (typeof(IList).IsInterface);
			Assert.IsFalse (typeof(int).IsAbstract);
			Assert.IsTrue (typeof(int).IsSealed);
			Assert.IsTrue (typeof(List<int>).IsGenericType);
			Assert.IsTrue (typeof(object).IsClass);
		}

		[Test ()]
		public void TestGetMethods ()
		{
			var methods = typeof(int).GetMethods ().Where (x => x.Name.Equals ("ToString")).ToList ();

			Assert.IsNotEmpty (methods);
		}

		[Test ()]
		public void TestMethodsProperties ()
		{			
			var aMethodInfo = typeof(int).GetMethod ("CompareTo", new [] { typeof(int) });

			Assert.AreEqual (typeof(int), aMethodInfo.ReturnType);
			Assert.IsTrue (aMethodInfo.IsPublic);
			Assert.IsFalse (aMethodInfo.IsPrivate);
			Assert.AreEqual ("CompareTo", aMethodInfo.Name);
			Assert.IsFalse (aMethodInfo.ContainsGenericParameters);

			MethodAttributes atts = aMethodInfo.Attributes;
		}

		[Test ()]
		public void TestMethodParameters ()
		{
			var aMethodInfo = typeof(int).GetMethod ("CompareTo", new [] { typeof(int) });

			ParameterInfo param = aMethodInfo.GetParameters ().Where (x => x.Name.Equals ("value")).FirstOrDefault ();

			Assert.IsFalse (param.IsOut);
			Assert.IsFalse (param.IsOptional);
			Assert.AreEqual (0, param.Position);
			Assert.AreEqual ("value", param.Name);
			//Assert.IsInstanceOfType ( typeof(int), param.ParameterType); // TODO: returns System.MonoType and not System.Int32
		}

		[Test ()]
		public void TestGetFields ()
		{
			FieldInfo[] fields = typeof(int).GetFields ();

			var aField = fields.Where (x => x.Name.Equals ("MinValue")).FirstOrDefault ();

			Assert.IsTrue (aField.IsLiteral);
			Assert.IsTrue (aField.IsPublic);

			//Assert.IsInstanceOfType (typeof(int), aField.FieldType); // TODO: System.MonoType
		}

		[Test ()]
		public void TestGetInterfaces ()
		{		
			var type = typeof(List<int>).GetInterfaces ().Where (x => x.Name.Equals ("IEnumerable")).FirstOrDefault ();

			Assert.IsNotNull (type);
			Assert.AreEqual ("IEnumerable", type.Name);
			Assert.IsNotNull (type.GetMethod ("GetEnumerator"));
		}
	}
}