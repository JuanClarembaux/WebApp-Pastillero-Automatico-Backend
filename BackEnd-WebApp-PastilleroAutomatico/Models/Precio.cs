﻿namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public class Precio
    {
        public int Id { get; set; }
        public int productoID { get; set; }
        public float precioBaseProducto { get; set; }
        public float costoImpuestos { get; set; }
        public float precioTotalProducto { get; set; }
    }
}