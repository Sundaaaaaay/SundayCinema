using SundayCinema.Application.Interfaces.Repositories;

namespace SundayCinema.Application.Interfaces;

public interface IUnitOfWork
{
    ISessionRepository Sessions { get; }
    ITicketRepository Tickets { get; }
}