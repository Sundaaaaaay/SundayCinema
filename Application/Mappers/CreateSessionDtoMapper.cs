using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class CreateSessionDtoMapper
{
    public static Session ToCreateSessionDto(this CreateSessionDto createSessionDto)
    {
        return new Session
        {
            HallId = createSessionDto.HallId,
            MovieId = createSessionDto.MovieId,
            EndTime = createSessionDto.EndTime,
            StartTime = createSessionDto.StartTime,
            TotalSeats = createSessionDto.TotalSeats,
        };
    }
}