<<<<<<< HEAD
﻿
using AutoMapper;
using concesionarioAPI.Models.Auth;
using concesionarioAPI.Models.Auth.Dto;
using concesionarioAPI.Services;
using concesionarioAPI.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
=======
﻿using concesionarioAPI.Models.Auth;
using concesionarioAPI.Models.Auth.Dto;
using concesionarioAPI.Models.Combustible.Dto;
using concesionarioAPI.Services;
using concesionarioAPI.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9

namespace concesionarioAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
<<<<<<< HEAD
        private readonly AuthServices _authServices;
        private readonly UserServices _userService;
        private readonly IEncoderServices _encoderServices;
        private readonly IMapper _mapper;

        public AuthController(AuthServices authServices, UserServices userService, IMapper mapper, IEncoderServices encoderServices)
        {
            _authServices = authServices;
            _userService = userService;
            _mapper = mapper;
            _encoderServices = encoderServices;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] Login login)
        {
            try
            {
                var user = await _userService.GetOneByUsernameOrEmail(login.Username, login.Email);

                var passwordMatch = _encoderServices.Verify(login.Password, user.Password);

                if (!passwordMatch)
                {
                    throw new CustomHttpException("Invalid Credentials", HttpStatusCode.BadRequest);
                }

                var token = _authServices.GenerateJwtToken(user);

                return Ok(new LoginResponseDTO { Token = token });
=======

        private readonly UserServices _userServices;
        private readonly IEncoderServices _encoderServices;
        private readonly string secretKey;
        public AuthController(UserServices userServices, IEncoderServices encoderServices, IConfiguration config)
        {
            _userServices = userServices;
            _encoderServices = encoderServices;
            secretKey = config.GetSection("jwtSettings").GetSection("secretKey").ToString() ?? null!;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userServices.GetOneByUsernameOrEmail(login.UserName, login.Email);

                if (!_encoderServices.Verify(login.Password, user.Password))
                {
                    ModelState.AddModelError("Message", "Credenciales incorrectas");
                    return BadRequest(ModelState);
                }

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim("Id", user.Id.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string token = tokenHandler.WriteToken(tokenConfig);

                return Ok(new LoginResponseDto { Token = token });
>>>>>>> 030e5a364a6670effa8e7a2f8c43c7491087b1d9
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
