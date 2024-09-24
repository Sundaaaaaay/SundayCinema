using Domain.Enums;

namespace Application.Dtos;

public class CreateMovieDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public MovieGenre Genre { get; set; }
}