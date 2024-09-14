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
    
    public async Task<Ticket?> BookTicketAsync(CreateTicketDto createTicketDto)
    {
        try
        {
            var session = await _unitOfWork.Sessions.GetByIdAsync(createTicketDto.SessionId);


            if (session == null)
                throw new Exception("Session not found");

            if (session.IsFull())
                throw new Exception("Session is full");

            if (session.Tickets.Any(t => t.SeatId == createTicketDto.SeatId))
                throw new Exception("Seat is already booked");

            var ticket = await _unitOfWork.Tickets.CreateTicketAsync(createTicketDto);

            return ticket;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception(ex.Message);
        }
    }
}