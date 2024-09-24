using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public ISessionRepository Sessions { get; private set; }
    public ITicketRepository Tickets { get; private set; }
    public IMovieRepository Movies { get; private set; }

    public UnitOfWork(ApplicationDbContext context, ISessionRepository session, ITicketRepository tickets, IMovieRepository movies)
    {
        _context = context;
        Sessions = session;
        Tickets = tickets;
        Movies = movies;
    }
}