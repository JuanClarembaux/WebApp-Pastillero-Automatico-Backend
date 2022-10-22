using System;
using System.Collections.Generic;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class UsuarioDetalle
    {
        public int IdUsuarioDetalle { get; set; }
        public int UsuarioId { get; set; }
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; }
        public DateTime? FechaNacimientoUsuario { get; set; }
        public DateTime FechaCreacionUsuarioDetalle { get; set; }
        public DateTime? FechaModificacionUsuarioDetalle { get; set; }
        public DateTime? FechaEliminacionUsuarioDetalle { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
    }
}
