using concesionarioAPI.Models.Auto.Dto;
using concesionarioAPI.Models.Auto;
using concesionarioAPI.Services;
using concesionarioAPI.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using concesionarioAPI.Models.User.Dto;
using concesionarioAPI.Models.User;

namespace concesionarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UsersController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<List<UsersDTO>> Get()
        {
            try
            {
                var users = _userServices.GetAll();
                return Ok(users);
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
        public ActionResult<UserDTO> Get(int id)
        {
            try
            {
                var user = _userServices.GetOneById(id);
                return Ok(user);
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
        public ActionResult<User> Post([FromBody] CreateUserDTO createUserDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = _userServices.CreateOne(createUserDTO);
               
                return Created(nameof(Post), user);
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
        public ActionResult<User> Put(int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = _userServices.UpdateOneById(id, updateUserDTO);
                return Ok(user);

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
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                _userServices.DeleteOneById(id);
                return Ok(new CustomMessage($"El Usuario con el Id = {id} fue eliminado!"));
                // tambien se puede devolver un 'no content 204'
                // return NoContent();

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
