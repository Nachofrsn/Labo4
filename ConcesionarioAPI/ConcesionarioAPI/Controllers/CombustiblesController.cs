using concesionarioAPI.Models.Combustible;
using concesionarioAPI.Models.Combustible.Dto;
using concesionarioAPI.Services;
using concesionarioAPI.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace concesionarioAPI.Controllers
{
    [Route("api/combustibles")]
    [ApiController]
    public class CombustiblesController : ControllerBase
    {
        private readonly CombustibleServices _combustibleServices;

        public CombustiblesController(CombustibleServices combustibleServices)
        {
            _combustibleServices = combustibleServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
<<<<<<< HEAD
        public async Task<ActionResult<List<Combustible>>> Get()
        {
            try
            {
                var combustibles = await _combustibleServices.GetAll();
=======
        public ActionResult<List<Combustible>> Get()
        {
            try
            {
                var combustibles = _combustibleServices.GetAll();
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
                return Ok(combustibles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
<<<<<<< HEAD
        public async Task<ActionResult<Combustible>> Get(int id)
        {
            try
            {
                var combustible = await _combustibleServices.GetOneById(id);
=======
        public ActionResult<Combustible> Get(int id)
        {
            try
            {
                var combustible = _combustibleServices.GetOneById(id);
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
                return Ok(combustible);
            }
            catch (CustomHttpException ex)
            {
                return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
<<<<<<< HEAD
        public async Task<ActionResult<Combustible>> Post([FromBody] CreateCombustibleDTO createCombustibleDto)
=======
        public ActionResult<Combustible> Post([FromBody] CreateCombustibleDTO createCombustibleDto)
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
<<<<<<< HEAD
                var combustible = await _combustibleServices.CreateOne(createCombustibleDto);
=======
                var combustible = _combustibleServices.CreateOne(createCombustibleDto);
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
                return Created(nameof(Post), combustible);

            }
            catch (CustomHttpException ex)
            {
                return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
<<<<<<< HEAD
        public async Task<ActionResult<Combustible>> Put(int id, [FromBody] UpdateCombustibleDTO updateCombustibleDTO)
=======
        public ActionResult<Combustible> Put(int id, [FromBody] UpdateCombustibleDTO updateCombustibleDTO)
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
<<<<<<< HEAD
                var combustible = await _combustibleServices.UpdateOneById(id, updateCombustibleDTO);
=======
                var combustible = _combustibleServices.UpdateOneById(id, updateCombustibleDTO);
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
                return Ok(combustible);
            }
            catch (CustomHttpException ex)
            {
                return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
<<<<<<< HEAD
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _combustibleServices.DeleteOneById(id);
=======
        public ActionResult Delete(int id)
        {
            try
            {
                _combustibleServices.DeleteOneById(id);
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
                return Ok(new CustomMessage($"El Combustible con el Id = {id} fue eliminado!"));

            }
            catch (CustomHttpException ex)
            {
                return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
            }
        }
    }
}
