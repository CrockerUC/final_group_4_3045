using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace final_group_4_3045.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Rating { get; set; }
    }
}
