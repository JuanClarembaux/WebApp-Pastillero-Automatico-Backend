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

    // HAY QUE MODIFICAR EL ARCHIVO IMAGEN DE BYTE POR TIPO STRING

    public class ProductoImagenController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoImagenController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
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
                var listadoProductoImagen = _unitOfWork.iProductoImagenRepository.GetAll();

                var listadoProductoImagenDTO = _mapper.Map<IEnumerable<ProductoImagenDTO>>(listadoProductoImagen);

                return Ok(listadoProductoImagenDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("imagen/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var productoImagen = _unitOfWork.iProductoImagenRepository.findId(id);

                if (productoImagen == null) return NotFound();

                var productoImagenDTO = _mapper.Map<ProductoImagenDTO>(productoImagen);

                return Ok(productoImagenDTO);
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
                var listadoProductoImagen = _unitOfWork.iProductoImagenRepository.GetAll().Where(x => x.ProductoId == productoID);

                var listadoProductoImagenDTO = _mapper.Map<IEnumerable<ProductoImagenDTO>>(listadoProductoImagen);

                return Ok(listadoProductoImagenDTO);
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
                var productoImagen = _unitOfWork.iProductoImagenRepository.findId(id);

                if (productoImagen == null) return NotFound();

                _unitOfWork.iProductoImagenRepository.Delete(productoImagen);
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
        public async Task<IActionResult> Post(ProductoImagenDTO productoImagenDTO)
        {
            try
            {
                var productoImagenRequest = _unitOfWork.iProductoImagenRepository.FindByName(productoImagenDTO.NombreProductoImagen);

                if (productoImagenRequest != null) return BadRequest("Ya existe una imagen con ese nombre.");


                var productoImagen = _mapper.Map<ProductoImagen>(productoImagenDTO);

                _unitOfWork.iProductoImagenRepository.Add(productoImagen);
                _unitOfWork.SaveChanges();

                var productoImagenItemDTO = _mapper.Map<ProductoImagenDTO>(productoImagen);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, ProductoImagenDTO productoImagenDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var productoImagenItem = _unitOfWork.iProductoImagenRepository.findId(id);

                if (productoImagenItem == null) return NotFound();

                var productoImagen = _mapper.Map<ProductoImagen>(productoImagenDTO);

                productoImagenItem.NombreProductoImagen = productoImagen.NombreProductoImagen;
                productoImagenItem.UrlArchivoImagen = productoImagen.UrlArchivoImagen;

                _unitOfWork.iProductoImagenRepository.Update(productoImagenItem);

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
