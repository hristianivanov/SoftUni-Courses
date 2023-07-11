namespace TaskBoardApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.Contracts;
	using TaskBoardApp.ViewModels.Task;

	[Authorize]
	public class BoardController : Controller
	{
		private readonly IBoardService boardService;

		public BoardController(IBoardService boardService)
		{
			this.boardService = boardService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var boards = await this.boardService.GetAllAsync();

			return View(boards);
		}
	}
}
