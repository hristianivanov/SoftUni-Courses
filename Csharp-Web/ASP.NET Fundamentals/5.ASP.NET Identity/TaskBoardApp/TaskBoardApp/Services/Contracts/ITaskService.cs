using TaskBoardApp.ViewModels.Task;

namespace TaskBoardApp.Services.Contracts
{
	public interface ITaskService
	{
		Task AddAsync(string ownerId, TaskFormModel model);
		Task<TaskDetailsViewModel> GetForDetailsByIdAsync(int id);
		Task<TaskFormModel> GetForEditByIdAsync(int id);
		Task EditByIdAsync(int id, TaskFormModel taskModel);
		Task DeleteByIdAsync(int id);
		Task<TaskViewModel> GetForDeleteByIdAsync(int id);
	}
}
