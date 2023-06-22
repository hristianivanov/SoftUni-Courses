namespace Homies.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        public Event()
        {
            this.EventsParticipants = new HashSet<EventParticipant>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        public string Description { get; set; } = null!;

        [Required]
        public string OrganiserId { get; set; } = null!;
        public IdentityUser Organiser { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        public virtual Type Type { get; set; } = null!;

        public virtual ICollection<EventParticipant> EventsParticipants { get; set; }
    }
}
