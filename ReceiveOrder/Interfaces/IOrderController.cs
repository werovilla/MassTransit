using Microsoft.AspNetCore.Mvc;
using ReceiveOrder.Contracts;

namespace ReceiveOrder.Interfaces;

public interface IOrderController
{
    Task Post([FromBody] NewOrderReceived newNewOrderReceived);
}