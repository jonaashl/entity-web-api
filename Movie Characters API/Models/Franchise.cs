using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models
{
    public class Franchise
    {
        public Franchise() 
        {
            Movies = new HashSet<Movie>();
        }


        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
