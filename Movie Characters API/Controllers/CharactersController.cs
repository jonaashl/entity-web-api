using Microsoft.AspNetCore.Mvc;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.Characters;

namespace Movie_Characters_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters() => Ok(await _characterService.GetAllAsync());

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = Ok(await _characterService.GetByIdAsync(id));

            if (character == null) return NotFound();

            return character;
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            await _characterService.UpdateAsync(character);

            return NoContent();
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            await _characterService.AddAsync(character);

            return CreatedAtAction("GetMovie", new { id = character.Id }, character);
        }
    }
}
