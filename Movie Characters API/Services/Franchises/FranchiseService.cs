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

        public Task<Franchise> AddAsync(Franchise entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Franchise>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Franchise> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Franchise> UpdateAsync(Franchise entity)
        {
            throw new NotImplementedException();
        }
    }
}
