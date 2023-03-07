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

        public async Task Delete(int franchiseId)
        {
            if (!await FranchiseExistsAsync(franchiseId)) throw new Exception("No franchise with that ID.");

            var franchise = await _context.Franchises
                .Where(f => f.Id == franchiseId)
                .FirstAsync();

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Franchise>> GetAllAsync()
        {
            return await _context.Franchises
                .Include(f => f.Movies)
                .ToListAsync();
        }

        public async Task<Franchise?> GetByIdAsync(int franchiseId)
        {
            if (!await FranchiseExistsAsync(franchiseId)) throw new Exception("No franchise with that ID.");

            return await _context.Franchises
                .Where(f => f.Id == franchiseId)
                .Include(f => f.Movies)
                .FirstAsync();
        }

        public async Task<ICollection<Character>> GetCharactersInFranchiseAsync(int franchiseId)
        {
            if (!await FranchiseExistsAsync(franchiseId)) throw new Exception("No franchise with that ID.");

            return await _context.Characters
                .Where(c => c.FranchiseId == franchiseId)
                .ToListAsync();
        }

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
            if (!await FranchiseExistsAsync(franchiseId)) throw new Exception("No franchise with that ID.");

            var franchise = await _context.Franchises
                .Where(f => f.Id == franchiseId)
                .FirstAsync();

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
