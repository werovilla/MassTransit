using ReceiveOrder;
using ReceiveOrder.Contracts;

namespace CreateOrder.Interfaces;

public interface ICreateOrderService
{
    Task CreateOrder(NewOrderReceived newOrderReceived);
}