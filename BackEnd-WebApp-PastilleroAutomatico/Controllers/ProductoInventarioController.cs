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
    public class ProductoInventarioController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoInventarioController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
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
                var listadoProductoInventario = _unitOfWork.iProductoInventarioRepository.GetAll().Where(x => x.ActivoProductoInventario == true);

                var listadoProductoInventarioDTO = _mapper.Map<IEnumerable<ProductoInventarioDTO>>(listadoProductoInventario);

                return Ok(listadoProductoInventarioDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("inventario/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var productoInventario = _unitOfWork.iProductoInventarioRepository.findId(id);

                if (productoInventario == null) return NotFound();

                var productoInventarioDTO = _mapper.Map<ProductoInventarioDTO>(productoInventario);

                return Ok(productoInventarioDTO);
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
                var listadoProductoInventario = _unitOfWork.iProductoInventarioRepository.GetAll().Where(x => x.ActivoProductoInventario == true && x.ProductoId == productoID);

                var listadoProductoInventarioDTO = _mapper.Map<IEnumerable<ProductoInventarioDTO>>(listadoProductoInventario);

                return Ok(listadoProductoInventarioDTO);
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
                var productoInventario = _unitOfWork.iProductoInventarioRepository.findId(id);

                if (productoInventario == null) return NotFound();

                productoInventario.ActivoProductoInventario = false;
                productoInventario.FechaEliminacionProductoInventario = DateTime.Now;

                _unitOfWork.iProductoInventarioRepository.Update(productoInventario);
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
        public async Task<IActionResult> Post(ProductoInventarioDTO productoInventarioDTO)
        {
            try
            {
                var productoRequest = _unitOfWork.iProductoInventarioRepository.FindByName(productoInventarioDTO.NombreProductoInventario, productoInventarioDTO.ProductoId);

                if (productoRequest != null) return BadRequest("Ya existe un almacen con ese nombre.");


                var productoInventario = _mapper.Map<ProductoInventario>(productoInventarioDTO);

                productoInventario.ActivoProductoInventario = true;
                productoInventario.FechaCreacionProductoInventario = DateTime.Now;

                _unitOfWork.iProductoInventarioRepository.Add(productoInventario);
                _unitOfWork.SaveChanges();

                var productoItemDTO = _mapper.Map<ProductoInventarioDTO>(productoInventario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, ProductoInventarioDTO productoInventarioDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var productoInventarioItem = _unitOfWork.iProductoInventarioRepository.findId(id);

                if (productoInventarioItem == null) return NotFound();

                var productoRequest = _unitOfWork.iProductoInventarioRepository.FindByName(productoInventarioDTO.NombreProductoInventario, productoInventarioDTO.ProductoId);

                if (productoRequest != null) return BadRequest("Ya existe un almacen con ese nombre.");

                var productoInventario = _mapper.Map<ProductoInventario>(productoInventarioDTO);

                productoInventarioItem.NombreProductoInventario = productoInventario.NombreProductoInventario;
                productoInventarioItem.CantidadProductoInventario = productoInventario.CantidadProductoInventario;
                productoInventarioItem.FechaModificacionProductoInventario = DateTime.Now;

                _unitOfWork.iProductoInventarioRepository.Update(productoInventarioItem);

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
