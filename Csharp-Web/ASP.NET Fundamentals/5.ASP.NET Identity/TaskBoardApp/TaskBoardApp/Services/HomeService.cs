namespace TaskBoardApp.Services
{
	using Data;
	using Contracts;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Home;

	public class HomeService : IHomeService
	{
		private readonly TaskBoardAppDbContext _context;

		public HomeService(TaskBoardAppDbContext context)
		{
			this._context = context;
		}

		public async Task<int> GetAllTasksCountAsync()
		=> await _context.Tasks.CountAsync();

		public async Task<int> GetTasksCountByBoardNameAsync(string boardName)
		=> await _context.Tasks
			.Where(t => t.Board!.Name == boardName)
			.CountAsync();

		public async Task<IEnumerable<HomeBoardModel>> GetTasksCountsAsync()
		{
			var taskBoards = await _context.Boards
					.Select(b => b.Name)
					.Distinct()
					.ToArrayAsync();

			var tasksCounts = new List<HomeBoardModel>();

			foreach (var boardName in taskBoards)
			{
				var tasksInBoard = await _context.Tasks
					.Where(t => t.Board!.Name == boardName)
					.CountAsync();

				tasksCounts.Add(new HomeBoardModel
				{
					BoardName = boardName,
					TasksCount = tasksInBoard
				});
			}

			return tasksCounts;
		}

		public async Task<int> GetUserTasksCountByIdAsync(string userId)
		=> await _context.Tasks
			.Where(t => t.OwnerId == userId)
			.CountAsync();
	}
}
