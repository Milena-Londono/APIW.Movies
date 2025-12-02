using APIMovie.DAL.Models;
using APIMovie.DAL.Repositories;
using APIW.Movies.DAL;
using Microsoft.EntityFrameworkCore;

namespace APIMovie.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;
            await _context.Movies.AddAsync(movie);
            await SaveAsync();
            return movie;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await GetMovieAsync(id);

            if (movie == null)
            {
                return false;
            }

            _context.Movies.Remove(movie);
            return await SaveAsync();
        }

        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _context.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies
                .AsNoTracking()
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.UpdatedDate = DateTime.UtcNow;
            _context.Movies.Update(movie);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
