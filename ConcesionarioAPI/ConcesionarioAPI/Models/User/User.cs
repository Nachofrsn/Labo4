using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concesionarioAPI.Models.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
