using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.Movies;
using System.Net.Mime;

namespace Movie_Characters_API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]

    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movies
        /// <summary>
        /// Get all the movies in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies() => Ok(await _movieService.GetAllAsync());

        // GET: api/movies/5
        /// <summary>
        /// Get movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = Ok(await _movieService.GetByIdAsync(id));

            if (movie == null) return NotFound();

            return movie;
        }

        // PUT: api/movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Override / update a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            
            await _movieService.UpdateAsync(movie);

            return NoContent();
        }

        // POST: api/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostMovie(Movie movie)
        {
            await _movieService.AddAsync(movie);

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // GET: api/movies/5/characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersInMovie(int id)
        {
            return Ok(await _movieService.GetCharactersInMovieAsync(id));
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
