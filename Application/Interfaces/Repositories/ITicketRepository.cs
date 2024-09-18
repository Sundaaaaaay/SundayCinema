using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ITicketRepository
{
    Task<Ticket?> CreateTicketAsync(Ticket ticketDto);
    Task<Ticket?> GetTicketByIdAsync(int id);
    Task<Ticket?> DeleteTicketAsync(int id);
}