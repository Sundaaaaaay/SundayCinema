using SundayCinema.Application.Interfaces.Repositories;
using SundayCinema.Domain.Entities;
using SundayCinema.Infrastructure.Data;

namespace SundayCinema.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly ApplicationDbContext _context;

    public SessionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Session GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}