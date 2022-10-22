using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Facturas = new HashSet<Factura>();
            UsuarioDetalles = new HashSet<UsuarioDetalle>();
            UsuarioDireccions = new HashSet<UsuarioDireccion>();
            UsuarioTelefonos = new HashSet<UsuarioTelefono>();
        }

        public int IdUsuario { get; set; }
        public string MailUsuario { get; set; } = null!;
        public string PasswordUsuario { get; set; } = null!;
        public string RolUsuario { get; set; } = null!;
        public bool ActivoUsuario { get; set; }
        public DateTime FechaCreacionUsuario { get; set; }
        public DateTime? FechaModificacionUsuario { get; set; }
        public DateTime? FechaEliminacionUsuario { get; set; }

        [JsonIgnore]
        public virtual ICollection<Factura> Facturas { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsuarioDetalle> UsuarioDetalles { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsuarioDireccion> UsuarioDireccions { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsuarioTelefono> UsuarioTelefonos { get; set; }
    }
}
