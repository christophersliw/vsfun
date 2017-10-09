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

//			var gitHubApi = RestService.For<IGitHubApi>("http://localhost:24571");
//
//			await gitHubApi.AddProduct(new Product() {Id = 10, Name = "nowy1", Price = 2});
			var gitHubApi = RestService.For<IGitHubApi>("http://localhost:24571");

			await gitHubApi.TestToken();


			string tmp =   await gitHubApi.GetInitializeToken("123");
			
			var secretApi = RestService.For<IGitHubApi>(new HttpClient(new AuthenticatedHttpClientHandler(GetToken)) { BaseAddress = new Uri("http://localhost:24571") });


			string token = await secretApi.Login("demo", "haslo");

			Session["token"] = token;
			
			IList<Product> model = await  secretApi.GetSecretProducts();
		
//			await secretApi.SecretMethodApply(new Product() {Id = 11, Name = "nowy2", Price = 2});
//			await secretApi.SecretMethodApply(new Product() {Id = 11, Name = "nowy3", Price = 2});

			
			
			return View(model);
		}	
		
		
		private async Task<string> GetToken()
		{
			string token = null;


			if (Session["token"] == null)
			{
				var gitHubApi = RestService.For<IGitHubApi>("http://localhost:24571");

				token =   await gitHubApi.GetInitializeToken("123");
				Session["token"] = token;
			}
			else
			{
				token = Session["token"] as string;
			}

			return token;
		}
	}
}
