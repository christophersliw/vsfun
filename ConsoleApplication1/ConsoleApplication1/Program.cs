using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            new Test().DownloadAndSortAsync();

            Console.ReadKey();

            
        }
        
        class Test
        {
            public async void DownloadAndSortAsync()
            {
                Console.WriteLine("a");
                Console.WriteLine("at" + Thread.CurrentThread.ManagedThreadId);
                Task<int[]> r =  DownloadNumbersAsync();

              

            
                    
                Console.WriteLine("c");
                
                int[] sortedNumbers = await SortNumbersAsync(r.Result);
                Console.WriteLine("c");
                

            }


            private Task<int[]> DownloadNumbersAsync()
            {
                return Task<int[]>.Factory.StartNew(() => DownloadNumbers());
            }
            private Task<int[]> SortNumbersAsync(int[] numbers)
            {
                return Task<int[]>.Factory.StartNew(() => SortNumbers(numbers));
            }
            private int[] DownloadNumbers()
            {
                Console.WriteLine("a1t" + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("a1");
                Thread.Sleep(5000);
                int[] allNumbers = { 1, 24, 6, 46, 74, 64, 75, 6, 6, 5 };
                return allNumbers;
            }
            private int[] SortNumbers(int[] numbers)
            {
                Console.WriteLine(numbers.Length);
                Thread.Sleep(5000);
                return numbers.OrderBy(n => n).ToArray();
            }
        }

    }
}