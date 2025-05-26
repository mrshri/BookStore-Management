using System.ComponentModel.DataAnnotations;

namespace BookStore_Management.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User";

        public ICollection<Order> Orders { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }
}
