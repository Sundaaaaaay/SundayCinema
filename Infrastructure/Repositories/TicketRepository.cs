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
        _context.Tickets.Add(ticket);
        var ticketModel = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == ticket.Id);
        _context.Seats.FirstOrDefaultAsync(x => x.Id == ticket.SeatId);
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
}