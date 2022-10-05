namespace MessagesAndEvents.Requests
{
    public class AddBookToBasketRequest
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; } = 1;
        public int UserId { get; set; }
    }
}
