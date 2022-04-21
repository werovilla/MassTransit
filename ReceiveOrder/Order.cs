namespace ReceiveOrder;

public record Order
{
    public DateTime Date { get; init; }
    public string? LotNumber { get; init; }
}