using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly MovieCharactersDbContext _context;

        public MovieService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task Delete(int id)
        {
            if (!await MovieExistsAsync(id)) throw new Exception("No movie with that ID.");

            var movie = await _context.Movies.FindAsync(id);
            
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync() => await _context.Movies.ToListAsync();

        public async Task<Movie?> GetByIdAsync(int id) => await _context.Movies.FindAsync(id);

        public async Task<ICollection<Character>> GetCharactersInMovieAsync(int movieId)
        {
            if (!await MovieExistsAsync(movieId)) throw new Exception("No movie with that ID.");

            var movie = await _context.Movies.FindAsync(movieId);
            return movie.Characters;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task UpdateCharactersInMovieAsync(int movieId, int[] characterIds)
        {
            if (!await MovieExistsAsync(movieId)) throw new Exception("No movie with that ID.");
            // Get the movie from the database

            List<Character> characters = characterIds
                .ToList()
                .Select(characterIds => _context.Characters
                .Where(c => c.Id == characterIds).First())
                .ToList();

            var movie = await _context.Movies.FindAsync(movieId);

            movie.Characters = characters;
            _context.Entry(movie).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        private async Task<bool> MovieExistsAsync(int id)
        {
            return await _context.Movies.AnyAsync(m => m.Id == id);
        }
    }
}
