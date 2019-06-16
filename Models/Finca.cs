using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Finca
    {
        public Finca()
        {
            Visitahdr = new HashSet<Visitahdr>();
        }

        public int Idfinca { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Dueno { get; set; }
        public string Contacto { get; set; }
        public int? Idproducto { get; set; }

        public virtual Producto IdproductoNavigation { get; set; }
        public virtual ICollection<Visitahdr> Visitahdr { get; set; }
    }
}
