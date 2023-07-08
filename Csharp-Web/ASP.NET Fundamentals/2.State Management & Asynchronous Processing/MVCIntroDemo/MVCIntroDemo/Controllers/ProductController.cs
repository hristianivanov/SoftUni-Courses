namespace MVCIntroDemo.Controllers
{
	using System.Text;
	using System.Text.Json;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Net.Http.Headers;

	using static Seeding.ProductData;

	public class ProductController : Controller
	{
		public IActionResult All()
		{
			return View(_products);
		}

		public IActionResult ById(int id)
		{
			var product = _products
				.FirstOrDefault(p => p.Id == id);
			if (product == null)
			{
				return RedirectToAction("All");
			}

			return View(product);
		}

		public IActionResult AllAsJson()
		{
			var options = new JsonSerializerOptions()
			{
				WriteIndented = true
			};

			return Json(_products, options);
		}

		public IActionResult AllAsText()
		{
			var text = string.Empty;

			foreach (var item in _products)
			{
				text += $"Product {item.Id}: {item.Name} - {item.Price} lv.";
				text += Environment.NewLine;
			}

			return Content(text);
		}

		public IActionResult AllAsTextFile()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var product in _products)
			{
				sb.AppendLine($"Product: {product.Id}: {product.Name} - {product.Price:f2} lv.");
			}

			Response.Headers.Add(HeaderNames.ContentDisposition,
				@"attachment;filename=products.txt");

			return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
		}

		[ActionName("My-Products")]
		public IActionResult AllMyProducts()
		{
			return RedirectToAction("All");
		}

		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
			if (keyword != null)
			{
				var foundProducts = _products
					.Where(p => p.Name
						.ToLower()
						.Contains(keyword.ToLower()));

				return View(foundProducts);
			}

			return View(_products);
		}
	}
}