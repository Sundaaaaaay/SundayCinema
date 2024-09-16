using Microsoft.AspNetCore.Mvc;
using SundayCinema.Application.Interfaces;
using SundayCinema.Application.Mappers;

namespace SundayCinema.Presentation.Controllers;

[Route("sundaycinema/getsessioninfo")]
[ApiController]
public class GetSessionInfo : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSessionInfo(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetSessionsInfo()
    {
        var sessions = await _unitOfWork.Sessions.GetAllSessionsAsync();

        var sessionsDto = sessions.Select(s => s.ToSessionResponseDto()).ToList();
        
        return Ok(sessionsDto);
    }
}