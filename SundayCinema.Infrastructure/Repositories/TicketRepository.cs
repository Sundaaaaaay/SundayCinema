using System.Runtime.InteropServices;
using SundayCinema.Application.Dtos;
using SundayCinema.Application.Interfaces.Repositories;
using SundayCinema.Domain.Entities;
using SundayCinema.Infrastructure.Data;

namespace SundayCinema.Infrastructure.Repositories;

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