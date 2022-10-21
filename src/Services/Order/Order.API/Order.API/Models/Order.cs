namespace Order.API.Models
{
    public enum OrderState
    {
        Pending,
        Completed,
        Failed,
        Cancelled
    }
    // Entity in DB
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }
        public OrderState OrderState { get; set; } = OrderState.Pending;
    }
}
