using System;

namespace NinjectCheatSheet
{
	public class RuntimeConstructorArgumentExample
	{
		public string Name { get; set; }
		public bool IsAlive { get; set; }

		public RuntimeConstructorArgumentExample ( string name, bool isAlive)
		{
			Name = name;
			IsAlive = isAlive;
		}
	}
}

