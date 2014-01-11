namespace TestingMoqingDebugging.RhinoMocks.Tests
{
    using System;
    using System.Collections.Generic;

    public interface IModelRepository
    {
        bool IsMock { get; }

        int ModelCount { get; }

        void Add(AnotherModel theModel);

        void Remove(AnotherModel theModel);

        IEnumerable<AnotherModel> GetModels();
    }
}