using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public ISessionRepository Sessions { get; private set; }
    public ITicketRepository Tickets { get; private set; }

    public UnitOfWork(ApplicationDbContext context, ISessionRepository session, ITicketRepository tickets)
    {
        _context = context;
        Sessions = session;
        Tickets = tickets;
    }
}