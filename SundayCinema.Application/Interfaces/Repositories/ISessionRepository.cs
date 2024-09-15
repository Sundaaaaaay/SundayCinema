using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Interfaces.Repositories;

public interface ISessionRepository
{ 
    Task<Session?> GetByIdAsync(int id);
    Task<Session?> DeleteAsync(int id);
    Task<IEnumerable<Session?>?> GetCompletedSessionsAsync();
}