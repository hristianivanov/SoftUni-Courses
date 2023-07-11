namespace TaskBoardApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Extensions;
	using Services.Contracts;
	using ViewModels.Task;

	[Authorize]
	public class TaskController : Controller
	{
		private readonly IBoardService boardService;
		private readonly ITaskService taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
			this.taskService = taskService;
        }

        [HttpGet]
		public async Task<IActionResult> Create()
		{
			TaskFormModel model = new TaskFormModel()
			{
				Boards = await this.boardService.GetAllForSelectAsync()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(TaskFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Boards = await this.boardService.GetAllForSelectAsync();
				return View(model);
			}

			if (!await boardService.ExitsByIdAsync(model.BoardId))
			{
				ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist!");
				model.Boards = await this.boardService.GetAllForSelectAsync();
				return View(model);
			}

			string currUserId = User.GetId();

			await taskService.AddAsync(currUserId, model);

			return RedirectToAction("All", "Board");
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			try
			{
				var vireModel = await taskService.GetForDetailsByIdAsync(id);

				return View(vireModel);
			}
			catch (Exception)
			{
				return RedirectToAction("All", "Board");
			}
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var taskModel = await taskService.GetForEditByIdAsync(id);

				return View(taskModel);
			}
			catch (Exception)
			{
				return RedirectToAction("All", "Board");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
		{
			if (!ModelState.IsValid)
			{
				return View(taskModel);
			}

			try
			{
				await taskService.EditByIdAsync(id,taskModel);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating your post!");

				return View(taskModel);
			}

			return RedirectToAction("All", "Board");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var taskModel = await taskService.GetForDeleteByIdAsync(id);

				return View(taskModel);
			}
			catch (Exception)
			{
				return RedirectToAction("All", "Board");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id, TaskViewModel taskModel)
		{
			try
			{
				await taskService.DeleteByIdAsync(id);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while deleting your post!");
				return View(taskModel);
			}

			return RedirectToAction("All", "Board");
		}
	}
}
