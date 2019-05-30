using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
    }
}
