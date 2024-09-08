using SundayCinema.Application.Interfaces.Repositories;
using SundayCinema.Infrastructure.Data;

namespace SundayCinema.Infrastructure.Persistence.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}