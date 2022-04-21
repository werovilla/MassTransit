namespace ReceiveOrder.Contracts;

public record OrderCreated
{
    public string? Id { get; init; }
    public DateTime Date { get; init; }
}