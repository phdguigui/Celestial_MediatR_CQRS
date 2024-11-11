using Celestial.API.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Celestial.API.Domain.Data.Repositories
{
    public class StarRepository : IStarRepository
    {
        private readonly ApplicationContext _context;

        public StarRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Star?> GetStarByIdAsync(int id)
        {
            return await _context.Stars
                .Include(s => s.Position)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Star>?> GetAllStarsAsync()
        {
            return await _context.Stars
                .Include(s => s.Position)
                .ToListAsync();
        }

        public async Task AddStarAsync(Star star)
        {
            await _context.Stars.AddAsync(star);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStarAsync(Star star)
        {
            _context.Stars.Update(star);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStarAsync(int id)
        {
            var star = await _context.Stars.FindAsync(id);
            if (star != null)
            {
                _context.Stars.Remove(star);
                await _context.SaveChangesAsync();
            }
        }
    }
}
