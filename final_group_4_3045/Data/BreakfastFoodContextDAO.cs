using Microsoft.EntityFrameworkCore;
using final_group_4_3045.Models;
using final_group_4_3045.Interfaces;

namespace final_group_4_3045.Data
{
    public class BreakfastFoodDAO : IBreakfastContextDAO
    {
        private readonly AppDbContext _context;

        public BreakfastFoodDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BreakfastFood>> GetAllBreakfastFoodsAsync()
        {
            return await _context.BreakfastFoods.ToListAsync();
        }

        public async Task<BreakfastFood?> GetBreakfastFoodByIdAsync(int id)
        {
            return await _context.BreakfastFoods.FindAsync(id);
        }

        public async Task AddBreakfastFoodAsync(BreakfastFood breakfastFood)
        {
            _context.BreakfastFoods.Add(breakfastFood);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBreakfastFoodAsync(BreakfastFood breakfastFood)
        {
            var existingBreakfastFood = await _context.BreakfastFoods.FindAsync(breakfastFood.Id);

            if (existingBreakfastFood != null)
            {
                existingBreakfastFood.Name = breakfastFood.Name;
                existingBreakfastFood.Categories = breakfastFood.Categories;
                existingBreakfastFood.Healthy = breakfastFood.Healthy;
                existingBreakfastFood.Drink = breakfastFood.Drink;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBreakfastFoodAsync(int id)
        {
            var breakfastFood = await _context.BreakfastFoods.FindAsync(id);
            if (breakfastFood != null)
            {
                _context.BreakfastFoods.Remove(breakfastFood);
                await _context.SaveChangesAsync();
            }
        }
    }
}