namespace TaskBoardApp.Services.Contracts
{
	using ViewModels.Home;
	public interface IHomeService
	{
		Task<int> GetAllTasksCountAsync();
		Task<int> GetTasksCountByBoardNameAsync(string boardName);
		Task<IEnumerable<HomeBoardModel>> GetTasksCountsAsync();
		Task<int> GetUserTasksCountByIdAsync(string userId);
	}
}
