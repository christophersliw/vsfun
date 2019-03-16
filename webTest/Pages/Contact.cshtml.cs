using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webTest.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page xxxxxxxxxxxxx.";

            new Repository().AddModel(1);
        }
    }

    public class Repository
    {
        public  void AddModel(int id)
        {
            new ElasticService().IndexModel(1);

            new ElasticService().IndexModelAndReturn(1);
        }

         public async  Task<int> AddModelAndReturn(int id)
        {
          int result = await new ElasticService().IndexModelAndReturn(1);

          return 1;
        }
    } 

    public class ElasticService
    {
        public  async void IndexModel(int id)
        {
            await Task.Run(() =>  
            { 
                for (int i = 0; i < 1000000000; i++)  
                {  
                    for (int j = 0; j < 1000000000; j++)  
                {  
                  
                }  
                }  
            });      
        }

         public  async Task<int> IndexModelAndReturn(int id)
        {
            await Task.Run(() =>  
            { 
                for (int i = 0; i < 1000000000; i++)  
                {  
                    for (int j = 0; j < 1000000000; j++)  
                {  
                  
                }  
                }  
            });      

            return 1;
        }
    }
}
