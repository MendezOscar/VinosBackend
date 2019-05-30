using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Recetahdr
    {
        public Recetahdr()
        {
            Ordendeproducciondtl = new HashSet<Ordendeproducciondtl>();
            Recetadtl = new HashSet<Recetadtl>();
        }

        public int Idreceta { get; set; }
        public int? Duracion { get; set; }
        public int? Idproducto { get; set; }

        public virtual Producto IdproductoNavigation { get; set; }
        public virtual ICollection<Ordendeproducciondtl> Ordendeproducciondtl { get; set; }
        public virtual ICollection<Recetadtl> Recetadtl { get; set; }
    }
}
