using concesionarioAPI.Models.Combustible;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concesionarioAPI.Models.Auto
{
    public class Auto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Marca { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Transmision { get; set; } = null!;

        [Required]
        public bool TieneEstereo { get; set; }

        [Required]
        public int CantidadPuertas { get; set; }

        public DateTime FechaFabricacion { get; set; } = DateTime.Now;

        [Required]
        public int CombustibleId { get; set; }

        [ForeignKey("CombustibleId")]
        public Combustible.Combustible Combustible { get; set; } = null!;
    }
}
