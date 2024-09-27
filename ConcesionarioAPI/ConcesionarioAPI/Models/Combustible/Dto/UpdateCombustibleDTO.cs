using System.ComponentModel.DataAnnotations;

namespace concesionarioAPI.Models.Combustible.Dto
{
    public class UpdateCombustibleDTO
    {
        [MaxLength(30)]
        public string? Nombre { get; set; }
    }
}
