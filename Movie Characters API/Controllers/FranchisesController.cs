using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;
using System.Net.Mime;
using Movie_Characters_API.Services.Franchises;
using AutoMapper;
using Movie_Characters_API.Models.DTOs.FranchiseDTOs;
using Movie_Characters_API.Models.DTOs.MovieDTOs;
using Movie_Characters_API.Models.DTOs.CharacterDTOs;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/franchises")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        // GET: api/franchises
        /// <summary>
        /// Get all franchises in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {

            return Ok(
                _mapper.Map<List<FranchiseDTO>>(
                await _franchiseService.GetAllAsync()));
        }

        // GET: api/franchises/5
        /// <summary>
        /// Get a specific database by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            var franchise = await _franchiseService.GetByIdAsync(id);

            if (franchise == null) return NotFound();

            return Ok(_mapper.Map<FranchiseDTO>(franchise));
        }

        // PUT: api/franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update / Override a franchise in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchiseDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDTO franchiseDTO)
        {
            if (id != franchiseDTO.Id)
            {
                return BadRequest();
            }

            await _franchiseService.UpdateAsync(_mapper.Map<Franchise>(franchiseDTO));

            return NoContent();
        }

        // POST: api/franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a new franchise to the database
        /// </summary>
        /// <param name="franchisePostDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostFranchise(FranchisePostDTO franchisePostDTO)
        {
            var franchise = _mapper.Map<Franchise>(franchisePostDTO);
            await _franchiseService.AddAsync(franchise);

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // GET: api/franchises/5/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Get all movies in a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieSummaryDTO>>> GetMoviesInFranchise(int id)
        {
            return Ok(
                _mapper.Map<List<MovieSummaryDTO>>(
                await _franchiseService.GetMoviesInFranchiseAsync(id)));
        }

        // GET: api/franchises/5/characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Get the Characters in a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterSummaryDTO>>> GetCharactersInFranchise(int id)
        {
            return Ok(
                _mapper.Map<List<CharacterSummaryDTO>>(
                await _franchiseService.GetCharactersInFranchiseAsync(id)));
        }

        // PUT: api/franchises/5/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update what movies are in a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesInFranchise(int id, int[] movieIds)
        {
            await _franchiseService.UpdateMoviesInFranchiseAsync(id, movieIds);

            return NoContent();
        }
        /// <summary>
        /// Delete a Franchise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            await _franchiseService.Delete(id);

            return NoContent();
        }

    }
}
