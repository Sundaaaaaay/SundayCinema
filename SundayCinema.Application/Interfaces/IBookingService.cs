using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Interfaces;

public interface IBookingService
{
    Ticket BookTicketAsync(int sessionId, int seat, string buyerName);
}