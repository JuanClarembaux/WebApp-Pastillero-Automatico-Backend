using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;
using BackEnd_WebApp_PastilleroAutomatico.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_WebApp_PastilleroAutomatico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {                
                var listadoProducto = _unitOfWork.iProductoRepository.GetAll().Where(x => x.ActivoProducto == true);

                var listadoProductoDTO = _mapper.Map<IEnumerable<ProductoDTO>>(listadoProducto);

                return Ok(listadoProductoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var producto = _unitOfWork.iProductoRepository.findId(id);

                if (producto == null) return NotFound();

                var productoDTO = _mapper.Map<ProductoDTO>(producto);

                return Ok(productoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var producto = _unitOfWork.iProductoRepository.findId(id);

                if (producto == null)
                {
                    return NotFound();
                }

                //_unitOfWork.iProductoRepository.Delete(producto);
                producto.ActivoProducto = false;
                producto.FechaEliminacionProducto = DateTime.Now;

                _unitOfWork.iProductoRepository.Update(producto);
                _unitOfWork.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoDTO productoDTO)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDTO);

                producto.ActivoProducto = true;
                producto.FechaCreacionProducto = DateTime.Now;
                producto.FechaModificacionProducto = null;
                producto.FechaEliminacionProducto = null;

                _unitOfWork.iProductoRepository.Add(producto);

                _unitOfWork.SaveChanges();

                var productoItemDTO = _mapper.Map<ProductoDTO>(producto);

                //return CreatedAtAction("Get", new { id = productoItemDTO.Id }, productoItemDTO);
                return CreatedAtAction("Get", producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoDTO productoDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var productoItem = _unitOfWork.iProductoRepository.findId(id);

                if (productoItem == null) return NotFound();

                var producto = _mapper.Map<Producto>(productoDTO);

                productoItem.NombreProducto = producto.NombreProducto;
                productoItem.MarcaProducto = producto.MarcaProducto;
                productoItem.DescripcionProducto = producto.DescripcionProducto;
                productoItem.CategoriaProducto = producto.CategoriaProducto;
                productoItem.PrecioProducto = producto.PrecioProducto;
                productoItem.SkuProducto = producto.SkuProducto;
                productoItem.FechaModificacionProducto = DateTime.Now;

                _unitOfWork.iProductoRepository.Update(productoItem);

                _unitOfWork.SaveChanges();

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
