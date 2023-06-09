﻿using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieCharactersDbContext _context;

        public CharacterService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<Character> AddAsync(Character entity)
        {
            await _context.Characters.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            if (!await CharacterExistsAsync(id)) throw new Exception("No character with that ID.");

            var character = await _context.Characters
                .Where(c => c.Id == id)
                .FirstAsync();

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _context.Characters
                .Include(c => c.Movies)
                .ToListAsync();
        }

        public async Task<Character?> GetByIdAsync(int id)
        {
            if (!await CharacterExistsAsync(id)) throw new Exception("No character with that ID.");

            return await _context.Characters
                .Where(c => c.Id == id)
                .FirstAsync();
        }

        public async Task<Character> UpdateAsync(Character entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        private async Task<bool> CharacterExistsAsync(int id)
        {
            return await _context.Characters.AnyAsync(c => c.Id == id);
        }
    }
}
