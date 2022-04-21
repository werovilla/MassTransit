using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ReceiveOrder.Contracts;
using ReceiveOrder.Interfaces;

namespace ReceiveOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private readonly IBus _bus;
        public OrderController(IBus bus)
        {
            _bus = bus;
        }
        
        [HttpPost]
        public async Task Post([FromBody] NewOrderReceived newNewOrderReceived)
        {
            Console.WriteLine($"Order received {newNewOrderReceived.Date} | {newNewOrderReceived.LotNumber}");
            await _bus.Publish(new NewOrderReceived
            {
                Date = DateTime.Now,
                LotNumber = newNewOrderReceived.LotNumber
            });
        }
    }
}
