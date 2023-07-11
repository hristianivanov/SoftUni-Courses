using ForumApp.ViewModels.Post;

namespace ForumApp.Services.Contracts
{
	public interface IPostService
	{
		Task<IEnumerable<PostListViewModel>> ListAllAsync();

		Task AddPostAsync(PostFormModel postViewModel);

		Task<PostFormModel> GetForEditByIdAsync(int id);

		Task EditByIdAsync(int id, PostFormModel postEditedModel);

		Task DeleteByIdAsync(int id);
	}
}
