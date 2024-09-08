using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Interfaces.Repositories;

public interface ISessionRepository
{
    Session GetByIdAsync(int id);
}