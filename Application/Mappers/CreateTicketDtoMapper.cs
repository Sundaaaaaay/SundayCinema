using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class CreateTicketDtoMapper
{
    public static Ticket CreateTicketMapper(this CreateTicketDto createTicketDto)
    {
        return new Ticket
        {
            SessionId = createTicketDto.SessionId,
            BookedBy = createTicketDto.BookedBy,
            SeatNumber = createTicketDto.SeatNumber,
        };
    }
}