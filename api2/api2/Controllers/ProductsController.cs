using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using api2.Models;

namespace api2.Controllers
{
    public class ProductsController  : ApiController
    {
        static IList<Product> products = new List<Product>()
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };
        
        public IList<Product> GetAllProducts()
        {
           
            return products;
          
        }

        [HttpPost]
        public void Product(Product product)
        {
            products.Add(product);
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        
        public IList<Product> GetAll()
        {
            return products;
        }
        
        private Task<IList<Product>> GetAllProductsAsync()
        {
            return Task<IList<Product>>.Factory.StartNew(() => GetProducts());
        }

        private IList<Product> GetProducts()
        {
            Thread.Sleep(5000);
            return products;
        }
        
    }
}