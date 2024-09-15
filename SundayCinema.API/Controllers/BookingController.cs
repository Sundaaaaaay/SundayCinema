using Microsoft.AspNetCore.Mvc;
using SundayCinema.Application.Dtos;
using SundayCinema.Application.Interfaces;
using SundayCinema.Application.Mappers;

namespace SundayCinema.API.Controllers;

[Route("sundaycinema/book")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    
    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    
    [HttpPost]
    public async Task<IActionResult> BookTicket([FromBody] CreateTicketDto ticketDto)
    {
        if (ticketDto == null)
            return BadRequest();
        
        var ticketModel = ticketDto.CreateTicketMapper();
        
        await _bookingService.BookTicketAsync(ticketModel);
            
        return Ok(ticketDto);
    }
}