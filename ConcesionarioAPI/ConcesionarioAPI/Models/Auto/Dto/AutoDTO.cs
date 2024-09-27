using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace concesionarioAPI.Models.Auto.Dto
{
    public class AutoDTO
    {
        public int Id { get; set; }

        public string Marca { get; set; } = null!;

        public string Modelo { get; set; } = null!;

        public string Transmision { get; set; } = null!;

        public bool TieneEstereo { get; set; }

        public int CantidadPuertas { get; set; }

        public DateTime FechaFabricacion { get; set; } = DateTime.Now;

        public Combustible.Combustible Combustible { get; set; } = null!;
    }
}
