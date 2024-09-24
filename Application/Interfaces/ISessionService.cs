using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface ISessionService
{
    Task<IEnumerable<ResponseSesionDto?>> GetAllSessionsAsync();
    Task<Session?> CreateSessionAsync(CreateSessionDto sessionDto);
}