using System;
using System.Collections.Generic;

namespace RhinoMocksExample
{
	public class ModelRepository : IModelRepository
	{
		public bool IsMock { get; private set; }
		public  int ModelCount { get; private set; }

		public void Add (Model aModel)
		{
			ModelCount ++;
		}

		public void Remove(Model aModel)
		{
			ModelCount++;
		}

		public IEnumerable<Model> GetModels()
		{
			return new List<Model>();
		}
	}
}

