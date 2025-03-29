using System.ComponentModel.DataAnnotations;

namespace WildRealms.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // You can add additional fields in the future, e.g., Email, DateOfBirth, etc.
    }
}

