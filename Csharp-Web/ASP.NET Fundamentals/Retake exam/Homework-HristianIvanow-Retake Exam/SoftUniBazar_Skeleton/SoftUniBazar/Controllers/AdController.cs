namespace SoftUniBazar.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Interfaces;
    using ViewModels.Ad;

    public class AdController : BaseController
    {
        private readonly IAdService adService;

        public AdController(IAdService adService)
        {
            this.adService = adService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            AdAllViewModel model = new AdAllViewModel()
            {
                Ads = await this.adService.AllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AdFormModel model = new AdFormModel()
            {
                Categories = await this.adService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.adService.AddAsync(model,GetUserId());

                return this.RedirectToAction("All");
            }
            catch (Exception)
            {
                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool isCurrUserOwnerOfTheAd = await this.adService.IsOwnerByUserIdAsync(id, GetUserId());

            if (!isCurrUserOwnerOfTheAd)
            {
                return this.RedirectToAction("All");
            }

            AdFormModel model = await this.adService.GetForEditByIdAsync(id);

            if (model == null)
            {
                return this.RedirectToAction("All");
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdFormModel model)
        {
            bool isCurrUserOwnerOfTheAd = await this.adService.IsOwnerByUserIdAsync(id, GetUserId());

            if (!isCurrUserOwnerOfTheAd)
            {
                return this.RedirectToAction("All");
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.adService.EditBookAsync(model, id,GetUserId());

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            AdAllViewModel model = new AdAllViewModel()
            {
                Ads = await this.adService.GetUserAdsAsync(GetUserId())
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var ad = await this.adService.GetByIdAsync(id);

            if (ad == null)
            {
                return this.RedirectToAction("All");
            }

            await this.adService.AddToCollectionAsync(GetUserId(), ad);

            return this.RedirectToAction("Cart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var ad = await this.adService.GetByIdAsync(id);

            if (ad == null)
            {
                return this.RedirectToAction("All");
            }

            await this.adService.RemoveFromCollectionAsync(GetUserId(),ad);

            return this.RedirectToAction("All");
        }
    }
}
