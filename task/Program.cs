//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Method1();  
             Console.WriteLine(" aaaa - " + Thread.CurrentThread.ManagedThreadId);  
            Method2();  
     
        }

        public static async Task Method1()  
        {  
            await Task.Run(() =>  
            {  
                for (int i = 0; i < 100; i++)  
                {  
                    Console.WriteLine(" Method 1  - " + Thread.CurrentThread.ManagedThreadId);  
                }  
            });  

             Console.WriteLine(" ccccccccccccccccccccccccccccccccccccc");             
        }  

    
        public static void Method2()  
                {  
                    for (int i = 0; i < 25; i++)  
                    {  
                        Console.WriteLine(" Method 2 - " + Thread.CurrentThread.ManagedThreadId);  
                    }  
                }  
}   


}
