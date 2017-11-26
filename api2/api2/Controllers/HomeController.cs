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
			
			var secretApi = RestService.For<IGitHubApi>(new HttpClient(new AuthenticatedHttpClientHandler(GetToken)) { BaseAddress = new Uri("http://localhost:24571") });

			var list = secretApi.GetSecretProducts();
			
			return View(new List<Product>());
		}	
		
		
		private async Task<string> GetToken()
		{
			string token = null;


			if (Session["token"] == null)
			{
				var gitHubApi = RestService.For<IGitHubInitApi>("http://localhost:24571");

				var tokenModel =   await gitHubApi.GetInitializeToken("123");
				Session["token"] = tokenModel.Token;
			}
			else
			{
				token = Session["token"] as string;
			}

			return token;
		}
	}
}
