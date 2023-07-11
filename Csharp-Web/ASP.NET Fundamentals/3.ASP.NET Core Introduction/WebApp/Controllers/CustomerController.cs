using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class CustomerController : Controller
	{
		public IActionResult Show()
		{
			CustomerViewModel customer = new CustomerViewModel()
			{
				Name = "Pesho",
				Age = 20
			};
			return View(customer);
		}
	}
}
