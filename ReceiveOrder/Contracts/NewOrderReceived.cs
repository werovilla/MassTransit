//This record assigns the Date and LotNumber to the order created by OrderCreatedConsumer.cs

namespace ReceiveOrder.Contracts;

public record NewOrderReceived
{
    public DateTime Date { get; init; }
    public string? LotNumber { get; init; }
}