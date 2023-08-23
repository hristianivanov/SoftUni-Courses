namespace SoftUniBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    public class AdBuyer
    {
        [ForeignKey(nameof(Buyer))]
        public string BuyerId { get; set; } = null!;

        public IdentityUser Buyer { get; set; } = null!;

        [ForeignKey(nameof(Ad))]
        public int AdId { get; set; }

        public Ad Ad { get; set; } = null!;
    }
}
