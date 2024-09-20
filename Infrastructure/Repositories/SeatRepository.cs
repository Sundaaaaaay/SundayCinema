using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Domain.Entities;

namespace Infrastructure.Repositories;

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

    public async Task ChangeAvailabilityAsync(int seatId, bool isAvailable)
    {
        var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == seatId);
        
        if (isAvailable)
            seat.IsAvailable = false;
        else
            seat.IsAvailable = true;
        
        await _context.SaveChangesAsync();
    }
}