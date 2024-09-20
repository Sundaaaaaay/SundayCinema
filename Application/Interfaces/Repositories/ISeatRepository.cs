using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ISeatRepository
{
    Task<Seat?> GetSeatByIdAsync(int seatId);
    Task ChangeAvailability(int seatId, bool isAvailable);
}