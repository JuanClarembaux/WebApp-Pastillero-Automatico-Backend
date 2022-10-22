using System;
using System.Collections.Generic;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class UsuarioTelefono
    {
        public int IdUsuarioTelefono { get; set; }
        public int UsuarioId { get; set; }
        public string TelefonoUsuario { get; set; } = null!;
        public bool ActivoUsuarioTelefono { get; set; }
        public DateTime FechaCreacionUsuarioTelefono { get; set; }
        public DateTime? FechaModificacionUsuarioTelefono { get; set; }
        public DateTime? FechaEliminacionUsuarioTelefono { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
    }
}
