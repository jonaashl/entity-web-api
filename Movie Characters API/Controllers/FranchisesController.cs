using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.Franchises;

namespace Movie_Characters_API.Controllers
{
    [Route("api/franchises")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;

        public FranchisesController(IFranchiseService franchiseService)
        {
            _franchiseService = franchiseService;
        }

        // GET: api/franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises() => Ok(await _franchiseService.GetAllAsync());

        // GET: api/franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            var franchise = Ok(await _franchiseService.GetByIdAsync(id));

            if (franchise == null) return NotFound();

            return franchise;
        }

        // PUT: api/franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            await _franchiseService.UpdateAsync(franchise);

            return NoContent();
        }

        // POST: api/franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            await _franchiseService.AddAsync(franchise);

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // GET: api/franchises/5/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesInFranchise(int franchiseId)
        {
            return Ok(await _franchiseService.GetMoviesInFranchiseAsync(franchiseId));
        }

        // GET: api/franchises/5/characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersInFranchise(int franchiseId)
        {
            return Ok(await _franchiseService.GetCharactersInFranchiseAsync(franchiseId));
        }

        // PUT: api/franchises/5/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/movies")]
        public async Task<ActionResult<Franchise>> UpdateMoviesInFranchise(int id, int[] movieIds)
        {
            await _franchiseService.UpdateMoviesInFranchiseAsync(id, movieIds);

            return NoContent();
        }
    }
}
