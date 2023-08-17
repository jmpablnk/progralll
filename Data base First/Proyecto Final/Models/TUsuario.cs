using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models
{
    public partial class TUsuario
    {
        public TUsuario()
        {
            TTareas = new HashSet<TTarea>();
        }

        public int IdUsuario { get; set; }
        public string Usuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public int IdRol { get; set; }

        public virtual TRole IdRolNavigation { get; set; } = null!;
        public virtual ICollection<TTarea> TTareas { get; set; }
    }
}
