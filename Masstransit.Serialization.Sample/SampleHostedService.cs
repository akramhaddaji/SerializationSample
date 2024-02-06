using MassTransit;
using Microsoft.Extensions.Hosting;

namespace Masstransit.Serialization.Sample;

public class SampleHostedService : BackgroundService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public SampleHostedService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _publishEndpoint.Publish(new SampleMessage { Id = Guid.NewGuid() }, stoppingToken);
    }
}