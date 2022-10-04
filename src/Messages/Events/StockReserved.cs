namespace MessagesAndEvents.Events
{
    public class StockReserved
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }
        public List<OrderItemMessage>? OrderItems { get; set; }
    }

    public class StockNotReserved
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string? Message { get; set; }
    }
}
