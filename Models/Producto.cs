using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Finca = new HashSet<Finca>();
            Recetahdr = new HashSet<Recetahdr>();
        }

        public int Idproducto { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Finca> Finca { get; set; }
        public virtual ICollection<Recetahdr> Recetahdr { get; set; }
    }
}
