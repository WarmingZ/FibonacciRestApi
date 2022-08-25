using Microsoft.AspNetCore.Mvc;

namespace Fibonacci
{
	[ApiController]
	[Route("api/[controller]")]
	public class FibonacciController : ControllerBase
	{
		public FibonacciController()
		{

		}

		[HttpGet]
		public ActionResult<List<Fibonacci>> GetAll() =>
		FibonacciServices.GetAll();
		

		[HttpGet("{id}")]
		public ActionResult<Fibonacci> Get(int id)
		{
			var fibonacci = FibonacciServices.Get(id);

			if (fibonacci == null)
				return NotFound();

			return fibonacci;
		}

		[HttpPost]
		public  IActionResult Create(Fibonacci fibonacci)
		{
			if(fibonacci.Row.Length <= 1)
				return BadRequest("Bad request: The array is empty or consists of one element");


			if(FibonacciServices.FibonacciEquals(fibonacci) == true){
			FibonacciServices.Add(fibonacci);
			FibonacciServices.ReverseFibonacciRow(fibonacci);
			FibonacciServices.Serializ(fibonacci);
			return CreatedAtAction(nameof(Create), new { id = fibonacci.Id }, fibonacci);
			}
			else
				return BadRequest("Bad request: The array is not a Fibonacci sequence");
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Fibonacci fibonacci)
		{
			if (id != fibonacci.Id)
				return BadRequest();

			var existingFibo = FibonacciServices.Get(id);
			if (existingFibo is null)
				return NotFound();

			FibonacciServices.Update(fibonacci);

			return NoContent();
		}

		 
	}
}