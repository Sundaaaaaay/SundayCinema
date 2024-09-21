using Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Application.Interfaces;

namespace Application.Services;

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
        _timer = new Timer(async state => await DeleteCompletedSessions(state), null, TimeSpan.Zero, TimeSpan.FromMinutes(30));

        return Task.CompletedTask;
    }
    
    private async Task DeleteCompletedSessions(object state)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var sessionRepo = scope.ServiceProvider.GetRequiredService<ISessionRepository>();

            var completedSessions = await sessionRepo.GetCompletedSessionsAsync();

            foreach (var session in completedSessions)
            {
                await sessionRepo.DeleteAsync(session.Id);
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