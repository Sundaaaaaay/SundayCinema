using SundayCinema.Application.Interfaces.Repositories;
using SundayCinema.Domain.Entities;
using SundayCinema.Infrastructure.Data;

namespace SundayCinema.Infrastructure.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly ApplicationDbContext _context;

    public SessionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Session> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Session?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Session?>?> GetCompletedSessionsAsync()
    {
        throw new NotImplementedException();
    }
}