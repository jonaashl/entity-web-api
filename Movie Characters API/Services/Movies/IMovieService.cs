using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.Movies
{
    public interface IMovieService : ICrudService<Movie, int>
    {
        Task<ICollection<Character>> GetCharactersInMovieAsync(int movieId);
        Task UpdateCharactersInMovieAsync(int movieId, int[] characterIds);
    }
}
