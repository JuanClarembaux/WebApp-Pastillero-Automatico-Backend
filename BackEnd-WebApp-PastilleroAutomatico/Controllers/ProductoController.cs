using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;
using BackEnd_WebApp_PastilleroAutomatico.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace BackEnd_WebApp_PastilleroAutomatico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listadoProducto = await _productoRepository.GetListProducto();

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
                var producto = await _productoRepository.GetProducto(id);

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
                var producto = await _productoRepository.GetProducto(id);

                if (producto == null)
                {
                    return NotFound();
                }

                await _productoRepository.DeleteProducto(producto);

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

                producto = await _productoRepository.AddProducto(producto);

                var productoItemDTO = _mapper.Map<ProductoDTO>(producto);

                return CreatedAtAction("Get", new { id = productoItemDTO.Id }, productoItemDTO);
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
                var producto = _mapper.Map<Producto>(productoDTO);

                if (id != producto.Id) return BadRequest();

                var productoItem = await _productoRepository.GetProducto(id);

                if(productoItem == null) return NotFound();

                await _productoRepository.UpdateProducto(producto);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
