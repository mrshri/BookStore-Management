using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_Management.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [MaxLength(300)]
        public string ImageUrl { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
