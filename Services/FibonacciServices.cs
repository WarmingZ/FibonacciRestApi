using System.Runtime.Serialization.Json;

namespace Fibonacci
{
	public class FibonacciServices
	{
		static List<Fibonacci> Fibonaccis { get; }
		static int nextId = 1;
		static FibonacciServices()
		{
			Fibonaccis = new List<Fibonacci>
				{
					new Fibonacci {Id = 0, Row = new int[] {1,1,2,3,5,8}}
				};

		}

		public static List<Fibonacci> GetAll() => Fibonaccis;
		public static Fibonacci? Get(int id) => Fibonaccis.FirstOrDefault(p => p.Id == id);


		public static void Add(Fibonacci fibonacci)
		{
			fibonacci.Id = nextId++;
			Fibonaccis.Add(fibonacci);
		}
		public static void Delete(int id)
		{
			var fibonacci = Get(id);
			if (fibonacci is null)
				return;

			Fibonaccis.Remove(fibonacci);
		}

		public static void Update(Fibonacci fibonacci)
		{
			var index = Fibonaccis.FindIndex(p => p.Id == fibonacci.Id);
			if (index == -1)
				return;

			Fibonaccis[index] = fibonacci;
		}

		public static void ReverseFibonacciRow(Fibonacci fibonacci)
		{
			int n = fibonacci.Row.Length;
			for (int i = 0; i < n / 2; i++)
			{
				int tmp = fibonacci.Row[i];
				fibonacci.Row[i] = fibonacci.Row[n - i - 1];
				fibonacci.Row[n - i - 1] = tmp;
			}
		}

		public static void Serializ(Fibonacci fibonacci)
		{
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Fibonacci));
			using (FileStream fs = new FileStream(@"/Users/user/Project&Code /Fibonacci/FibonacciSerialize.json",
			FileMode.Append, FileAccess.Write))
			{
				jsonFormatter.WriteObject(fs, fibonacci);
			}
		}

		public static bool FibonacciEquals(Fibonacci fibonacci)
		{
			var row = fibonacci.Row;
			for (int i = 0; i < row.Length - 2; i++)
				if (row[i] + row[i + 1] != row[i + 2])
					return false;
			return true;
		}

	}
}