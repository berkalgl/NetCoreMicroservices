namespace MessagesAndEvents.Events
{
    public class OrderCreated
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }
        public List<OrderItemMessage>? OrderItems { get; set; }
    }

    public class OrderItemMessage
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }

}
