using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Visitahdr
    {
        public int Idvisita { get; set; }
        public int? Numero { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Idproveedor { get; set; }
        public int? Idfinca { get; set; }
        public string Titulo { get; set; }

        public virtual Finca IdfincaNavigation { get; set; }
    }
}
