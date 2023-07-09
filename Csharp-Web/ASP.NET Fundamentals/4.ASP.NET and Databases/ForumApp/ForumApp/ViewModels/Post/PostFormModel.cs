namespace ForumApp.ViewModels.Post
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidations.Post;
	public class PostFormModel
	{
		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]

		public string Title { get; set; } = null!;

		[Required]
		[StringLength(ContentMaxLength, MinimumLength = ContentMinxLength)]
		public string Content { get; set; } = null!;
	}
}
