using System.Runtime.CompilerServices;
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
    
    public async Task<Ticket?> BookTicketAsync(Ticket createTicketModel)
    {
        try
        {
            var session = await _unitOfWork.Sessions.GetByIdAsync(createTicketModel.SessionId);
                
            if (session == null)
                throw new Exception("Session not found");

            if(session.IsFull())
                throw new Exception($"Session is full, total size {session.TotalSeats}");

            if (!session.IsSeatExist(createTicketModel.SeatNumber))
                throw new Exception(
                    $"Seat {createTicketModel.SeatNumber} doesnt exist, total seats: {session.TotalSeats}");
            
            if(await _unitOfWork.Tickets.CheckSeatsAvailabilityAsync(createTicketModel.SeatNumber))
                throw new Exception($"Seat {createTicketModel.SeatNumber} is already booked");

            try
            {
                var ticket = await _unitOfWork.Tickets.CreateTicketAsync(createTicketModel);
                
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