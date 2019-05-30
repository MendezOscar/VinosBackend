using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Personalorden
    {
        public Personalorden()
        {
            Ordendeproducciondtl = new HashSet<Ordendeproducciondtl>();
        }

        public int Idpersonal { get; set; }
        public int? Idempleado { get; set; }

        public virtual Empleado IdempleadoNavigation { get; set; }
        public virtual ICollection<Ordendeproducciondtl> Ordendeproducciondtl { get; set; }
    }
}
