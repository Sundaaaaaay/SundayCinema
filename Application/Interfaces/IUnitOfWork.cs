using Application.Interfaces.Repositories;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    ISessionRepository Sessions { get; }
    ITicketRepository Tickets { get; }
    ISeatRepository Seats { get; }
}