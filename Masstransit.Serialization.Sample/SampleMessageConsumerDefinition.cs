using System.Net.Mime;
using MassTransit;

namespace Masstransit.Serialization.Sample;

public class SampleMessageConsumerDefinition : ConsumerDefinition<SampleMessageConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SampleMessageConsumer> consumerConfigurator,
        IRegistrationContext context)
    {
        endpointConfigurator.DefaultContentType = new ContentType("application/json");
        endpointConfigurator.UseNewtonsoftRawJsonSerializer();
        base.ConfigureConsumer(endpointConfigurator, consumerConfigurator, context);
    }
}