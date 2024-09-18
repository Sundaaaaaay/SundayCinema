using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class ResponseSessionDtoMapper
{
    public static ResponseSesionDto ToSessionResponseDto(this Session session)
    {
        return new ResponseSesionDto
        {
            Id = session.Id,
            MovieName = session.Movie.Name,
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            CinemaHallId = session.CinemaHallId,
        };
    }
}