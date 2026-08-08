using Microsoft.EntityFrameworkCore;
using final_group_4_3045.Models;
using final_group_4_3045.Interfaces;

namespace final_group_4_3045.Data
{
    public class HobbyDAO : IHobbyContextDAO
    {
        private readonly AppDbContext _context;

        public HobbyDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hobby>> GetAllHobbiesAsync()
        {
            return await _context.Hobbies.ToListAsync();
        }

        public async Task<Hobby?> GetHobbyByIdAsync(int id)
        {
            return await _context.Hobbies.FindAsync(id);
        }

        public async Task AddHobbyAsync(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHobbyAsync(Hobby hobby)
        {
            _context.Hobbies.Update(hobby);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHobbyAsync(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby != null)
            {
                _context.Hobbies.Remove(hobby);
                await _context.SaveChangesAsync();
            }
        }
    }
}