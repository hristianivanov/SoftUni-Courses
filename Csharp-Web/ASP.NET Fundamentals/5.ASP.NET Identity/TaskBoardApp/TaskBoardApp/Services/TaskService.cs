using Microsoft.EntityFrameworkCore;

namespace TaskBoardApp.Services
{
	using Contracts;
	using Data;
	using ViewModels.Task;
	public class TaskService : ITaskService
	{
		private readonly TaskBoardAppDbContext context;
		private readonly IBoardService boardService;

		public TaskService(TaskBoardAppDbContext context, IBoardService boardService)
		{
			this.context = context;
			this.boardService = boardService;
		}

		public async Task AddAsync(string ownerId, TaskFormModel model)
		{
			var task = new Data.Models.Task()
			{
				Title = model.Title,
				Description = model.Description,
				BoardId = model.BoardId,
				CreatedOn = DateTime.UtcNow,
				OwnerId = ownerId,
			};

			await context.Tasks.AddAsync(task);
			await context.SaveChangesAsync();
		}

		public async Task<TaskDetailsViewModel> GetForDetailsByIdAsync(int id)
		{
			var model = await context.Tasks
				.Select(t => new TaskDetailsViewModel
				{
					Id = t.Id,
					Title = t.Title,
					Board = t.Board!.Name,
					CreatedOn = t.CreatedOn.ToString("f"),
					Description = t.Description,
					Owner = t.Owner.UserName,
				})
				.FirstAsync(t => t.Id == id);

			return model;
		}

		public async Task<TaskFormModel> GetForEditByIdAsync(int id)
		{
			Data.Models.Task task = (await context.Tasks
				.FindAsync(id))!;

			return new TaskFormModel()
			{

				Title = task!.Title,
				Description = task.Description,
				BoardId = task.BoardId,
				Boards = await boardService.GetAllForSelectAsync()
			};
		}

		public async Task EditByIdAsync(int id, TaskFormModel taskModel)
		{
			Data.Models.Task? taskToEdit = await context.Tasks
				.FindAsync(id);

			taskToEdit!.Title = taskModel.Title;
			taskToEdit!.Description = taskModel.Description;
			taskToEdit!.BoardId = taskModel.BoardId;

			await context.SaveChangesAsync();
		}

		public async Task DeleteByIdAsync(int id)
		{
			Data.Models.Task? taskToDelete = await context.Tasks
				.FindAsync(id);

			if (taskToDelete != null)
			{
				context.Tasks.Remove(taskToDelete);
				await context.SaveChangesAsync();
			}
		}

		public async Task<TaskViewModel> GetForDeleteByIdAsync(int id)
		{
			TaskViewModel task = await context.Tasks
				.Select(t => new TaskViewModel
				{
					Id = t.Id,
					Title = t.Title,
					Description = t.Description,
				})
				.FirstAsync(t => t.Id == id);

			return task;
		}
	}
}
