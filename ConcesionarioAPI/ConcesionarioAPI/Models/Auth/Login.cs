using System.ComponentModel.DataAnnotations;

namespace concesionarioAPI.Models.Auth
{
    public class Login
    {
<<<<<<< HEAD
        public string? Username { get; set; }

=======
        public string? UserName { get; set; }
        
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string Password { get; set; } = null!;
    }
}
