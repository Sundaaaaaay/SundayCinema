using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface ISessionService
{
    Task<IEnumerable<Session?>> GetAllSessionsAsync();
    Task<Session?> CreateSessionAsync(CreateSessionDto sessionDto);
}