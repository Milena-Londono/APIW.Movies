using System.ComponentModel.DataAnnotations;

namespace APIMovie.DAL.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        public string? Description { get; set; }

        [Required]
        [MaxLength(10)]
        public string Clasification { get; set; }
    }
}
