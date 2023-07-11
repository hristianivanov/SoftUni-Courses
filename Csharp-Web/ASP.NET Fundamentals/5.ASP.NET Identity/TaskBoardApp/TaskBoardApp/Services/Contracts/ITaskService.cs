using TaskBoardApp.ViewModels.Task;

namespace TaskBoardApp.Services.Contracts
{
	public interface ITaskService
	{
		Task AddAsync(string ownerId, TaskFormModel model);
		Task<TaskDetailsViewModel> GetForDetailsByIdAsync(int id);
	}
}
