using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Fibonacci
{
	public class Fibonacci
	{

		public int Id { get; set; }

		public int[] Row {get; set;}

		public Fibonacci()
		{
		}
	}
}

