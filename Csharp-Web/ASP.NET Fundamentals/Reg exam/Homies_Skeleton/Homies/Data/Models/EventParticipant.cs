namespace Homies.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventParticipant
    {
        [ForeignKey(nameof(Helper))]
        public string HelperId { get; set; }
        public IdentityUser Helper { get; set; } = null!;

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; } = null!;
    }
}
