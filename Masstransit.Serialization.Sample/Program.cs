using MassTransit;
using Masstransit.Serialization.Sample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<SampleMessageConsumer, SampleMessageConsumerDefinition>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddHostedService<SampleHostedService>();
        services.AddLogging();
    })
    .Build()
    .RunAsync();