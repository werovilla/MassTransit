//This class implements the IConsumer that comes from the MassTransit NugetPackage which shows the Order ID# created by CreateOrderConsumer.cs

using MassTransit;
using ReceiveOrder.Contracts;

namespace ReceiveOrder.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    private readonly ILogger<OrderCreatedConsumer> _logger;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
    {
        _logger = logger;
    }
    public Task Consume(ConsumeContext<OrderCreated> context)
    {
        _logger.LogInformation($"Order Created with ID: {context.Message.Id}");
        return Task.CompletedTask;
    }
}