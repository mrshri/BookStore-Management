namespace BookStore_Management.ModelDtos.OrderDto
{
    public class CreateOrderDto
    {
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
