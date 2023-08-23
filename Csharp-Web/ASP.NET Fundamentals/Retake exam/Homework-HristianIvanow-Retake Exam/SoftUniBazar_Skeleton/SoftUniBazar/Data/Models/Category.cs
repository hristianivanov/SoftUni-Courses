﻿namespace SoftUniBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.GeneralApplicationConstants.Category;

    public class Category
    {
        public Category()
        {
            this.Ads = new HashSet<Ad>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Ad> Ads { get; set; }
    }
}
