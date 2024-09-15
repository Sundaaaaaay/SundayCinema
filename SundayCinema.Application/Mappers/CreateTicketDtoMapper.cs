using SundayCinema.Application.Dtos;
using SundayCinema.Domain.Entities;

namespace SundayCinema.Application.Mappers;

public static class CreateTicketDtoMapper
{
    public static Ticket CreateTicketMapper(this CreateTicketDto createTicketDto)
    {
        return new Ticket
        {
            SeatId = createTicketDto.SeatId,
            SessionId = createTicketDto.SessionId,
            BookedBy = createTicketDto.BookedBy
        };
    }
}