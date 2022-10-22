namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class ProductoImagenDTO
    {
        public int IdProductoImagen { get; set; }
        public int ProductoId { get; set; }
        public string NombreProductoImagen { get; set; } = null!;
        public byte[] ArchivoProductoImagen { get; set; } = null!;
    }
}
