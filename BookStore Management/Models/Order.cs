using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_Management.Models
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;


        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
