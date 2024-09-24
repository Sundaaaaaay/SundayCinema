using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Mappers;
using Domain.Entities;

namespace Application.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }
    
    public async Task<IEnumerable<ResponseSesionDto>> GetAllSessionsAsync()
    {
        try
        {
            return await _sessionRepository.GetAllSessionsAsync();
        }
        catch(Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public async Task<Session> CreateSessionAsync(CreateSessionDto sessionDto)
    {
        if(sessionDto == null)
            throw new ArgumentNullException(nameof(sessionDto));

        var sessionModel = sessionDto.ToCreateSessionDto();

        try
        {
            return await _sessionRepository.CreateSessionAsync(sessionModel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}