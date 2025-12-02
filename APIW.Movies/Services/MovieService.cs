using APIMovie.DAL.Models;
using APIMovie.DAL.Repositories;

namespace APIMovie.BLL.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie?> GetMovieAsync(int id);
        Task<Movie> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
    }


    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Movie>> GetMoviesAsync() => _repository.GetMoviesAsync();
        public Task<Movie?> GetMovieAsync(int id) => _repository.GetMovieAsync(id);
        public Task<Movie> CreateMovieAsync(Movie movie) => _repository.CreateMovieAsync(movie);
        public Task<bool> UpdateMovieAsync(Movie movie) => _repository.UpdateMovieAsync(movie);
        public Task<bool> DeleteMovieAsync(int id) => _repository.DeleteMovieAsync(id);
    }
}
