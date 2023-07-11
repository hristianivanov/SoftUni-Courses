namespace TaskBoardApp.ViewModels.Board
{
	using Task;
	public class BoardAllViewModel
	{
		public BoardAllViewModel()
		{
			Tasks = new HashSet<TaskViewModel>();
		}

		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public ICollection<TaskViewModel> Tasks { get; set; }
	}
}
