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
    public class UsuarioTelefonoController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioTelefonoController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
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
                var listadoUsuarioTelefono = _unitOfWork.iUsuarioTelefonoRepository.GetAll().Where(x => x.ActivoUsuarioTelefono == true);

                var listadoUsuarioTelefonoDTO = _mapper.Map<IEnumerable<UsuarioTelefonoDTO>>(listadoUsuarioTelefono);

                return Ok(listadoUsuarioTelefonoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("telefono/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuarioTelefono = _unitOfWork.iUsuarioTelefonoRepository.findId(id);

                if (usuarioTelefono == null) return NotFound();

                var usuarioTelefonoDTO = _mapper.Map<UsuarioTelefonoDTO>(usuarioTelefono);

                return Ok(usuarioTelefonoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuarioID}")]
        [Authorize]
        public async Task<IActionResult> GetByProductoID(int usuarioID)
        {
            try
            {
                var listadoUsuarioTelefono = _unitOfWork.iUsuarioTelefonoRepository.GetAll().Where(x => x.ActivoUsuarioTelefono == true && x.UsuarioId == usuarioID);

                var listadoUsuarioTelefonoDTO = _mapper.Map<IEnumerable<UsuarioTelefonoDTO>>(listadoUsuarioTelefono);

                return Ok(listadoUsuarioTelefonoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuarioTelefono = _unitOfWork.iUsuarioTelefonoRepository.findId(id);

                if (usuarioTelefono == null) return NotFound();

                usuarioTelefono.ActivoUsuarioTelefono = false;
                usuarioTelefono.FechaEliminacionUsuarioTelefono = DateTime.Now;

                _unitOfWork.iUsuarioTelefonoRepository.Update(usuarioTelefono);
                _unitOfWork.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(UsuarioTelefonoDTO usuarioTelefonoDTO)
        {
            try
            {
                var usuarioTelefonoRequest = _unitOfWork.iUsuarioTelefonoRepository.FindByNumber(usuarioTelefonoDTO.TelefonoUsuario, usuarioTelefonoDTO.UsuarioId);

                if (usuarioTelefonoRequest != null) return BadRequest("Ya existe un telefono para este usuario con ese numero registrado.");


                var usuarioTelefono = _mapper.Map<UsuarioTelefono>(usuarioTelefonoDTO);

                usuarioTelefono.ActivoUsuarioTelefono = true;
                usuarioTelefono.FechaCreacionUsuarioTelefono = DateTime.Now;

                _unitOfWork.iUsuarioTelefonoRepository.Add(usuarioTelefono);
                _unitOfWork.SaveChanges();

                var usuarioTelefonoItemDTO = _mapper.Map<UsuarioTelefonoDTO>(usuarioTelefono);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UsuarioTelefonoDTO usuarioTelefonoDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var usuarioTelefonoItem = _unitOfWork.iUsuarioTelefonoRepository.findId(id);

                if (usuarioTelefonoItem == null) return NotFound();

                var usuarioTelefonoRequest = _unitOfWork.iUsuarioTelefonoRepository.FindByNumber(usuarioTelefonoDTO.TelefonoUsuario, usuarioTelefonoDTO.UsuarioId);

                if (usuarioTelefonoRequest != null) return BadRequest("Ya existe un telefono para este usuario con ese numero registrado.");

                var usuarioTelefono = _mapper.Map<UsuarioTelefono>(usuarioTelefonoDTO);

                usuarioTelefonoItem.TelefonoUsuario = usuarioTelefono.TelefonoUsuario;
                usuarioTelefonoItem.FechaModificacionUsuarioTelefono = DateTime.Now;

                _unitOfWork.iUsuarioTelefonoRepository.Update(usuarioTelefonoItem);

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
