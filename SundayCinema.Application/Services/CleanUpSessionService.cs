using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SundayCinema.Application.Interfaces;
using SundayCinema.Application.Interfaces.Repositories;

namespace SundayCinema.Application.Services;

public class CleanUpSessionService : IHostedService
{
    private readonly ILogger<CleanUpSessionService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private Timer _timer;

    public CleanUpSessionService(ILogger<CleanUpSessionService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanUpSessionService is starting.");
        _timer = new Timer(DeleteCompletedSessions, null, TimeSpan.Zero, TimeSpan.FromHours(24));

        return Task.CompletedTask;
    }
    
    private void DeleteCompletedSessions(object state)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var sessionRepo = scope.ServiceProvider.GetRequiredService<ISessionRepository>();

            var completedSessions = sessionRepo.GetCompletedSessionsAsync().Result;

            foreach (var session in completedSessions)
            {
                sessionRepo.DeleteAsync(session.Id).Wait();
                _logger.LogInformation($"Deleted completed session: {session.Id}");
            }

            _logger.LogInformation("All completed sessions deleted.");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanUpSessionService is stopping.");
        
        _timer?.Change(Timeout.Infinite, 0);
        
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}