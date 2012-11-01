using System.Collections.Generic;

using System.Linq;
using NUnit.Framework;
using Rhino;
using Rhino.Mocks;

using Ninject;
//using Ninject.Activation;



namespace ProductApp.Tests {

[TestFixture]
public class MyPriceReducerTest {

    private IEnumerable<Product> products;
    private IKernel ninjectKernel;

    public MyPriceReducerTest() {
        ninjectKernel = new StandardKernel();
    }

    [TestFixtureSetUp]
    public void PreTestInitialize() {

        products = new Product[] {
            new Product() { Name = "Kayak", Price = 275M},
            new Product() { Name = "Lifejacket", Price = 48.95M},
            new Product() { Name = "Soccer ball", Price = 19.50M},
            new Product() { Name = "Stadium", Price = 79500M}
        };

		IProductRepository mock = MockRepository.GenerateMock<IProductRepository>();


       // Mock<IProductRepository> mock = new Mock<IProductRepository>();
        mock.Stub(m => m.GetProducts()).Return(products);
       
		ninjectKernel.Bind<IProductRepository>().ToConstant(mock); //.Object

    }

	


        [Test]
        public void All_Prices_Are_Reduced() {

            // Arrange
            decimal reductionAmount = 10;
            IEnumerable<decimal> prices = products.Select(e => e.Price);
            decimal[] initialPrices = prices.ToArray();
            MyPriceReducer target = ninjectKernel.Get<MyPriceReducer>();

            // Act 
            target.ReducePrices(reductionAmount);

            // Assert    
            prices.Zip(initialPrices, (p1, p2) => {
                if (p1 == p2) {
                    Assert.Fail();
                }
                return p1;
            });
        }

        [Test]
        public void Correct_Total_Reduction_Amount() {

            // Arrange
            decimal reductionAmount = 10;
            decimal initialTotal = products.Sum(p => p.Price);
            MyPriceReducer target = ninjectKernel.Get<MyPriceReducer>();

            // Act
            target.ReducePrices(reductionAmount);

            // Assert
			var amount = products.Sum(p => p.Price);

			//var products.Sum(p => p.Price);
			var count = products.Count(p => p.Price < 1 );


            Assert.AreEqual(products.Sum(p => p.Price),
                (initialTotal - (products.Count() * reductionAmount)));
        }

        [Test]
        public void Update_Method_Called_For_Each_Product() {

            // Arrange  
            decimal reductionAmount = 10;
            MyPriceReducer target = ninjectKernel.Get<MyPriceReducer>();

        
			var mock = ninjectKernel.Get<IProductRepository>();


			//IProductRepository mock = MockRepository.GenerateStub<IProductRepository>();

			// Act
            target.ReducePrices(reductionAmount);

		
            // Assert
            //Mock<IProductRepository> mock = Mock.Get(ninjectKernel.Get<IProductRepository>());
            foreach (Product p in mock.GetProducts()) {
                mock.AssertWasCalled(m => m.UpdateProduct(p));
            }
		}

        [Test]
        public void No_Price_Less_Than_One_Dollar() {

            // Arrange
            decimal reductionAmount = decimal.MaxValue;
            MyPriceReducer target = ninjectKernel.Get<MyPriceReducer>();

            // Act
            target.ReducePrices(reductionAmount);

            // Assert
            Assert.AreEqual(products.Count(e => e.Price < 1), 0);
        }
    }
}