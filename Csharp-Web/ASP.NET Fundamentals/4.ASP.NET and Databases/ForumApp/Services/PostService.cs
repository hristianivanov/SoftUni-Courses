namespace ForumApp.Services
{

	using Microsoft.EntityFrameworkCore;

	using Data;
	using Contracts;
	using ViewModels.Post;
	using Data.Models;

	public class PostService : IPostService
	{
		private readonly ForumAppDbContext context;

		public PostService(ForumAppDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
		{
			var allPosts = await context.Posts
				.Select(p => new PostListViewModel
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content
				})
				.ToArrayAsync();

			return allPosts;
		}

		public async Task AddPostAsync(PostFormModel postViewModel)
		{
			Post newPost = new Post
			{
				Title = postViewModel.Title,
				Content = postViewModel.Content
			};

			await context.Posts.AddAsync(newPost);
			await context.SaveChangesAsync();
		}

		public async Task<PostFormModel> GetForEditByIdAsync(int id)
		{
			Post postToEdit = await context.Posts
				.FindAsync(id);

			return new PostFormModel
			{
				Title = postToEdit.Title,
				Content = postToEdit.Content
			};
		}

		public async Task EditByIdAsync(int id, PostFormModel postEditedModel)
		{
			Post postToEdit = await context.Posts
				.FindAsync(id);

			postToEdit.Title = postEditedModel.Title;
			postToEdit.Content = postEditedModel.Content;

			await context.SaveChangesAsync();
		}

		public async Task DeleteByIdAsync(int id)
		{
			Post? postToDelete = await context.Posts
				.FindAsync(id);

			if (postToDelete != null)
			{
				context.Remove(postToDelete);
				await context.SaveChangesAsync();
			}

		}
	}
}
