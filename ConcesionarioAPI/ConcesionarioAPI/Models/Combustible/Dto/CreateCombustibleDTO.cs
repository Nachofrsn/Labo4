using System.ComponentModel.DataAnnotations;

namespace concesionarioAPI.Models.Combustible.Dto
{
    public class CreateCombustibleDTO
    {
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
