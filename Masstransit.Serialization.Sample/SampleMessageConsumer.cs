using MassTransit;
using Microsoft.Extensions.Logging;

namespace Masstransit.Serialization.Sample;

public class SampleMessageConsumer : IConsumer<SampleMessage>, IConsumer<Fault<SampleMessage>>
{
    private readonly ILogger<SampleMessageConsumer> _logger;

    public SampleMessageConsumer(ILogger<SampleMessageConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<SampleMessage> context)
    {
        _logger.LogInformation($"SampleMessage Received: {context.Message.Id}");
        await Task.Yield();
    }

    public async Task Consume(ConsumeContext<Fault<SampleMessage>> context)
    {
        _logger.LogInformation($"SampleMessage Received: {context.Message.Message?.Id}");
        await Task.Yield();
    }
}