using Microsoft.EntityFrameworkCore;
using SundayCinema.Application.Interfaces.Repositories;
using SundayCinema.Domain.Entities;
using SundayCinema.Infrastructure.Data;

namespace SundayCinema.Infrastructure.Repositories;

public class SeatRepositoryv: ISeatRepository
{
    private readonly ApplicationDbContext _context;

    public SeatRepositoryv(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Seat?> GetSeatByIdAsync(int seatId)
    {
        var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == seatId);
        
        return seat;
    }
}