using MassTransit;
using ReceiveOrder;

namespace CreateOrder.Consumers;

public class NewOrderConsumer : IConsumer<Order>
{
    private IBus _bus;
    private readonly ICreateOrderService _orderService;
    private readonly ILogger<NewOrderConsumer> _logger;

    public NewOrderConsumer(IBus bus, ICreateOrderService orderService, ILogger<NewOrderConsumer> logger)
    {
        _bus = bus;
        _orderService = orderService;
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<Order> context)
    {
        _logger.LogInformation($"Creating Order");
        await _orderService.CreateOrder(context.Message);
    }
}