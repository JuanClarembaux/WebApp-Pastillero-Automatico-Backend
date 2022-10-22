using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;
using BackEnd_WebApp_PastilleroAutomatico.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BackEnd_WebApp_PastilleroAutomatico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LoginRegisterController(IUnitOfWorkRepository unitOfWork, IConfiguration configuration, /*IUserService userService,*/ IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async /*Task<IActionResult>*/ Task<ActionResult<Usuario>> Register(UsuarioDTO usuarioDTO)
        {
            try
            {
                var emailRequest = _unitOfWork.iUsuarioRepository.GetByEmail(usuarioDTO.MailUsuario);

                if (emailRequest != null) return BadRequest("Email ya registrado.");

                var usuario = _mapper.Map<Usuario>(usuarioDTO);

                usuario.RolUsuario = "usuario";
                usuario.ActivoUsuario = true;
                usuario.FechaCreacionUsuario = DateTime.Now;
                usuario.FechaModificacionUsuario = null;
                usuario.FechaEliminacionUsuario = null;

                _unitOfWork.iUsuarioRepository.Add(usuario);
                _unitOfWork.SaveChanges();

                var usuarioItemDTO = _mapper.Map<UsuarioDTO>(usuario);
                //return CreatedAtAction("Get", usuarioItemDTO /*new { id = usuarioItemDTO.Email }, usuarioItemDTO*/); //   PREGUNTAR SOBRE ERROR USANDO CreatedAtAction
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UsuarioDTO usuarioDTO)
        {
            try
            {
                var emailRequest = _unitOfWork.iUsuarioRepository.GetByEmail(usuarioDTO.MailUsuario);

                if (emailRequest == null) return BadRequest("User not found.");

                var usuario = _mapper.Map<Usuario>(usuarioDTO);

                string token = CreateToken(usuario);

                /*
                var refreshToken = GenerateRefreshToken();
                SetRefreshToken(usuario, refreshToken);
                */

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        private string CreateToken(Usuario user)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.MailUsuario),
                    new Claim(ClaimTypes.Role, user.RolUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(23),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}





/*
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken(Usuario usuario)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!usuario.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (usuario.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(usuario);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(usuario, newRefreshToken);

            return Ok(token);
        }
        
        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddMinutes(23),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(Usuario usuario, RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            usuario.RefreshToken = newRefreshToken.Token;
            usuario.TokenCreated = newRefreshToken.Created;
            usuario.TokenExpires = newRefreshToken.Expires;
        }
        */