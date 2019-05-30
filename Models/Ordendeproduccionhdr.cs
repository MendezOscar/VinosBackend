using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Ordendeproduccionhdr
    {
        public Ordendeproduccionhdr()
        {
            Ordendeproducciondtl = new HashSet<Ordendeproducciondtl>();
        }

        public int Idorden { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Ordendeproducciondtl> Ordendeproducciondtl { get; set; }
    }
}
