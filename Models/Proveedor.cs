using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Visita = new HashSet<Visita>();
        }

        public int Idproveedor { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }

        public virtual ICollection<Visita> Visita { get; set; }
    }
}
