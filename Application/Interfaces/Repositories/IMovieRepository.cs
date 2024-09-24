using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie?>> GetAllMoviesAsync();
    Task<Movie?> GetMovieByIdAsync(int movieId);
    Task<Movie?> CreateMovieAsync(Movie movie);
    Task<Movie?> DeleteMovieAsync(int movieId);
}