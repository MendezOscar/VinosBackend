using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Visita
    {
        public Visita()
        {
            Actividadvisita = new HashSet<Actividadvisita>();
            Personalvisita = new HashSet<Personalvisita>();
        }

        public int Idvisita { get; set; }
        public int? Numero { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Idfinca { get; set; }
        public string Titulo { get; set; }

        public virtual Finca IdfincaNavigation { get; set; }
        public virtual ICollection<Actividadvisita> Actividadvisita { get; set; }
        public virtual ICollection<Personalvisita> Personalvisita { get; set; }
    }
}
