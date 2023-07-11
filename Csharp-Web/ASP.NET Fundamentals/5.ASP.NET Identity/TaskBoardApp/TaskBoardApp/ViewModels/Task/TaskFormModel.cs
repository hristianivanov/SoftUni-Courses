namespace TaskBoardApp.ViewModels.Task
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationsConstants.Task;
	public class TaskFormModel
	{
		public TaskFormModel()
		{
			this.Boards = new HashSet<TaskBoardViewModel>();
		}

		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
			ErrorMessage = "Title should be at least {2} characters long.")]
		public string Title { get; set; } = null!;
		[Required]
		[StringLength(DescriptionMaxLength,MinimumLength =DescriptionMinLength,
			ErrorMessage = "Description should be at least {2} characters long.")]
		public string Description { get; set; } = null!;
		[Display(Name = "Board")]
		public int BoardId { get; set; }
		public IEnumerable<TaskBoardViewModel> Boards { get; set; }
	}
}
