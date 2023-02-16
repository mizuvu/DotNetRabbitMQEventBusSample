using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace EventBusRabbitMQ;

public static class Startup
{
    public static IServiceCollection AddRabbitMQEventBus(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IConnection>(sp =>
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            //Create the RabbitMQ connection using connection factory details as i mentioned above
            return factory.CreateConnection();
        });

        services.AddSingleton<IEventBus, RabbitMQEventBus>();

        return services;
    }

    public static void Subscribe<TMessage, TEventHandler>(this IServiceCollection services)
        where TMessage : IntegrationEvent
        where TEventHandler : class, IEventHandler<TMessage>, IHostedService
    {
        services.AddHostedService<TEventHandler>();
    }
}