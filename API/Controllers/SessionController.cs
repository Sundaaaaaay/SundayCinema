using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Mappers;
using Domain.Entities;

namespace SundayCinema.Presentation.Controllers;

[Route("sundaycinema/sessions")]
[ApiController]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;
    private readonly ILogger<SessionController> _logger;

    public SessionController(ISessionService sessionService, ILogger<SessionController> logger)
    {
        _sessionService = sessionService;
        _logger = logger;
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