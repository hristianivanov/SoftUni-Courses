namespace ForumApp.Controllers
{
	using ViewModels.Post;
	using Microsoft.AspNetCore.Mvc;

	using Services.Contracts;

	public class PostController : Controller
	{
		private readonly IPostService postService;

		public PostController(IPostService postService)
		{
			this.postService = postService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var allPosts =
				await this.postService.ListAllAsync();

			return View(allPosts);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		=> View();

		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await postService.AddPostAsync(model);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your post!");

				return View(model);
			}

			return RedirectToAction("All");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var postModel = await postService.GetForEditByIdAsync(id);

				return View(postModel);
			}
			catch (Exception)
			{
				return RedirectToAction("All", "Post");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PostFormModel postModel)
		{
			if (!ModelState.IsValid)
			{
				return View(postModel);
			}

			try
			{
				await postService.EditByIdAsync(id, postModel);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating your post!");

				return View(postModel);
			}

			return RedirectToAction("All", "Post");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await postService.DeleteByIdAsync(id);
			}
			catch (Exception)
			{

			}

			return RedirectToAction("All", "Post");
		}
	}
}
