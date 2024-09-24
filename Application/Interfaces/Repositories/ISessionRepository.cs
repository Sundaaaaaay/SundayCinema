using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ISessionRepository
{ 
    Task<Session?> GetSessionByIdAsync(int id);
    Task<Session?> DeleteSessionAsync(int id);
    Task<IEnumerable<Session>> GetCompletedSessionsAsync();
    Task<Session> CreateSessionAsync(Session session);
    Task<IEnumerable<ResponseSesionDto>?> GetAllSessionsAsync();
}