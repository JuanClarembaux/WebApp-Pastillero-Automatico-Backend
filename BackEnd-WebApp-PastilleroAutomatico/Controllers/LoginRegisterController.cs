using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;
using BackEnd_WebApp_PastilleroAutomatico.Repositories;
using BackEnd_WebApp_PastilleroAutomatico.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BackEnd_WebApp_PastilleroAutomatico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginRegisterController(IUsuarioRepository usuarioRepository, IConfiguration configuration, IUserService userService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Usuario>> Register(UsuarioDTO usuarioDTO)
        {

            /*var emailRequest = await _usuarioRepository.GetUsuarioByEmail(usuarioDTO.Email);

            if (emailRequest != null) return BadRequest("Email ya registrado.");
            */
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            await _usuarioRepository.AddUsuario(usuario);

            var usuarioItemDTO = _mapper.Map<UsuarioDTO>(usuario);
            return CreatedAtAction("Get", new { id = usuarioItemDTO.Email }, usuarioItemDTO);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UsuarioDTO usuarioDTO)
        {
            var emailRequest = _usuarioRepository.GetUsuarioByEmail(usuarioDTO.Email);

            if (emailRequest == null) return BadRequest("User not found.");

            var usuario = _mapper.Map<Usuario>(usuarioDTO);


            string token = CreateToken(usuario);

            /*var refreshToken = GenerateRefreshToken();

            SetRefreshToken(usuario, refreshToken);
            */

            return Ok(token);
        }

        /*[HttpPost("refresh-token")]
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
        }*/

        private string CreateToken(Usuario user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
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
    }
}
