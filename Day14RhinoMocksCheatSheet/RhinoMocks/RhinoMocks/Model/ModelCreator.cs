using System;
using System.Collections.Generic;

namespace RhinoMocksExample.Model
{
    public class ModelCreator
    {
        private IModelRepository repository;

        public int ModelCount 
        {
            get 
            { 
                return this.repository.ModelCount; 
            }
        }

        public bool IsMock { get { return this.repository.IsMock; } }

        public ModelCreator(IModelRepository repository)
        {
            this.repository = repository;
        }

        public void CreateModel(AnotherModel aModel)
        {
            this.repository.Add(aModel);
        }

        public void RemoveModel(AnotherModel aModel)
        {
            this.repository.Remove(aModel);
        }

        public IEnumerable<AnotherModel> GetModels()
        {
            return this.repository.GetModels();
        }
    }
}