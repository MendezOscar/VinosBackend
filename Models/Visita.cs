using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Visita
    {
        public int Idvisita { get; set; }
        public int? Numero { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Idactividad { get; set; }
        public int? Idproveedor { get; set; }
        public int? Idfinca { get; set; }
        public string Titulo { get; set; }

        public virtual Actividades IdactividadNavigation { get; set; }
        public virtual Finca IdfincaNavigation { get; set; }
        public virtual Proveedor IdproveedorNavigation { get; set; }
    }
}
