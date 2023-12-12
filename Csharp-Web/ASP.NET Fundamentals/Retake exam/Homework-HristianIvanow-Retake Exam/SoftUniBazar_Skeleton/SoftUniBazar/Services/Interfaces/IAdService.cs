namespace SoftUniBazar.Services.Interfaces
{
    using ViewModels.Ad;
    using ViewModels.Category;

    public interface IAdService
    {
        Task<IEnumerable<AdViewModel>> AllAsync();
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        Task AddAsync(AdFormModel model,string userId);
        Task<AdFormModel> GetForEditByIdAsync(int id);
        Task EditBookAsync(AdFormModel model, int id,string userId);
        Task<AdViewModel> GetByIdAsync(int id);
        Task AddToCollectionAsync(string userId, AdViewModel model);
        Task<IEnumerable<AdViewModel>> GetUserAdsAsync(string userId);
        Task RemoveFromCollectionAsync(string userId, AdViewModel ad);
        Task<bool> IsOwnerByUserIdAsync(int id, string userId);
    }
}
