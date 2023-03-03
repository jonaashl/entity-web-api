using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.Franchises
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieCharactersDbContext _context;

        public FranchiseService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<Franchise> AddAsync(Franchise entity)
        {
            await _context.Franchises.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Franchise>> GetAllAsync() => await _context.Franchises.ToListAsync();

        public async Task<Franchise?> GetByIdAsync(int id) => await _context.Franchises.FindAsync(id);

        public async Task<ICollection<Movie>> GetMoviesInFranchiseAsync(int franchiseId)
        {
            if (!await FranchiseExistsAsync(franchiseId)) throw new Exception("No franchise with that ID.");

            return await _context.Movies
                .Where(m => m.FranchiseId == franchiseId)
                .ToListAsync();
        }

        public async Task<Franchise> UpdateAsync(Franchise entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateMoviesInFranchiseAsync(int franchiseId, int[] movieIds)
        {
            // Get the movie from the database
            var franchise = await _context.Franchises.FindAsync(franchiseId) ?? throw new Exception("No franchise with that ID.");

            List<Movie> movies = movieIds
                .ToList()
                .Select(movieIds => _context.Movies
                .Where(m => m.Id == movieIds).First())
                .ToList();

            franchise.Movies = movies;
            _context.Entry(franchise).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        private async Task<bool> FranchiseExistsAsync(int id)
        {
            return await _context.Franchises.AnyAsync(f => f.Id == id);
        }
    }
}
