namespace ReceiveOrder;

public record NewOrderCreated
{
    public string? Id { get; init; }
    public DateTime Date { get; init; }
}