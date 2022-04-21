//This class contains the logic used to create the order.

using CreateOrder.Interfaces;
using MassTransit;
using ReceiveOrder;
using ReceiveOrder.Contracts;

namespace CreateOrder.Services;

public class CreateOrderService : ICreateOrderService
{
    private readonly IBus _bus;

    public CreateOrderService(IBus bus)
    {
        _bus = bus;
    }
    public async Task CreateOrder(NewOrderReceived newOrderReceived)
    {
        var orderCreated = new OrderCreated
        {
            Id = Guid.NewGuid().ToString(),
            Date = DateTime.Now
        };
        await _bus.Publish(orderCreated);
    }
}