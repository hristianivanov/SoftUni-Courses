using Microsoft.EntityFrameworkCore;

namespace TaskBoardApp.Services
{
	using Contracts;
	using Data;
	using ViewModels.Task;
	public class TaskService : ITaskService
	{
		private readonly TaskBoardAppDbContext context;

        public TaskService(TaskBoardAppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(string ownerId, TaskFormModel model)
        {
	        var task = new Data.Models.Task()
	        {
		        Title = model.Title,
		        Description = model.Description,
		        BoardId = model.BoardId,
		        CreatedOn = DateTime.UtcNow,
		        OwnerId = ownerId,
	        };

	        await context.Tasks.AddAsync(task);
	        await context.SaveChangesAsync();
        }

        public async Task<TaskDetailsViewModel> GetForDetailsByIdAsync(int id)
        {
	        var model = await context.Tasks
		        .Select(t => new TaskDetailsViewModel
		        {
			        Id = t.Id,
			        Title = t.Title,
			        Board = t.Board!.Name,
			        CreatedOn = t.CreatedOn.ToString("f"),
			        Description = t.Description,
			        Owner = t.Owner.UserName,
		        })
		        .FirstAsync(t => t.Id == id);

	        return model;
        }
	}
}
