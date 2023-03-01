using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieCharactersDbContext _context;

        public CharacterService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public Task<Character> AddAsync(Character entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Character> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Character> UpdateAsync(Character entity)
        {
            throw new NotImplementedException();
        }
    }
}
