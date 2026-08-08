using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace final_group_4_3045.Models
{
    public class Hobby
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? HobbyName { get; set; }
        public string? Category { get; set; }
        public int HoursPerWeek { get; set; }
        public bool Indoor { get; set; }
    }
}
