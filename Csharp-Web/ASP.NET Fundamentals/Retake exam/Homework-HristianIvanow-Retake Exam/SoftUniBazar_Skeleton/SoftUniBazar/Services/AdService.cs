namespace SoftUniBazar.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Interfaces;
    using ViewModels.Ad;
    using ViewModels.Category;

    using static Common.GeneralApplicationConstants.Ad;

    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;

        public AdService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AdViewModel>> AllAsync()
        {
            var allAds = await this.dbContext
                .Ads
                .Select(a => new AdViewModel
                {
                    Id = a.Id,
                    Description = a.Description,
                    Category = a.Category.Name,
                    CreatedOn = a.CreatedOn.ToString(DateTimeFormat),
                    ImageUrl = a.ImageUrl,
                    Name = a.Name,
                    Owner = a.Owner.UserName,
                    Price = a.Price,
                })
                .ToArrayAsync();

            return allAds;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            var allCategories = await this.dbContext
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task AddAsync(AdFormModel model, string userId)
        {
            Ad ad = new Ad
            {
                Name = model.Name,
                OwnerId = userId,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CreatedOn = DateTime.Now,
                Description = model.Description,
                CategoryId = model.CategoryId
            };

            await this.dbContext.Ads.AddAsync(ad);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AdFormModel> GetForEditByIdAsync(int id)
        {
            var ad = await this.dbContext
                .Ads
                .FirstOrDefaultAsync(a => a.Id == id);

            if (ad == null)
            {
                return null;
            }

            return new AdFormModel
            {
                Name = ad.Name,
                Description = ad.Description,
                Price = ad.Price,
                ImageUrl = ad.ImageUrl,
                CategoryId = ad.CategoryId,
                Categories = await this.AllCategoriesAsync(),
            };
        }

        public async Task EditBookAsync(AdFormModel model, int id, string userId)
        {
            var ad = await this.dbContext
                .Ads
                .FirstOrDefaultAsync(a => a.Id == id);

            if (ad != null ||
                ad.OwnerId == userId)
            {
                ad.Name = model.Name;
                ad.Description = model.Description;
                ad.CategoryId = model.CategoryId;
                ad.ImageUrl = model.ImageUrl;
                ad.Price = model.Price;

                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<AdViewModel> GetByIdAsync(int id)
        {
            var ad = await this.dbContext
                .Ads
                .Include(a => a.Category)
                .Include(a => a.Owner)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (ad == null)
            {
                return null;
            }

            return new AdViewModel
            {
                Id = ad.Id,
                Name = ad.Name,
                Description = ad.Description,
                Price = ad.Price,
                ImageUrl = ad.ImageUrl,
                Category = ad.Category.Name,
                Owner = ad.Owner.UserName,
                CreatedOn = ad.CreatedOn.ToString(DateTimeFormat),
            };
        }
        public async Task<IEnumerable<AdViewModel>> GetUserAdsAsync(string userId)
        {
            var userAds = await this.dbContext
                .AdsBuyers
                .Where(ab => ab.BuyerId == userId)
                .Select(ab => new AdViewModel
                {
                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    Description = ab.Ad.Description,
                    Category = ab.Ad.Category.Name,
                    CreatedOn = ab.Ad.CreatedOn.ToString(DateTimeFormat),
                    ImageUrl = ab.Ad.ImageUrl,
                    Owner = ab.Ad.Owner.UserName,
                    Price = ab.Ad.Price,
                })
                .ToArrayAsync();

            return userAds;
        }

        public async Task AddToCollectionAsync(string userId, AdViewModel model)
        {
            bool alreadyAdded = await dbContext
                .AdsBuyers
                .AnyAsync(ab => ab.BuyerId == userId && ab.AdId == model.Id);

            if (alreadyAdded == false)
            {
                var userBook = new AdBuyer
                {
                    BuyerId = userId,
                    AdId = model.Id
                };

                await dbContext.AdsBuyers.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCollectionAsync(string userId, AdViewModel ad)
        {
            var adToDelete = await this.dbContext
                .AdsBuyers
                .FirstOrDefaultAsync(ab => ab.BuyerId == userId
                                   && ab.AdId == ad.Id);

            if (adToDelete != null)
            {
                this.dbContext.Remove(adToDelete);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> IsOwnerByUserIdAsync(int id, string userId)
        {
            var ad = await this.dbContext
                .Ads
                .FirstOrDefaultAsync(a => a.Id == id);

            return ad!.OwnerId == userId;
        }
    }
}
