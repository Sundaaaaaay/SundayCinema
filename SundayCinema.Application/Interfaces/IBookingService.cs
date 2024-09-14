using SundayCinema.Application.Dtos;
using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Interfaces;

public interface IBookingService
{
    Task<Ticket?> BookTicketAsync(CreateTicketDto createTicketDto);
}