using System.Collections.Generic;
using System.Threading.Tasks;
using api2.Models;
using Refit;

namespace api2.Api
{
 //   [Headers("User-Agent: Awesome Octocat App")]
    public interface IGitHubInitApi
    {
      
        [Get("/api/apitest/GetInitializeToken")] 
        Task<TokenModel> GetInitializeToken(string orgName);

    }
}