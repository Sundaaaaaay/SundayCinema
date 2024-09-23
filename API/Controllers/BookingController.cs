using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Application.Interfaces;
using Application.Mappers;

namespace SundayCinema.Presentation.Controllers;

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
        
        await _bookingService.BookTicketAsync(ticketDto);
            
        return Ok(ticketDto);
    }
}