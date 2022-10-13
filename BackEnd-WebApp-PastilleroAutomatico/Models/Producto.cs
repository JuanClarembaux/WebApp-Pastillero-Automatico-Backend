namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
    }
}
