using final_group_4_3045.Models;

namespace final_group_4_3045.Interfaces
{
    public interface ITeamMemberContextDAO
    {
        Task<List<TeamMember>> GetAllTeamMembersAsync();
        Task<TeamMember?> GetTeamMemberByIdAsync(int id);
        Task AddTeamMemberAsync(TeamMember teamMember);
        Task UpdateTeamMemberAsync(TeamMember teamMember);
        Task DeleteTeamMemberAsync(int id);
    }
}