using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;
using BackEnd_WebApp_PastilleroAutomatico.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
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

        public LoginRegisterController(IUnitOfWorkRepository unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Usuario>> Register(UsuarioRegisterDTO usuarioRegisterDTO)
        {
            try
            {
                var emailRequest = _unitOfWork.iUsuarioRepository.GetByEmail(usuarioRegisterDTO.MailUsuario);

                if (emailRequest != null) return BadRequest("Email ya registrado.");

                UsuarioDTO usuarioDTO = new UsuarioDTO(usuarioRegisterDTO.MailUsuario, usuarioRegisterDTO.PasswordUsuario);
                UsuarioDetalleDTO usuarioDetalleDTO = new UsuarioDetalleDTO(usuarioRegisterDTO.NombreUsuario, usuarioRegisterDTO.ApellidoUsuario, usuarioRegisterDTO.FechaNacimientoUsuario);


                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                var usuarioDetalle = _mapper.Map<UsuarioDetalle>(usuarioDetalleDTO);

                usuario.RolUsuario = "usuario";
                usuario.ActivoUsuario = true;
                usuario.FechaCreacionUsuario = DateTime.Now;
                usuario.FechaModificacionUsuario = null;
                usuario.FechaEliminacionUsuario = null;                 

                _unitOfWork.iUsuarioRepository.Add(usuario);
                _unitOfWork.SaveChanges();

                usuarioDetalle.UsuarioId = _unitOfWork.iUsuarioRepository.GetByEmail(usuario.MailUsuario).IdUsuario;
                usuarioDetalle.FechaCreacionUsuarioDetalle = DateTime.Now;
                usuarioDetalle.FechaModificacionUsuarioDetalle = null;
                usuarioDetalle.FechaEliminacionUsuarioDetalle = null;

                _unitOfWork.iUsuarioDetalleRepository.Add(usuarioDetalle);
                _unitOfWork.SaveChanges();
             
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
                    expires: DateTime.Now.AddHours(12),
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