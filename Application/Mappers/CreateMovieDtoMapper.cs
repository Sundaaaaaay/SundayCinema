using Domain.Entities;

namespace Application.Mappers;

public static class CreateMovieDtoMapper
{
    public static Movie ToCreateMovieDto(this Movie movie)
    {
        return new Movie
        {
            Id = movie.Id,
            Description = movie.Description,
            Name = movie.Name,
            ReleaseDate = movie.ReleaseDate,
        };
    }
}