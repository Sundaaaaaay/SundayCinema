using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class CreateMovieDtoMapper
{
    public static Movie ToCreateMovieDto(this CreateMovieDto movieDto)
    {
        return new Movie
        {
            Description = movieDto.Description,
            Name = movieDto.Name,
            ReleaseDate = movieDto.ReleaseDate,
        };
    }
}