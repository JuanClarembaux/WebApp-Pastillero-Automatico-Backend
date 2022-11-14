using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;
using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_WebApp_PastilleroAutomatico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listadoUsuarios = _unitOfWork.iUsuarioRepository.GetAll().Where(x => x.ActivoUsuario == true);

                var listadoUsuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(listadoUsuarios);

                return Ok(listadoUsuariosDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = _unitOfWork.iUsuarioRepository.findId(id);
                var usuarioDetalle = _unitOfWork.iUsuarioDetalleRepository.FindByUserID(id);

                if (usuario == null) return NotFound();
                if (usuarioDetalle == null) return BadRequest("El usuario no tiene detalle");

                UsuarioRegisterDTO usuarioRegisterDTO = new UsuarioRegisterDTO();
                usuarioRegisterDTO.MailUsuario = usuario.MailUsuario;
                usuarioRegisterDTO.PasswordUsuario = usuario.PasswordUsuario;
                usuarioRegisterDTO.NombreUsuario = usuarioDetalle.NombreUsuario;
                usuarioRegisterDTO.ApellidoUsuario = usuarioDetalle.ApellidoUsuario;
                usuarioRegisterDTO.FechaNacimientoUsuario = usuarioDetalle.FechaNacimientoUsuario;

                return Ok(usuarioRegisterDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("mail/{email}")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioByEmail(string email)
        {
            if (email == null) return BadRequest();

            var emailRequest = _unitOfWork.iUsuarioRepository.GetByEmail(email);

            if (emailRequest == null) return BadRequest("User not found.");

            var usuarioDTO = _mapper.Map<UsuarioDTO>(emailRequest);

            return usuarioDTO;
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = _unitOfWork.iUsuarioRepository.findId(id);

                if (usuario == null) return NotFound();

                usuario.ActivoUsuario = false;
                usuario.FechaEliminacionUsuario = DateTime.Now;

                _unitOfWork.iUsuarioRepository.Update(usuario);
                _unitOfWork.SaveChanges();

                /*
                 * HABRIA QUE AGREGAR PARA DAR DE BAJA TODOS LOS DEMAS ITEMS DE OTRAS TABLAS QUE ESTEN RELACIONADOS AL USUARIO
                 */

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UsuarioRegisterDTO usuarioRegisterDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var usuarioItem = _unitOfWork.iUsuarioRepository.findId(id);
                var usuarioDetalleItem = _unitOfWork.iUsuarioDetalleRepository.FindByUserID(id);

                if (usuarioItem == null) return NotFound();
                if (usuarioDetalleItem == null) return NotFound("No se encuentra el detalle del usuario.");

                usuarioItem.MailUsuario = usuarioRegisterDTO.MailUsuario;
                usuarioItem.PasswordUsuario = usuarioRegisterDTO.PasswordUsuario;
                usuarioItem.FechaModificacionUsuario = DateTime.Now;

                usuarioDetalleItem.NombreUsuario = usuarioRegisterDTO.NombreUsuario;
                usuarioDetalleItem.ApellidoUsuario = usuarioRegisterDTO.ApellidoUsuario;
                usuarioDetalleItem.FechaNacimientoUsuario = usuarioRegisterDTO.FechaNacimientoUsuario;
                
                usuarioDetalleItem.FechaModificacionUsuarioDetalle = DateTime.Now;

                _unitOfWork.iUsuarioRepository.Update(usuarioItem);
                _unitOfWork.iUsuarioDetalleRepository.Update(usuarioDetalleItem);

                _unitOfWork.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
