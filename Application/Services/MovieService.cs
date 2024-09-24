using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class MovieService : IMovieService
{
    private readonly IUnitOfWork _unitOfWork;

    public MovieService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Movie?>> GetAllMoviesAsync()
    {
        try
        {
            var movies = await _unitOfWork.Movies.GetAllMoviesAsync();
            
            return movies;
        }
        catch (Exception e)
        {
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<Movie?> GetMovieByIdAsync(int movieId)
    {
        throw new NotImplementedException();
    }

    public async Task<CreateMovieDto?> CreateMovieAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public async Task<Movie?> DeleteMovieAsync(int movieId)
    {
        throw new NotImplementedException();
    }
}