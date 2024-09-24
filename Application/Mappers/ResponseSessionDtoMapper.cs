using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class ResponseSessionDtoMapper
{
    public static ResponseSesionDto ToSessionResponseDto(this Session session)
    {
        if (session == null)
        {
            throw new ArgumentNullException(nameof(session), "Session cannot be null.");
        }
        
        return new ResponseSesionDto
        {
            Id = session.Id,
            MovieName = session.Movie.Name,
            StartTime = session.StartTime,
            CinemaHallId = session.HallId,
            EndTime = session.EndTime,
            TotalSeats = session.TotalSeats,
        };
    }
}