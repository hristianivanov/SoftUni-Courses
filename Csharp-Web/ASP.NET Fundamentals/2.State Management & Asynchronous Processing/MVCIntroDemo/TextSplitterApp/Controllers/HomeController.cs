using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index(TextViewModel model)
		{
			return View(model);
		}

		[HttpPost]
		public IActionResult Split(TextViewModel model)
		{
			var splitTextArr = model
				.Text.Split(' ',StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			model.SplitText = string.Join(Environment.NewLine, splitTextArr);

			return RedirectToAction("Index",model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}