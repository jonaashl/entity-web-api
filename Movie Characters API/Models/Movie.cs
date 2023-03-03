using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models
{
    public class Movie
    {
        public Movie()
        {
            Characters = new HashSet<Character>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string MovieTitle { get; set; } = null!;
        [StringLength(50)]
        public string? Genre { get; set; }
        public int? ReleaseYear { get; set; }
        [StringLength(50)]
        public string? Director { get; set; }
        [StringLength(250)]
        public string? Picture { get; set; } // URL to picture
        [StringLength(250)]
        public string? Trailer { get; set; } // URL to trailer
        public virtual ICollection<Character> Characters { get; set; }
        public virtual Franchise? Franchise { get; set; }
        public int? FranchiseId { get; set; }
    }
}
