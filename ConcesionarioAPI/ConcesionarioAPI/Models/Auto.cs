namespace ConcesionarioAPI.Models
{
    public class Auto
    {
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Motor { get; set; } = null!;
        public int CantPuertas { get; set; } 
        public string Transmision { get; set; } = null!;
        public string TipoCombustible { get; set; } = null!;
        public bool TieneEstereo { get; set; } 
        public DateTime FechaFabricacion { get; set; } = DateTime.Today;

    }
}
