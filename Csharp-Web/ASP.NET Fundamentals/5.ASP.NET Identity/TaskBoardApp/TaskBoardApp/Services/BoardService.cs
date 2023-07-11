namespace TaskBoardApp.Services
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Contracts;
	using ViewModels.Board;
	using ViewModels.Task;

	public class BoardService : IBoardService
	{
		private readonly TaskBoardAppDbContext context;

		public BoardService(TaskBoardAppDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<BoardAllViewModel>> GetAllAsync()
		{
			var allBoards = await context.Boards
				.Select(b => new BoardAllViewModel
				{
					Id = b.Id,
					Name = b.Name,
					Tasks = b.Tasks.Select(t => new TaskViewModel
					{
						Id = t.Id,
						Title = t.Title,
						Description = t.Description,
						Owner = t.Owner.UserName,
					}).ToArray(),
				}).ToArrayAsync();

			return allBoards;
		}

		public async Task<IEnumerable<TaskBoardViewModel>> GetAllForSelectAsync()
		{
			var boards = await context.Boards
				.Select(b => new TaskBoardViewModel
				{
					Id = b.Id,
					Name = b.Name,
				}).ToArrayAsync();

			return boards;
		}

		public async Task<bool> ExitsByIdAsync(int id)
		=> await context.Boards.AnyAsync(b => b.Id == id);
	}
}
