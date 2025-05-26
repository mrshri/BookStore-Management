namespace BookStore_Management.ModelDtos.OrderDto
{
    public class OrderItemDto
    {
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
