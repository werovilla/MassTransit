namespace ReceiveOrder.Contracts;

public record NewOrderReceived
{
    public DateTime Date { get; init; }
    public string? LotNumber { get; init; }
}