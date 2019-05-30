using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Inventariodtl
    {
        public int Idinventariodetalle { get; set; }
        public string Item { get; set; }
        public int? Existencia { get; set; }
        public int? Idinventario { get; set; }

        public virtual Inventariohdr IdinventarioNavigation { get; set; }
    }
}
