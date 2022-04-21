using ReceiveOrder;

namespace CreateOrder;

public interface ICreateOrderService
{
    Task CreateOrder(Order order);
}