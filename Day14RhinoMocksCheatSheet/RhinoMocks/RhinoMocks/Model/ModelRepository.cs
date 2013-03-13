namespace RhinoMocksExample.Model
{
    using System.Collections.Generic;

    public class ModelRepository : IModelRepository
    {
        public bool IsMock { get; private set; }

        public int ModelCount { get; private set; }

        public void Add(AnotherModel theModel)
        {
            this.ModelCount++;
        }

        public void Remove(AnotherModel theModel)
        {
            this.ModelCount++;
        }

        public IEnumerable<AnotherModel> GetModels()
        {
            return new List<AnotherModel>();
        }
    }
}