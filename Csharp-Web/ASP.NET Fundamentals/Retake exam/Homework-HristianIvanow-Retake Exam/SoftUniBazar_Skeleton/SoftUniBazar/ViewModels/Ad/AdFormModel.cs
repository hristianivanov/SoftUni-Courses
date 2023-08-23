namespace SoftUniBazar.ViewModels.Ad
{
    using System.ComponentModel.DataAnnotations;

    using Category;
    using static Common.GeneralApplicationConstants.Ad;

    public class AdFormModel
    {
        public AdFormModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
