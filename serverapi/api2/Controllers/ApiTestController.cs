using System.Collections.Generic;
using System.Web.Http;
using api2.Models;

namespace api2.Controllers
{
    public class ApiTestController : ApiController
    {
        static IList<Product> products = new List<Product>()
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };
        
        [HttpGet]
        public IList<Product> GetAllProducts()
        {          
            return products;   
        }
        
        
        [HttpGet]
        public IList<Product> GetSecretProducts()
        {          
            return products;   
        }
        
        
        
        [HttpPost]
        public void Product(Product product)
        {
            products.Add(product);
        }

        [HttpPost]
        public void Apply(Product product)
        {
            products.Add(product);
        }
    }
}