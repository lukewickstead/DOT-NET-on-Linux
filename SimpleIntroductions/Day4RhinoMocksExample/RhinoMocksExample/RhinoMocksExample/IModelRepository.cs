using System;
using System.Collections.Generic;

namespace RhinoMocksExample
{
	public interface IModelRepository
	{
		bool IsMock { get; }
		int ModelCount { get; }
		void Add (Model aModel);
		void Remove (Model aModel);
		IEnumerable<Model> GetModels();
	}
}



