using Microsoft.AspNetCore.Mvc;
using APIMovie.BLL.Services;
using APIMovie.DAL.Models;
using APIMovie.DAL.Dtos.Movie;

namespace APIMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
   _service = service;
  }

        // GET api/movies
        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync()
        {
        var movies = await _service.GetMoviesAsync();
            return Ok(movies);
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieAsync(int id)
        {
            var movie = await _service.GetMovieAsync(id);
            if (movie == null) return NotFound();
return Ok(movie);
        }

        // POST api/movies
        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync([FromBody] CreateMovieDto dto)
        {
         if (!ModelState.IsValid) return BadRequest(ModelState);

     var movie = new Movie
    {
     Name = dto.Name,
     Duration = dto.Duration,
 Description = dto.Description,
        Clasification = dto.Clasification
        };

        var created = await _service.CreateMovieAsync(movie);
         return CreatedAtAction(nameof(GetMovieAsync), new { id = created.Id }, created);
        }

        // PUT api/movies/5
    [HttpPut("{id}")]
 public async Task<IActionResult> UpdateMovieAsync(int id, [FromBody] UpdateMovieDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch.");
    if (!ModelState.IsValid) return BadRequest(ModelState);

    var movie = await _service.GetMovieAsync(id);
      if (movie == null) return NotFound();

      movie.Name = dto.Name;
        movie.Duration = dto.Duration;
        movie.Description = dto.Description;
       movie.Clasification = dto.Clasification;
            movie.UpdatedDate = DateTime.Now;

   await _service.UpdateMovieAsync(movie);

   return NoContent();
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
     {
            var movie = await _service.GetMovieAsync(id);
         if (movie == null) return NotFound();

         await _service.DeleteMovieAsync(id);
            return NoContent();
      }
    }
}
