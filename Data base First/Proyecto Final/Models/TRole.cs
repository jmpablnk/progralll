using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models
{
    public partial class TRole
    {
        public TRole()
        {
            TUsuarios = new HashSet<TUsuario>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; } = null!;

        public virtual ICollection<TUsuario> TUsuarios { get; set; }
    }
}
