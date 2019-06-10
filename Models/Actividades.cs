using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Actividades
    {
        public Actividades()
        {
            Planactividades = new HashSet<Planactividades>();
            Visita = new HashSet<Visita>();
        }

        public int Idactividad { get; set; }
        public string Descripcion { get; set; }
        public int? Numerodevisita { get; set; }

        public virtual ICollection<Planactividades> Planactividades { get; set; }
        public virtual ICollection<Visita> Visita { get; set; }
    }
}
