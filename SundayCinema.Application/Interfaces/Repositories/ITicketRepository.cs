using SundayCinema.Application.Dtos;
using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Interfaces.Repositories;

public interface ITicketRepository
{
    Task<Ticket?> CreateTicketAsync(Ticket ticketDto);
    Task<Ticket?> GetTicketByIdAsync(int id);
    Task<Ticket?> DeleteTicketAsync(int id);
}