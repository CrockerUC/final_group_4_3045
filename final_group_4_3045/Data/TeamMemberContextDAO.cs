using Microsoft.EntityFrameworkCore;
using final_group_4_3045.Models;
using final_group_4_3045.Interfaces;

namespace final_group_4_3045.Data
{
    public class TeamMemberDAO: ITeamMemberContextDAO
    {
        private readonly AppDbContext _context;

        public TeamMemberDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeamMember>> GetAllTeamMembersAsync()
        {
            return await _context.TeamMembers.ToListAsync();
        }

        public async Task<TeamMember?> GetTeamMemberByIdAsync(int id)
        {
            return await _context.TeamMembers.FindAsync(id);
        }

        public async Task AddTeamMemberAsync(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeamMemberAsync(TeamMember teamMember)
        {
            var existingTeamMember = await _context.TeamMembers.FindAsync(teamMember.Id);

            if (existingTeamMember != null)
            {
                existingTeamMember.FullName = teamMember.FullName;
                existingTeamMember.BirthDate = teamMember.BirthDate;
                existingTeamMember.CollegeProgram = teamMember.CollegeProgram;
                existingTeamMember.YearInProgram = teamMember.YearInProgram;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTeamMemberAsync(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember != null)
            {
                _context.TeamMembers.Remove(teamMember);
                await _context.SaveChangesAsync();
            }
        }
    }
}