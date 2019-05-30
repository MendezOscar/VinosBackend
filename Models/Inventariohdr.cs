using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Inventariohdr
    {
        public Inventariohdr()
        {
            Inventariodtl = new HashSet<Inventariodtl>();
        }

        public int Idinventario { get; set; }
        public int? Tipo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Inventariodtl> Inventariodtl { get; set; }
    }
}
