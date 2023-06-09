﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Movie_Characters_API.Models;
using Movie_Characters_API.Models.DTOs.CharacterDTOs;
using Movie_Characters_API.Models.DTOs.MovieDTOs;
using Movie_Characters_API.Services.Movies;
using System.Net.Mime;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/movies")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]

    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;


        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/v1/movies
        /// <summary>
        /// Get all the movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            return Ok(
                _mapper.Map<List<MovieDTO>>(
                await _movieService.GetAllAsync()));
        }

        // GET: api/v1/movies/5
        /// <summary>
        /// Get movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);

            if (movie == null) return NotFound();

            return Ok(_mapper.Map<MovieDTO>(movie));
        }

        // PUT: api/v1/movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MoviePutDTO movieDTO)
        {
            if (id != movieDTO.Id)
            {
                return BadRequest();
            }
            await _movieService.UpdateAsync(_mapper.Map<Movie>(movieDTO));

            return NoContent();
        }

        // POST: api/v1/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a new movie
        /// </summary>
        /// <param name="moviePostDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostMovie(MoviePostDTO moviePostDTO)
        {
            var movie = _mapper.Map<Movie>(moviePostDTO);
            await _movieService.AddAsync(movie); 

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // GET: api/v1/movies/5/characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Get all characters in a movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterSummaryDTO>>> GetCharactersInMovie(int id)
        {
            return Ok(
                _mapper.Map<List<CharacterSummaryDTO>>(
                await _movieService.GetCharactersInMovieAsync(id)));
        }

        // PUT: api/v1/movies/5/characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update what characters are in a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterIds"></param>
        /// <returns></returns>
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateCharactersInMovie(int id, int[] characterIds)
        {
            await _movieService.UpdateCharactersInMovieAsync(id, characterIds);

            return NoContent();
        }

        /// <summary>
        /// Delete a movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.Delete(id);

            return NoContent();
        }
    }
}
