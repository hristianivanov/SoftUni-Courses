using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
         
        public string CollertorId { get; set; } = null!;
        [ForeignKey(nameof(CollertorId))]
        public virtual IdentityUser Collector { get; set; } = null!;

        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; } = null!;
    }
}
