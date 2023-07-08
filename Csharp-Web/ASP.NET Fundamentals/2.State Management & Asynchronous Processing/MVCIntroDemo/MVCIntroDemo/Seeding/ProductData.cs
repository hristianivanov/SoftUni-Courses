using MVCIntroDemo.ViewModels.Product;

namespace MVCIntroDemo.Seeding
{
	public static class ProductData
	{
		public static IEnumerable<ProductViewModel> _products
			= new List<ProductViewModel>()
			{
				new ProductViewModel()
				{
					Id = 1,
					Name = "Chese",
					Price = 7.0
				},
				new ProductViewModel()
				{
					Id = 2,
					Name = "Ham",
					Price = 5.5
				},
				new ProductViewModel()
				{
					Id = 3,
					Name = "Bread",
					Price = 1.5
				},
			};
	}
}
