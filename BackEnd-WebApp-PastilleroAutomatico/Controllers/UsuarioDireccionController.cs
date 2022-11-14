
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
    public class UsuarioDireccionController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioDireccionController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
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
                var listadoUsuarioDireccion = _unitOfWork.iUsuarioDireccionRepository.GetAll().Where(x => x.ActivoUsuarioDireccion == true);

                var listadoUsuarioDireccionDTO = _mapper.Map<IEnumerable<UsuarioDireccionDTO>>(listadoUsuarioDireccion);

                return Ok(listadoUsuarioDireccionDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("direccion/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuarioDireccion = _unitOfWork.iUsuarioDireccionRepository.findId(id);

                if (usuarioDireccion == null) return NotFound();

                var usuarioDireccionDTO = _mapper.Map<UsuarioDireccionDTO>(usuarioDireccion);

                return Ok(usuarioDireccionDTO);
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
                var listadoUsuarioDireccion = _unitOfWork.iUsuarioDireccionRepository.GetAll().Where(x => x.ActivoUsuarioDireccion == true && x.UsuarioId == usuarioID);

                var listadoUsuarioDireccionDTO = _mapper.Map<IEnumerable<UsuarioDireccionDTO>>(listadoUsuarioDireccion);

                return Ok(listadoUsuarioDireccionDTO);
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
                var usuarioDireccion = _unitOfWork.iUsuarioDireccionRepository.findId(id);

                if (usuarioDireccion == null) return NotFound();

                usuarioDireccion.ActivoUsuarioDireccion = false;
                usuarioDireccion.FechaEliminacionUsuarioDireccion = DateTime.Now;

                _unitOfWork.iUsuarioDireccionRepository.Update(usuarioDireccion);
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
        public async Task<IActionResult> Post(UsuarioDireccionDTO usuarioDireccionDTO)
        {
            try
            {
                var usuarioDireccionRequest = _unitOfWork.iUsuarioDireccionRepository.FindByName(usuarioDireccionDTO.DireccionUsuario, usuarioDireccionDTO.UsuarioId);

                if (usuarioDireccionRequest != null) return BadRequest("Ya existe una direccion con ese nombre.");


                var usuarioDireccion = _mapper.Map<UsuarioDireccion>(usuarioDireccionDTO);

                usuarioDireccion.ActivoUsuarioDireccion = true;
                usuarioDireccion.FechaCreacionUsuarioDireccion = DateTime.Now;

                _unitOfWork.iUsuarioDireccionRepository.Add(usuarioDireccion);
                _unitOfWork.SaveChanges();

                var usuarioDireccionItemDTO = _mapper.Map<UsuarioDireccionDTO>(usuarioDireccion);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UsuarioDireccionDTO usuarioDireccionDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var usuarioDireccionItem = _unitOfWork.iUsuarioDireccionRepository.findId(id);

                if (usuarioDireccionItem == null) return NotFound();

                var usuarioDireccionRequest = _unitOfWork.iUsuarioDireccionRepository.FindByName(usuarioDireccionDTO.DireccionUsuario, usuarioDireccionDTO.UsuarioId);

                if (usuarioDireccionRequest != null) return BadRequest("Ya existe una direccion con ese nombre.");

                var usuarioDireccion = _mapper.Map<UsuarioDireccion>(usuarioDireccionDTO);

                usuarioDireccionItem.DireccionUsuario = usuarioDireccion.DireccionUsuario;
                usuarioDireccionItem.Ciudad = usuarioDireccion.Ciudad;
                usuarioDireccionItem.Provincia = usuarioDireccion.Provincia;
                usuarioDireccionItem.Pais = usuarioDireccion.Pais;
                usuarioDireccionItem.FechaModificacionUsuarioDireccion = DateTime.Now;

                _unitOfWork.iUsuarioDireccionRepository.Update(usuarioDireccionItem);

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
