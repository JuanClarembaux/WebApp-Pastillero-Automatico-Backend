using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;
using BackEnd_WebApp_PastilleroAutomatico.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_WebApp_PastilleroAutomatico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IGeneratePdf _generatePDF;

        public ProductoController(IUnitOfWorkRepository unitOfWork, IMapper mapper/*, IGeneratePdf generatePdf*/)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_generatePDF = generatePdf;
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Post(ProductoEInventarioDTO productoEInventarioDTO)
        {
            try
            {
                var productoRequest = _unitOfWork.iProductoRepository.FindByName(productoEInventarioDTO.NombreProducto);

                if (productoRequest != null) return BadRequest("Ya existe un producto con ese nombre.");


                ProductoDTO productoDTO = new ProductoDTO(productoEInventarioDTO.NombreProducto, productoEInventarioDTO.MarcaProducto, productoEInventarioDTO.DescripcionProducto,
                                                            productoEInventarioDTO.CategoriaProducto, productoEInventarioDTO.PrecioProducto, productoEInventarioDTO.SkuProducto);
                ProductoInventarioDTO productoInventarioDTO = new ProductoInventarioDTO(productoEInventarioDTO.NombreProductoInventario, productoEInventarioDTO.CantidadProductoInventario);

                var producto = _mapper.Map<Producto>(productoDTO);
                var productoInventario = _mapper.Map<ProductoInventario>(productoInventarioDTO);

                producto.ActivoProducto = true;
                producto.FechaCreacionProducto = DateTime.Now;
                producto.FechaModificacionProducto = null;
                producto.FechaEliminacionProducto = null;

                _unitOfWork.iProductoRepository.Add(producto);
                _unitOfWork.SaveChanges();

                productoInventario.ProductoId = _unitOfWork.iProductoRepository.GetByName(productoEInventarioDTO.NombreProducto).IdProducto;
                productoInventario.ActivoProductoInventario = true;
                productoInventario.FechaCreacionProductoInventario = DateTime.Now;
                productoInventario.FechaModificacionProductoInventario = null;
                productoInventario.FechaEliminacionProductoInventario = null;

                _unitOfWork.iProductoInventarioRepository.Add(productoInventario);
                _unitOfWork.SaveChanges();

                var productoItemDTO = _mapper.Map<ProductoDTO>(producto);

                //return CreatedAtAction("Get", new { id = productoItemDTO.Id }, productoItemDTO);
                //return CreatedAtAction("Get", producto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, ProductoDTO productoDTO)
        {
            try
            {
                if (id == null) return BadRequest();

                var productoItem = _unitOfWork.iProductoRepository.findId(id);

                if (productoItem == null) return NotFound();

                var productoRequest = _unitOfWork.iProductoRepository.FindByName(productoDTO.NombreProducto);

                if (productoRequest != null) return BadRequest("Ya existe un producto con ese nombre.");

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
        /*
        [HttpPost("/facturaPDF")]
        public /*async Task<// byte[]/*> // GenerarFacturaPDF(/*ProductoDTO productoDTO*///)
        //{
            /*var producto = _mapper.Map<Producto>(productoDTO);

            return new ViewAsPdf("GenerarFacturaPDF", producto)
            {
                FileName = $"Venta x.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };*/


        /*    var html = @"<!DOCTYPE html>
                        <html>
                        <head>
                        </head>
                        <body>
                            <header>
                                <h1>This is a hardcoded test</h1>
                            </header>
                            <div>
                                <h2>456789</h2>
                            </div>
                        </body>";

            var pdf = _generatePDF.GetPDF(html);
            /*var pdfStream = new System.IO.MemoryStream();
            pdfStream.Write(pdf, 0, pdf.Length);
            pdfStream.Position = 0;*/
        /*    return pdf;

        }
        */
    }
}
