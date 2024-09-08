using SundayCinema.Application.Interfaces;
using SundayCinema.Application.Interfaces.Repositories;
using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Services;

public class BookingService : IBookingService
{
    private readonly ISessionRepository _sessionRepo;
    
    public BookingService(ISessionRepository sessionRepo)
    {
        _sessionRepo = sessionRepo;
    }
    
    public Ticket BookTicketAsync(int sessionId, int seat, string buyerName)
    {
        var session = _sessionRepo.GetByIdAsync(sessionId);
        
        if(session == null)
            throw new Exception("Session not found");

        if(session.IsFull())
            throw new Exception("Session is full");
        
        if(session.Tickets.Any(t => t.SeatId == seat))
            throw new Exception("Seat is already booked");
            
        throw new NotImplementedException();
    }
}