using Microsoft.AspNetCore.Mvc;

namespace ReceiveOrder.Controllers;

public interface IOrderController
{
    IEnumerable<string> Get();
    string Get(int id);
    Task Post([FromBody] Order newOrder);
    void Put(int id, [FromBody] string value);
    void Delete(int id);
}