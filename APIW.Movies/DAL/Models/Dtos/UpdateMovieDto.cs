using System.ComponentModel.DataAnnotations;

namespace APIMovie.DAL.Dtos.Movie
{
    public class UpdateMovieDto : CreateMovieDto
    {
        [Required]
        public int Id { get; set; }
    }
}
