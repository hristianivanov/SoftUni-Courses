namespace TextSplitterApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Models;

	public class HomeController : Controller
	{
		public IActionResult Index(TextViewModel model)
		{
			return View(model);
		}

		[HttpPost]
		public IActionResult Split(TextViewModel model)
		{
			if (string.IsNullOrWhiteSpace(model.Text))
			{
				return RedirectToAction("Index", new TextViewModel()
				{
					SplitText = string.Empty,
					Text = string.Empty
				});
			}

			var splitTextArr = model
				.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			model.SplitText = string.Join(Environment.NewLine, splitTextArr);

			return RedirectToAction("Index", model);
		}
	}
}