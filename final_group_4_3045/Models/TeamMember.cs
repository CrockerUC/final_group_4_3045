using System.ComponentModel.DataAnnotations; // For data annotations like [Key]
namespace final_group_4_3045.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CollegeProgram { get; set; }
        public string YearInProgram { get; set; }
    }
}
