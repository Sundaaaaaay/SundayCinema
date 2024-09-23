using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly ApplicationDbContext _context;

    public SessionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Session?> GetSessionByIdAsync(int id)
    {
        var session = await _context.Sessions
            .Where(s => s.Id == id)
            .Select(s => new
            {
                s.Id,
                s.StartTime,
                s.EndTime,
                MovieName = s.Movie.Name,
                TicketsCount = s.Tickets.Count,
                s.TotalSeats,
                s.HallId
            })
            .FirstOrDefaultAsync();
        
        return session != null ? new Session 
        {
            Id = session.Id,
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            TotalSeats = session.TotalSeats,
            Movie = new Movie
            {
                Name = session.MovieName
            },
            HallId = session.HallId
        } : null;

    }

    public async Task<Session?> DeleteSessionAsync(int id)
    {
        var session = await _context.Sessions
            .FirstOrDefaultAsync(x => x.Id == id);
        _context.Sessions.Remove(session);
        await _context.SaveChangesAsync();
        
        return session;
    }

    public async Task<IEnumerable<Session>> GetCompletedSessionsAsync()
    {
        return await _context.Sessions
            .Include(s => s.Tickets)
            .Where(s => s.EndTime < DateTime.UtcNow)
            .ToListAsync();
    }
    
    public async Task<Session> CreateSessionAsync(Session session)
    {
        await _context.Sessions.AddAsync(session);
        await _context.SaveChangesAsync();

        return session;
    }

    public async Task<IEnumerable<Session>> GetAllSessionsAsync()
    {
        var skipNumber = (1 - 1) * 10;
        
        var sessions = await _context.Sessions
            .ToListAsync();
        
        return sessions;
    }
}