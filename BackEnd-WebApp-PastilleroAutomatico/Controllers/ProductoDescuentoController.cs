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
    public class ProductoDescuentoController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoDescuentoController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
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
                var listadoProductoDescuento = _unitOfWork.iProductoDescuentoRepository.GetAll().Where(x => x.ActivoProductoDescuento == true);

                var listadoProductoDescuentoDTO = _mapper.Map<IEnumerable<ProductoDescuentoDTO>>(listadoProductoDescuento);

                return Ok(listadoProductoDescuentoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("descuento/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var productoDescuento = _unitOfWork.iProductoDescuentoRepository.findId(id);

                if (productoDescuento == null) return NotFound();

                var productoDescuentoDTO = _mapper.Map<ProductoDescuentoDTO>(productoDescuento);

                return Ok(productoDescuentoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productoID}")]
        [Authorize]
        public async Task<IActionResult> GetByProductoID(int productoID)
        {
            try
            {
                var listadoProductoDescuento = _unitOfWork.iProductoDescuentoRepository.GetAll().Where(x => x.ActivoProductoDescuento == true && x.ProductoId == productoID);

                var listadoProductoDescuentoDTO = _mapper.Map<IEnumerable<ProductoDescuentoDTO>>(listadoProductoDescuento);

                return Ok(listadoProductoDescuentoDTO);
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
                var productoDescuento = _unitOfWork.iProductoDescuentoRepository.findId(id);

                if (productoDescuento == null)
                {
                    return NotFound();
                }

                productoDescuento.ActivoProductoDescuento = false;
                productoDescuento.FechaEliminacionProductoDescuento = DateTime.Now;

                _unitOfWork.iProductoDescuentoRepository.Update(productoDescuento);
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
        public async Task<IActionResult> Post(ProductoDescuentoDTO productoDescuentoDTO)
        {
            try
            {
                var productoRequest = _unitOfWork.iProductoDescuentoRepository.FindByName(productoDescuentoDTO.NombreProductoDescuento, productoDescuentoDTO.ProductoId);

                if (productoRequest != null) return BadRequest("Ya existe un descuento con ese nombre.");

                
                var productoDescuento = _mapper.Map<ProductoDescuento>(productoDescuentoDTO);

                productoDescuento.ActivoProductoDescuento = true;
                productoDescuento.FechaCreacionProductoDescuento = DateTime.Now;

                _unitOfWork.iProductoDescuentoRepository.Add(productoDescuento);
                _unitOfWork.SaveChanges();

                var productoDescuentoItemDTO = _mapper.Map<ProductoDescuentoDTO>(productoDescuento);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, ProductoDescuentoDTO productoDescuentoDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var productoDescuentoItem = _unitOfWork.iProductoDescuentoRepository.findId(id);

                if (productoDescuentoItem == null) return NotFound();

                var productoRequest = _unitOfWork.iProductoDescuentoRepository.FindByName(productoDescuentoDTO.NombreProductoDescuento, productoDescuentoDTO.ProductoId);

                if (productoRequest != null) return BadRequest("Ya existe un descuento con ese nombre.");

                var productoDescuento = _mapper.Map<ProductoDescuento>(productoDescuentoDTO);

                productoDescuentoItem.NombreProductoDescuento = productoDescuento.NombreProductoDescuento;
                productoDescuentoItem.PorcentajeProductoDescuento = productoDescuento.PorcentajeProductoDescuento;
                productoDescuentoItem.FechaModificacionProductoDescuento = DateTime.Now;

                _unitOfWork.iProductoDescuentoRepository.Update(productoDescuentoItem);

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
