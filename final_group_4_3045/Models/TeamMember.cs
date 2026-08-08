using System.ComponentModel.DataAnnotations; // For data annotations like [Key]
using System.ComponentModel.DataAnnotations.Schema; // For database schema-related annotations like [DatabaseGenerated]
namespace final_group_4_3045.Models
{
    public class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? CollegeProgram { get; set; }
        public string? YearInProgram { get; set; }
    }
}
