namespace TaskBoardApp.ViewModels.Home
{
	public class HomeViewModel
	{
        public HomeViewModel()
        {
	        this.BoardsWithTasksCount = new List<HomeBoardModel>();
        }

        public int AllTasksCount { get; set; }
        public IEnumerable<HomeBoardModel> BoardsWithTasksCount { get; set; }
        public int UserTasksCount { get; set; }
    }
}
