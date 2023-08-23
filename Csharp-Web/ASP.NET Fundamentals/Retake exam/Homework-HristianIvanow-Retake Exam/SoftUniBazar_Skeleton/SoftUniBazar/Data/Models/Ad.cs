namespace SoftUniBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using static Common.GeneralApplicationConstants.Ad;

    public class Ad
    {
        public Ad()
        {
            this.AdBuyers = new HashSet<AdBuyer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string OwnerId { get; set; } = null!;

        public IdentityUser Owner { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<AdBuyer> AdBuyers { get; set; }
    }
}
