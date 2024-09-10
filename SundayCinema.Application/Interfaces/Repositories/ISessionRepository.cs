using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Interfaces.Repositories;

public interface ISessionRepository
{ 
    Task<Session> GetByIdAsync(int id);
}