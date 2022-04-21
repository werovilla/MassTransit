using Microsoft.AspNetCore.Mvc;
using MassTransit;

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
        
        // GET: api/Order
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        [HttpPost]
        public async Task Post([FromBody] Order newOrder)
        {
            Console.WriteLine($"Order received {newOrder.Date} | {newOrder.LotNumber}");
            await _bus.Publish(new Order
            {
                Date = DateTime.Now,
                LotNumber = newOrder.LotNumber
            });
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
