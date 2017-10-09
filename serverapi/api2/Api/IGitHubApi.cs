﻿using System.Collections.Generic;
using System.Threading.Tasks;
using api2.Models;
using Refit;

namespace api2.Api
{
 //   [Headers("User-Agent: Awesome Octocat App")]
    public interface IGitHubApi
    {
        [Get("/api/apitest/getallproducts")]
        Task<IList<Product>> GetProducts();
        
        [Get("/api/apitest/GetSecretProducts")]
        Task<IList<Product>> GetSecretProducts();
        
        [Post("/api/apitest/Product")]
        Task AddProduct([Body] Product product);

        [Post("/api/apitest/Apply")] 
        [Headers("Authorization: User")]
        Task SecretMethodApply([Body] Product product);

    }
}