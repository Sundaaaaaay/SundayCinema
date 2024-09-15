using Microsoft.EntityFrameworkCore;
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
        throw new NotImplementedException();
    }

    public async Task<List<Session?>?> GetCompletedSessionsAsync()
    {
        throw new NotImplementedException();
    }
}