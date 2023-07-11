namespace TaskBoardApp.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using ViewModels.Home;
	using Services.Contracts;
	using Extensions;

	public class HomeController : Controller
	{
		private readonly IHomeService homeService;
		public HomeController(IHomeService homeService)
		{
			this.homeService = homeService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			string currUserId = User.GetId();

			var homeModel = new HomeViewModel()
			{
				AllTasksCount = await homeService.GetAllTasksCountAsync(),
				BoardsWithTasksCount = await homeService.GetTasksCountsAsync(),
				UserTasksCount = await homeService.GetUserTasksCountByIdAsync(currUserId)
			};

            return View(homeModel);
		}
	}
}
