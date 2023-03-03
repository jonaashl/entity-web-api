using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Characters_API.Models;
using Movie_Characters_API.Models.DTOs.CharacterDTOs;
using Movie_Characters_API.Services.Characters;
using System.Net.Mime;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/characters")]
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

        // GET: api/characters
        /// <summary>
        /// Get all the characters in a database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters() => Ok(
            _mapper.Map<List<CharacterDTO>>(
            await _characterService.GetAllAsync()));

        // GET: api/characters/5
        /// <summary>
        /// get a character by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            var character = await _characterService.GetByIdAsync(id);

            if (character == null) return NotFound();

            return Ok(_mapper.Map<CharacterDTO>(character));
        }

        // PUT: api/characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update / Override a character in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterPutDTO characterDTO)
        {
            if (id != characterDTO.Id)
            {
                return BadRequest();
            }

            await _characterService.UpdateAsync(_mapper.Map<Character>(characterDTO));

            return NoContent();
        }

        // POST: api/characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a new character to the DB
        /// </summary>
        /// <param name="characterPostDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostCharacter(CharacterPostDTO characterPostDTO)
        {
            var character = _mapper.Map<Character>(characterPostDTO);
            await _characterService.AddAsync(character);

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            await _characterService.Delete(id);

            return NoContent();
        }
    }
}
