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

        public async Task<Franchise> GetByIdAsync(int id) => await _context.Franchises.FindAsync(id);

        public async Task<Franchise> UpdateAsync(Franchise entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
