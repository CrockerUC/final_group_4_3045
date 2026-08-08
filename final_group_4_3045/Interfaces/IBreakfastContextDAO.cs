using final_group_4_3045.Models;

namespace final_group_4_3045.Interfaces
{
    public interface IBreakfastContextDAO
    {
        Task<List<BreakfastFood>> GetAllBreakfastFoodsAsync();
        Task<BreakfastFood?> GetBreakfastFoodByIdAsync(int id);
        Task AddBreakfastFoodAsync(BreakfastFood breakfastFood);
        Task UpdateBreakfastFoodAsync(BreakfastFood breakfastFood);
        Task DeleteBreakfastFoodAsync(int id);
    }
}