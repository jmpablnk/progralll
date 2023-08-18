using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models
{
    public partial class TProyecto
    {
        public TProyecto()
        {
            TTareas = new HashSet<TTarea>();
        }

        public int IdProyecto { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual ICollection<TTarea> TTareas { get; set; }
    }
}
