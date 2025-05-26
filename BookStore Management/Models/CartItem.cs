using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_Management.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [Required, Range(1, 1000)]
        public int Quantity { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
