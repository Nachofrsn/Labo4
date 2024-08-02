using ConcesionarioAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcesionarioAPI.Controllers
{
    [Route("api/autos")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Auto> GetOne()
        {
            Boolean result = false;
            var auto = new Auto
            {
                Marca = "Ford",
                Modelo = "Focus",
                Color = "Blanco",
                Motor = "1.6",
                CantPuertas = 4,
                Transmision = "Automatica",
                TipoCombustible = "Super",
                TieneEstereo = true,
            };
            if (result)
            {
                return Ok(auto);
            }
            return NotFound(new { Message = "No se encontro el auto" });
        }
    }
}
