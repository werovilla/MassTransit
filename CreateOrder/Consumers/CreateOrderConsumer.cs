using CreateOrder.Interfaces;
using MassTransit;
using ReceiveOrder;
using ReceiveOrder.Contracts;

namespace CreateOrder.Consumers;

public class CreateOrderConsumer : IConsumer<NewOrderReceived>
{
    private IBus _bus;
    private readonly ICreateOrderService _orderService;
    private readonly ILogger<CreateOrderConsumer> _logger;

    public CreateOrderConsumer(IBus bus, ICreateOrderService orderService, ILogger<CreateOrderConsumer> logger)
    {
        _bus = bus;
        _orderService = orderService;
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<NewOrderReceived> context)
    {
        _logger.LogInformation($"Creating Order");
        await _orderService.CreateOrder(context.Message);
    }
}