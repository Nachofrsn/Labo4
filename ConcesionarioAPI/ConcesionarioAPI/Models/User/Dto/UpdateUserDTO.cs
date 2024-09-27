using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace concesionarioAPI.Models.User.Dto
{
    public class UpdateUserDTO
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Username { get; set; } = null!;
    }
}
