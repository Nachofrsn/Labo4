using ConcesionarioAPI.Models;
using ConcesionarioAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcesionarioAPI.Controllers
{
    [Route("api/autos")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        private readonly AutoServices _autoServices;
        public AutosController()
        {
            _autoServices = new AutoServices();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Auto>> Get()
        {
            var autos = _autoServices.GetAll();
            return Ok(autos);
        } 

        /*[HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Auto> GetOne()
        {
            Boolean result = false;
            var auto = new Auto
            {
                Marca = "Ford",
                Modelo = "Focus",
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
        }*/
    }
}
