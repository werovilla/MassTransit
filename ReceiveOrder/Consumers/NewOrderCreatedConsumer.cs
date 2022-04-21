using MassTransit;

namespace ReceiveOrder.Consumers;

public class NewOrderCreatedConsumer : IConsumer<NewOrderCreated>
{
    private readonly ILogger<NewOrderCreatedConsumer> _logger;

    public NewOrderCreatedConsumer(ILogger<NewOrderCreatedConsumer> logger)
    {
        _logger = logger;
    }
    public Task Consume(ConsumeContext<NewOrderCreated> context)
    {
        _logger.LogInformation($"Order Created with ID: {context.Message.Id}");
        return Task.CompletedTask;
    }
}