using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using api2.Models;
using System.Security.Claims;

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

        private static string _orgKod = "098";


		[HttpGet]
		public void TestToken()
		{
			string token = new JwtManager().GenerateToken(_orgKod, null);
		

			var simplePrinciple = new JwtManager().GetPrincipal(token);
			var identity = simplePrinciple.Identity as ClaimsIdentity;
		}


		[HttpGet]
        public string GetInitializeToken(string orgName)
        {
            if (orgName == "123")
            {        
                return new JwtManager().GenerateToken(_orgKod, null);


            }
            else
            {
                return null;
            }
        }
        
        [HttpGet]
        public IList<Product> GetAllProducts()
        {          
            return products;   
        }
        
        [HttpPost]
        [JwtAuthenticationAttribute()]
        public string Login(string username, string password)
        {
            if (ValidateUser(username, password))
            {
                return new JwtManager().GenerateToken(_orgKod,username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
        
        public bool ValidateUser(string username, string password)
        {

            return true;
        }
        
        [HttpGet]
        [JwtAuthenticationAttribute()]
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