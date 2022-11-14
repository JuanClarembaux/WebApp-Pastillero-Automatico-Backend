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
    public class FacturaController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public FacturaController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
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
                var listadoFactura = _unitOfWork.iFacturaRepository.GetAll().Where(x => x.ActivoFactura == true);

                var listadoFacturaDTO = _mapper.Map<IEnumerable<FacturaDTO>>(listadoFactura);

                return Ok(listadoFacturaDTO);
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
                var factura = _unitOfWork.iFacturaRepository.findId(id);

                if (factura == null) return NotFound();

                var facturaDTO = _mapper.Map<FacturaDTO>(factura);

                return Ok(facturaDTO);
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
                var factura = _unitOfWork.iFacturaRepository.findId(id);

                if (factura == null) return NotFound();

                factura.ActivoFactura = false;
                factura.FechaEliminacionFactura = DateTime.Now;

                _unitOfWork.iFacturaRepository.Update(factura);
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
        public async Task<IActionResult> Post(FacturaDTO facturaDTO)
        {
            try
            {
                var facturaRequest = _unitOfWork.iFacturaRepository.FindByNumber(facturaDTO.NumeroFactura);

                if (facturaRequest != null) return BadRequest("Ya existe una direccion con ese nombre.");


                var factura = _mapper.Map<Factura>(facturaDTO);

                factura.ActivoFactura = true;
                factura.FechaCreacionFactura = DateTime.Now;

                _unitOfWork.iFacturaRepository.Add(factura);
                _unitOfWork.SaveChanges();

                var facturaItemDTO = _mapper.Map<FacturaDTO>(factura);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, FacturaDTO facturaDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var facturaItem = _unitOfWork.iFacturaRepository.findId(id);

                if (facturaItem == null) return NotFound();

                var factura = _mapper.Map<Factura>(facturaDTO);

                facturaItem.NumeroFactura = factura.NumeroFactura;
                facturaItem.UrlArchivoFactura = factura.UrlArchivoFactura;
                facturaItem.FechaModificacionFactura = DateTime.Now;

                _unitOfWork.iFacturaRepository.Update(facturaItem);

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
