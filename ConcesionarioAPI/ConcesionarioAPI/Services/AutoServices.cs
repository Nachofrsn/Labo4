using ConcesionarioAPI.Models;

namespace ConcesionarioAPI.Services
{
    public class AutoServices
    {
        public static List<Auto> autos = new List<Auto>
        {
            new Auto{
                Marca = "Ford",
                Modelo ="Ka",
                CantPuertas = 4,
                TieneEstereo=true,
                TipoCombustible="Super",
                Transmision="Manual"
            },
            new Auto{
                Marca = "Toyota",
                Modelo ="Corolla",
                CantPuertas = 4,
                TieneEstereo=true,
                TipoCombustible="Diesel",
                Transmision="Automatica"
            },
        };

        public List<Auto> GetAll()
        {
            return autos;
        }
    }
}
