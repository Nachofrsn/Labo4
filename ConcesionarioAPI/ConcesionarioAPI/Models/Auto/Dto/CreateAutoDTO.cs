using System.ComponentModel.DataAnnotations;

namespace concesionarioAPI.Models.Auto.Dto
{
    // DTO para crear un nuevo Auto, los campos Id y FechaFabricacion se crearan automáticamente
    public class CreateAutoDTO
    {
        [Required]
        [MaxLength(40)]
        public string Marca { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; } = null!;

        [Required]
        public int CombustibleId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Transmision { get; set; } = null!;

        [Required]
        public bool TieneEstereo { get; set; }

        [Required]
        public int CantidadPuertas { get; set; }
    }
}
