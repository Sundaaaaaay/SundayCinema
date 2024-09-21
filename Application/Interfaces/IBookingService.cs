using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface IBookingService
{
    Task<Ticket?> BookTicketAsync(Ticket createTicketModel);
}