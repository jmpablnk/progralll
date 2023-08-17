using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models
{
    public partial class TTarea
    {
        public int IdTarea { get; set; }
        public int IdProyecto { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public byte NivelDificultad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdUsuario { get; set; }

        public virtual TProyecto IdProyectoNavigation { get; set; } = null!;
        public virtual TUsuario IdUsuarioNavigation { get; set; } = null!;
    }
}
