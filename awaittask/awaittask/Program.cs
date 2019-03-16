using System;
using System.Threading.Tasks;

namespace awaittask
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("e");
			m0().Wait();

			Console.WriteLine("f");


		}

		public static async Task m0()
		{
			Console.WriteLine("a");

			var a = m1("a1");
			var a1 = m1("a1");

			Console.WriteLine("b");

			 await a;
			 await a1;


		}

		//public static async Task<string> m1(string param)
		//{

		//	await Task.Delay(1000);

		//	Console.WriteLine(param);

		//		return "m1";

		//}

		public static Task<string> m1(string param)
		{
			return Task.Run(() =>
			{
				System.Threading.Thread.Sleep(5000);

				Console.WriteLine(param);

				return "m1";
			}
			);
		}

	}
}