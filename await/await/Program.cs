using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace await
{
	class Program
	{
		static void Main(string[] args)
		{
			new Test().DownloadAndSortAsync();

			Console.ReadKey();
		}

		
	}

	class Test
	{
		public async void DownloadAndSortAsync()
		{
			int[] allNumbers = await DownloadNumbersAsync();
			int[] sortedNumbers = await SortNumbersAsync(allNumbers);

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
			Thread.Sleep(5000);
			int[] allNumbers = { 1, 24, 6, 46, 74, 64, 75, 6, 6, 5 };
			return allNumbers;
		}
		private int[] SortNumbers(int[] numbers)
		{
			Thread.Sleep(5000);
			return numbers.OrderBy(n => n).ToArray();
		}
	}
}
