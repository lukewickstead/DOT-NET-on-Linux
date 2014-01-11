using System;
using System.Linq;
using System.Collections.Generic;

namespace Advanced.Generics
{
	public class GenericsClass<T>
	{
		public T value { get; private set; }

		public GenericsClass (T t)
		{
			this.value = t;
		}

		public void Set (T t)
		{
			value = t;
		}
	}

	public class Base
	{
	}

	public class Test< K, V > where K : struct where V : Base, new()
	{
		public V foo;

		public void Do<X, Y> (X first, Y second) where Y : X 
		{
		}
	}

	public class SampleClass< T, K, V > where T : V
	{
		public SampleClass( T t, K k, V v )
		{

		}

	}
}

