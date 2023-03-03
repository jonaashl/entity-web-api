using Microsoft.EntityFrameworkCore;

namespace Movie_Characters_API.Models
{
    public class MovieCharactersDbContext : DbContext
    {
        public MovieCharactersDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; } = null!;
        public virtual DbSet<Franchise> Franchises { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    MovieTitle = "Harry Potter and the Philosopher's Stone",
                    Genre = "Adventure, Family, Fantasy",
                    ReleaseYear = 2001,
                    Director = "Chris Colombus",
                    Picture = "https://www.imdb.com/title/tt0241527/mediaviewer/rm2105413120/",
                    Trailer = "https://www.imdb.com/video/vi3115057433/?playlistId=tt0241527",
                    FranchiseId = 1
                },
                new Movie()
                {
                    Id = 2,
                    MovieTitle = "Harry Potter and the Half-Blood Prince",
                    Genre = "Action, Adventure, Family, Fantasy, Mystery",
                    ReleaseYear = 2009,
                    Director = "David Yates",
                    Picture = "https://www.imdb.com/title/tt0417741/mediaviewer/rm282560512/",
                    Trailer = "https://www.imdb.com/video/vi1061421849/?playlistId=tt0417741",
                    FranchiseId = 1
                },
                new Movie()
                {
                    Id = 3,
                    MovieTitle = "The Lord of the Rings: The Fellowship of the Ring",
                    Genre = "Action, Adventure, Drama, Fantasy",
                    ReleaseYear = 2001,
                    Director = "Peter Jackson",
                    Picture = "https://www.imdb.com/title/tt0120737/mediaviewer/rm3592958976/",
                    Trailer = "https://www.imdb.com/video/vi684573465/?playlistId=tt0120737",
                    FranchiseId = 2
                }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character()
                {
                    Id = 1,
                    Name = "Harry Potter",
                    Alias = "The boy who lived",
                    Gender = "Male",
                    Picture = "https://www.imdb.com/title/tt0241527/mediaviewer/rm2113437952",
                    FranchiseId = 1
                },
                new Character()
                {
                    Id = 2,
                    Name = "Hermoine Granger",
                    Gender = "Female",
                    Picture = "https://www.imdb.com/title/tt0241527/mediaviewer/rm2923487745/",
                    FranchiseId = 1
                },
                new Character()
                {
                    Id = 3,
                    Name = "Horace Slughorn",
                    Alias = "Professor Slughorn",
                    Gender = "Male",
                    Picture = "https://www.imdb.com/title/tt0417741/mediaviewer/rm1934071552",
                    FranchiseId = 1
                },
                new Character()
                {
                    Id = 4,
                    Name = "Frodo Baggins",
                    Gender = "Male",
                    Picture = "https://www.imdb.com/title/tt0120737/mediaviewer/rm2645131264",
                    FranchiseId = 2
                },
                new Character()
                {
                    Id = 5,
                    Name = "Aragorn",
                    Alias = "Strider",
                    Gender = "Male",
                    Picture = "https://www.imdb.com/title/tt0120737/mediaviewer/rm2368970240",
                    FranchiseId = 2
                }
            );

            modelBuilder.Entity<Franchise>().HasData(
                new Franchise()
                {
                    Id = 1,
                    Name = "Harry Potter",
                    Description = "Harry Potter is a film series based on the eponymous novels by J. K. Rowling. The series is produced and distributed by Warner Bros. Pictures and consists of eight fantasy films, beginning with Harry Potter and the Philosopher's Stone (2001) and culminating with Harry Potter and the Deathly Hallows – Part 2 (2011)."
                },
                new Franchise()
                {
                    Id = 2,
                    Name = "Lord of the Rings",
                    Description = "The Lord of the Rings is a series of three epic fantasy adventure films directed by Peter Jackson, based on the novel The Lord of the Rings by J. R. R. Tolkien. The films are subtitled The Fellowship of the Ring (2001), The Two Towers (2002), and The Return of the King (2003)."
                }
            );

            modelBuilder.Entity<Movie>()
                .HasMany(mov => mov.Characters)
                .WithMany(chr => chr.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCharacter",
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("MovieId", "CharacterId");
                        je.HasData(
                            new { MovieId = 1, CharacterId = 1 },
                            new { MovieId = 1, CharacterId = 2 },
                            new { MovieId = 2, CharacterId = 1 },
                            new { MovieId = 2, CharacterId = 2 },
                            new { MovieId = 2, CharacterId = 3 },
                            new { MovieId = 3, CharacterId = 4 },
                            new { MovieId = 3, CharacterId = 5 }
                        );
                    }
            );

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Franchise)
                .WithMany(f => f.Movies)
                .HasForeignKey(m => m.FranchiseId);

            modelBuilder.Entity<Franchise>()
                .HasMany(f => f.Movies)
                .WithOne(m => m.Franchise)
                .HasForeignKey(m => m.FranchiseId);
        }
    }
}
