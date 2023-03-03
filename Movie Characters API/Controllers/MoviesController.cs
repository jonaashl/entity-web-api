using Microsoft.AspNetCore.Mvc;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.Movies;

namespace Movie_Characters_API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies() => Ok(await _movieService.GetAllAsync());

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = Ok(await _movieService.GetByIdAsync(id));

            if (movie == null) return NotFound();

            return movie;
        }

        // PUT: api/movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            
            await _movieService.UpdateAsync(movie);

            return NoContent();
        }

        // POST: api/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostMovie(Movie movie)
        {
            await _movieService.AddAsync(movie);

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // GET: api/movies/5/characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersInMovie(int movieId)
        {
            return Ok(await _movieService.GetCharactersInMovieAsync(movieId));
        }

        // PUT: api/movies/5/characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/characters")]
        public async Task<ActionResult<Movie>> UpdateCharactersInMovie(int id, int[] characterIds)
        {
            await _movieService.UpdateCharactersInMovieAsync(id, characterIds);

            return NoContent();
        }
    }
}
