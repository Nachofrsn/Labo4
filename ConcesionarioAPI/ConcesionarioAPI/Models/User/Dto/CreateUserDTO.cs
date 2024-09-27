using System.ComponentModel.DataAnnotations;

namespace concesionarioAPI.Models.User.Dto
{
    public class CreateUserDTO
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
    }
}
