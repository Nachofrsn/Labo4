namespace concesionarioAPI.Models.Auto.Dto
{
    // Este DTO solo es para lectura, esto datos se mostraran en la lista (GetAll)
    public class AutosDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;

        public DateTime FechaFabricacion { get; set; } = DateTime.Now;
    }
}
