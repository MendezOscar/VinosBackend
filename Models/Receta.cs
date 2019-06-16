using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Receta
    {
        public int Idreceta { get; set; }
        public int? Duracion { get; set; }
        public int? Idproducto { get; set; }

        public virtual Producto IdproductoNavigation { get; set; }
    }
}
