using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Actividades
    {
        public int Idactividad { get; set; }
        public string Descripcion { get; set; }
        public int? Numerodevisita { get; set; }
    }
}
