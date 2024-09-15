using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Interfaces.Repositories;

public interface ISeatRepository
{
    Task<Seat?> GetSeatByIdAsync(int seatId);
}