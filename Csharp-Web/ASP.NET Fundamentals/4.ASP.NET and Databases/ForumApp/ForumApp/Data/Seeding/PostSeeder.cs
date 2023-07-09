namespace ForumApp.Data.Seeding
{

	using Models;

	class PostSeeder
	{
		internal ICollection<Post> GeneratePosts()
		{
			ICollection<Post> posts = new HashSet<Post>();

			posts.Add(new Post
			{
				Id = 1,
				Title = "My first post",
				Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
			});
			posts.Add(new Post
			{
				Id = 2,
				Title = "My second post",
				Content = "CRUD operations in MVC are getting more and more interesting!"
			});
			posts.Add(new Post
			{
				Id = 3,
				Title = "My third post",
				Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
			});

			return posts;
		}
	}
}
