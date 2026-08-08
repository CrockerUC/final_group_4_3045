using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace final_group_4_3045.Models
{
    public class BreakfastFood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Categories { get; set; }
        public bool Healthy { get; set; }
        public string? Drink { get; set; }
    }
}
 