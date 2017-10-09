using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using api2.Api;
using api2.Models;
using Refit;

namespace api2.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			ViewBag.Title = "Home Page";

			var gitHubApi = RestService.For<IGitHubApi>("http://localhost:24571");

			await gitHubApi.AddProduct(new Product() {Id = 10, Name = "nowy1", Price = 2});
			
			
			var secretApi = RestService.For<IGitHubApi>(new HttpClient(new AuthenticatedHttpClientHandler(GetToken)) { BaseAddress = new Uri("http://localhost:24571") });
			await secretApi.SecretMethodApply(new Product() {Id = 11, Name = "nowy2", Price = 2});
			await secretApi.SecretMethodApply(new Product() {Id = 11, Name = "nowy3", Price = 2});
			
			IList<Product> model = await  secretApi.GetSecretProducts();
			
			return View(model);
		}	
		
		
		private async Task<string> GetToken()
		{
			string token = "123";

			return token;
		}
	}
}
