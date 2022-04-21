//This service class is the EventBUS Hosted Service which is used to Start/Stop the EventBUS Service

using MassTransit;

namespace MTHost.Services;

public class MassTransitService : IHostedService
{
    readonly IBusControl _bus;

    public MassTransitService(IBusControl bus)
    {
        _bus = bus;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _bus.StartAsync(cancellationToken).ConfigureAwait(false);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return _bus.StopAsync(cancellationToken);
    }
}