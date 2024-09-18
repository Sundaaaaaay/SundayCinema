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

    public async Task<Session?> GetByIdAsync(int id)
    {
        // var session = await _context.Sessions
        //     .Include(s => s.Movie)
        //         .ThenInclude(m => m.Genre)
        //     .Include(s => s.CinemaHall)
        //         .ThenInclude(c => c.Seats)
        //     .Include(s => s.Tickets)
        //     .FirstOrDefaultAsync(x => x.Id == id);

        var session = await _context.Sessions
            .Where(s => s.Id == id)
            .Select(s => new
            {
                s.Id,
                s.StartTime,
                s.EndTime,
                MovieName = s.Movie.Name,
                CinemaHall = new
                {
                    s.CinemaHall.Id,
                    s.CinemaHall.TotalSeats
                },
                TicketsCount = s.Tickets.Count
            })
            .FirstOrDefaultAsync();
        
        return session != null ? new Session 
        {
            Id = session.Id,
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            Movie = new Movie
            {
                Name = session.MovieName
            },
            CinemaHall = new CinemaHall
            {
                Id = session.CinemaHall.Id,
                TotalSeats = session.CinemaHall.TotalSeats
            }
        } : null;

    }

    public async Task<Session?> DeleteAsync(int id)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(x => x.Id == id);
        _context.Sessions.Remove(session);
        await _context.SaveChangesAsync();
        
        return session;
    }

    public async Task<IEnumerable<Session?>?> GetCompletedSessionsAsync()
    {
        return await _context.Sessions
            .Include(s => s.Tickets)
            .Where(s => s.EndTime < DateTime.UtcNow)
            .ToListAsync();

    }

    public async Task<Session?> CreateAsync(Session session)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Session>> GetAllSessionsAsync()
    {
        var sessions = await _context.Sessions.ToListAsync();

        return sessions;
    }
}