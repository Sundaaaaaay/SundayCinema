using SundayCinema.Application.Interfaces;
using SundayCinema.Application.Interfaces.Repositories;
using SundayCinema.Infrastructure.Data;
using SundayCinema.Infrastructure.Persistence.Repositories;

namespace SundayCinema.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public ISessionRepository Sessions { get; private set; }
    public ITicketRepository Tickets { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Sessions = new SessionRepository(_context);
        Tickets = new TicketRepository(_context);
    }
}