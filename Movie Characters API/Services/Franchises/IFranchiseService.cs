using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.Franchises
{
    public interface IFranchiseService : ICrudService<Franchise, int>
    {
        Task UpdateMoviesInFranchiseAsync(int franchiseId, int[] movieIds);
        Task<ICollection<Movie>> GetMoviesInFranchiseAsync(int franchiseId);
        Task<ICollection<Character>> GetCharactersInFranchiseAsync(int franchiseId);
    }
}
