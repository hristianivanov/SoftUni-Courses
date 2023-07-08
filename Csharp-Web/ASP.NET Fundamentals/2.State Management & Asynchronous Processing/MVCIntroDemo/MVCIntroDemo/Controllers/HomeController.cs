using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MVCIntroDemo.ViewModels;

namespace MVCIntroDemo.Controllers;

public class HomeController : Controller
{
	public HomeController()
	{
	}

	public IActionResult Index()
	{
		ViewBag.Message = "Hello World!";
		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}

	public IActionResult About()
	{
		ViewBag.Message = "This is an ASP.NET Core MVC app.";
		return View();
	}

	public IActionResult Numbers()
	{
		return View();
	}

	[HttpGet]
	public IActionResult NumbersToN()
	{
		ViewBag.Count = -1;
		return View();
	}

	[HttpPost]
	public IActionResult NumbersToN(int count = -1)
	{
		ViewBag.Count = count;
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}