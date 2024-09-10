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
    public async Task<Ticket> CreateTicketAsync(CreateTicketDto ticketDto)
    {
        throw new NotImplementedException();
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