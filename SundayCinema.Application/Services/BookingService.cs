using Microsoft.Extensions.Logging;
using SundayCinema.Application.Dtos;
using SundayCinema.Application.Interfaces;
using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Services;

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
                throw new Exception("Seat is now available");
            
            try
            {
                var ticket = await _unitOfWork.Tickets.CreateTicketAsync(createTicket);

                return ticket;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception($"Error while booking ticket: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception(ex.Message);
        }
    }
}