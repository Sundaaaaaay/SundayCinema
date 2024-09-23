using System.Runtime.InteropServices;
using Application.Dtos;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
        
        return ticket;
    }

    public async Task<Ticket?> GetTicketByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Ticket?> DeleteTicketAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<Ticket>> GetAllTicketsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CheckSeatsAvailabilityAsync(int seatNumber)
    {
        return await _context.Tickets
            .AnyAsync(t => t.SeatNumber == seatNumber);
    }
}