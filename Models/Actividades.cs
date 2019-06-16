using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Actividades
    {
        public Actividades()
        {
            Actividadvisita = new HashSet<Actividadvisita>();
        }

        public int Idactividad { get; set; }
        public string Descripcion { get; set; }
        public int? Numerodevisita { get; set; }

        public virtual ICollection<Actividadvisita> Actividadvisita { get; set; }
    }
}
