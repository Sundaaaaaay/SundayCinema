using SundayCinema.Application.Dtos;
using SundayCinema.Application.Interfaces;
using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Services;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public BookingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Ticket?> BookTicketAsync(CreateTicketDto ticketDto)
    {
        var session = await _unitOfWork.Sessions.GetByIdAsync(ticketDto.SessionId);
        
        
        if(session == null)
            throw new Exception("Session not found");

        if(session.IsFull())
            throw new Exception("Session is full");
        
        if(session.Tickets.Any(t => t.SeatId == ticketDto.SeatId))
            throw new Exception("Seat is already booked");
        
        var ticket = await _unitOfWork.Tickets.CreateTicketAsync(ticketDto);
        
        return ticket;
    }
}