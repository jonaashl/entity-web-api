using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Characters_API.Models;
using Movie_Characters_API.Models.DTOs.CharacterDTOs;
using Movie_Characters_API.Services.Characters;
using System.Net.Mime;

namespace Movie_Characters_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        // GET: api/Characters
        /// <summary>
        /// Get all the characters in a database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters() => Ok(await _characterService.GetAllAsync());

        // GET: api/Characters/5
        /// <summary>
        /// get a character by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            var character = Ok(await _characterService.GetByIdAsync(id));

            if (character == null) return NotFound();

            return Ok(_mapper.Map<CharacterDTO>(character));
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update / Override a character in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add a new character to the DB
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            await _characterService.AddAsync(character);

            return CreatedAtAction("GetMovie", new { id = character.Id }, character);
        }
    }
}
