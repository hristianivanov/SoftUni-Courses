using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required, MinLength(3), MaxLength(40)]
        [RegularExpression(@"^[a-zA-Z0-9\s.-]+$")]
        public string Name { get; set; } = null!;

        [Required, MinLength(2), MaxLength(40)]
        public string Nationality { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
