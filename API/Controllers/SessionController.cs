using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;

namespace SundayCinema.Presentation.Controllers;

[Route("sundaycinema/getsessioninfo")]
[ApiController]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSessionsInfo()
    {
        var sessions = await _sessionService.GetAllSessionsAsync();

        if (sessions == null)
            return NotFound();
        
        return Ok(sessions);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSession(CreateSessionDto sessionDto)
    {
        return Ok(await _sessionService.CreateSessionAsync(sessionDto));
    }
}