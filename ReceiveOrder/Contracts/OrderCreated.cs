//This record assigns the Date and ID to the order created by OrderCreatedConsumer.cs

namespace ReceiveOrder.Contracts;

public record OrderCreated
{
    public string? Id { get; init; }
    public DateTime Date { get; init; }
}