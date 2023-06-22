namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Type
    {
        public Type()
        {
            this.Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
