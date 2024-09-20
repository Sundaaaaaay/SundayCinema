using Application.Interfaces;
using Microsoft.Extensions.Logging;
using Application.Dtos;
using Domain.Entities;

namespace Application.Services;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BookingService> _logger;
    
    public BookingService(IUnitOfWork unitOfWork, ILogger<BookingService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    
    public async Task<Ticket?> BookTicketAsync(Ticket createTicket)
    {
        try
        {
            var session = await _unitOfWork.Sessions.GetByIdAsync(createTicket.SessionId);
                
            if (session == null)
                throw new Exception("Session not found");

            if (!session.IsFull())
                throw new Exception("Session is full");

            var seat = await _unitOfWork.Seats.GetSeatByIdAsync(createTicket.SeatId);

            if (seat == null)
                throw new Exception("Seat not found");
            
            if(!seat.IsAvailable)
                throw new Exception("Seat is not available");

            try
            {
                var ticket = await _unitOfWork.Tickets.CreateTicketAsync(createTicket);
                
                await _unitOfWork.Seats.ChangeAvailability(seat.Id, seat.IsAvailable);
                
                return ticket;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new Exception($"Ticket creation failed: {e.Message}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception($"Error while booking ticket: {ex.Message}");
        }
    }
}