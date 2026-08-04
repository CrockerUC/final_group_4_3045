using Microsoft.EntityFrameworkCore;
using final_group_4_3045.Models;

namespace final_group_4_3045.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Define DbSet properties for each model
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<BreakfastFood> BreakfastFoods { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
