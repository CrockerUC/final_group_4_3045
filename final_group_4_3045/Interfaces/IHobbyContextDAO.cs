using final_group_4_3045.Models;

namespace final_group_4_3045.Interfaces
{
    public interface IHobbyContextDAO
    {
        Task<List<Hobby>> GetAllHobbiesAsync();
        Task<Hobby?> GetHobbyByIdAsync(int id);
        Task AddHobbyAsync(Hobby hobby);
        Task UpdateHobbyAsync(Hobby hobby);
        Task DeleteHobbyAsync(int id);
    }
}