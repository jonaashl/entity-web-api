using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Services.Franchises;
using Movie_Characters_API.Models;
using System.Net.Mime;

namespace Movie_Characters_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;

        public FranchisesController(IFranchiseService franchiseService)
        {
            _franchiseService = franchiseService;
        }

        // GET: api/Franchises
        /// <summary>
        /// Get all franchises in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises() => Ok(await _franchiseService.GetAllAsync());

        // GET: api/Franchises/5
        /// <summary>
        /// Get a specific database by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            var franchise = Ok(await _franchiseService.GetByIdAsync(id));

            if (franchise == null) return NotFound();

            return franchise;
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update / Override a franchise in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
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

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a new franchise to the database
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            await _franchiseService.AddAsync(franchise);

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }
    }
}
