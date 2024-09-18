using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ISessionRepository
{ 
    Task<Session?> GetByIdAsync(int id);
    Task<Session?> DeleteAsync(int id);
    Task<IEnumerable<Session?>?> GetCompletedSessionsAsync();
    Task<Session?> CreateAsync(Session session);
    Task<IEnumerable<Session?>?> GetAllSessionsAsync();
}