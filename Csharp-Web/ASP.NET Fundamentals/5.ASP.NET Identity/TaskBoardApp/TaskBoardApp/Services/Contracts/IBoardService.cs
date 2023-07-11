using TaskBoardApp.ViewModels.Board;
using TaskBoardApp.ViewModels.Task;

namespace TaskBoardApp.Services.Contracts
{
	public interface IBoardService
	{
		Task<IEnumerable<BoardAllViewModel>> GetAllAsync();
		Task<IEnumerable<TaskBoardViewModel>>  GetAllForSelectAsync();
		Task<bool> ExitsByIdAsync(int id);
	}
}
