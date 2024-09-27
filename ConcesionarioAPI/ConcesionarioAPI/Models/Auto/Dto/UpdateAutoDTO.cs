using System.ComponentModel.DataAnnotations;

namespace concesionarioAPI.Models.Auto.Dto
{
    // Este DTO se utilizará para actualizar los datos. Con el signo de pregunta (?) indicamos que el campo puede ser opcional o nulo.
    public class UpdateAutoDTO
    {
        [MaxLength(40)]
        public string? Marca { get; set; }

        [MaxLength(50)]
        public string? Modelo { get; set; }

        public int? CombustibleId { get; set; }

        [MaxLength(30)]
        public string? Transmision { get; set; }
        public bool? TieneEstereo { get; set; }
        public int? CantidadPuertas { get; set; }
    }
}
