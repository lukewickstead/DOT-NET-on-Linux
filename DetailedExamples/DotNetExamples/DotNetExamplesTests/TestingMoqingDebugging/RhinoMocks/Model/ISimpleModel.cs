namespace TestingMoqingDebugging.RhinoMocks.Tests
{
    using System.Collections.Generic;

    public interface ISimpleModel
    {
        int AProperty { get; set; }

        int AReadonlyPropery { get; }

        int Do();

        int Do(int x);

        int Do(string x);

        int DoIFoo(IFoo x);

        int Do<T>(List<T> x);

        int Do(int x, ref int y);

        int Do(int x, string y, out int z);        
    }
}