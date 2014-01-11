using System;
using System.Collections.Generic;

namespace RhinoMocksExample
{
	public class ModelCreator
	{
		IModelRepository repository;

		public int ModelCount { get { return repository.ModelCount; } }
		public bool IsMock { get { return repository.IsMock; } }

		public ModelCreator (IModelRepository repository)
		{
			this.repository = repository;
		}

		public void CreateModel(Model aModel)
		{
			repository.Add(aModel);
		}

		public void RemoveModel(Model aModel)
		{
			repository.Remove(aModel);
		}


		public IEnumerable<Model> GetModels()
		{
			return repository.GetModels();
		}

		



	}
}

