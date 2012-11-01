using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductApp {
    class Program {
        static void Main(string[] args) {
        }
    }

public class Product {
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { set; get; }
}

public interface IPriceReducer {

    void ReducePrices(decimal priceReduction);
}

public class MyPriceReducer : IPriceReducer {
    private IProductRepository repository;

    public MyPriceReducer(IProductRepository repo) {
        repository = repo;
    }

    public void ReducePrices(decimal priceReduction) {
        foreach (Product p in repository.GetProducts()) {
            p.Price = Math.Max(p.Price - priceReduction, 1);
            repository.UpdateProduct(p);
        }
    }
}

public interface IProductRepository {

    IEnumerable<Product> GetProducts();
    void UpdateProduct(Product product);
}

public class FakeRepository : IProductRepository {
    private Product[] products = {
        //new Product() { Name = "Kayak", Price = 275M},
        //new Product() { Name = "Lifejacket", Price = 48.95M},
        //new Product() { Name = "Soccer ball", Price = 19.50M},
        //new Product() { Name = "Stadium", Price = 79500M}
    };

    public IEnumerable<Product> GetProducts() {
        return products;
    }

    public void UpdateProduct(Product productParam) {
        foreach(Product p in products
            .Where(e => e.Name == productParam.Name)
            .Select(e => e)) {
                p.Price = productParam.Price;
        }
        UpdateProductCallCount++;
    }

    public int UpdateProductCallCount { get; set; }

    public decimal GetTotalValue() {
        return products.Sum(e => e.Price);
    }
}

}