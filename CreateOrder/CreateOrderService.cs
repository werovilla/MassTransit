using MassTransit;
using ReceiveOrder;

namespace CreateOrder;

public class CreateOrderService : ICreateOrderService
{
    private readonly IBus _bus;

    public CreateOrderService(IBus bus)
    {
        _bus = bus;
    }
    public async Task CreateOrder(Order order)
    {
        var orderCreated = new NewOrderCreated
        {
            Id = Guid.NewGuid().ToString(),
            Date = DateTime.Now
        };
        await _bus.Publish(orderCreated);
    }
}