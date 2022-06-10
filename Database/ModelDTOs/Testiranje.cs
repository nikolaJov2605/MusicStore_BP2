using System;
using System.Collections.Generic;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class Testiranje
    {
        public int SifraI { get; set; }
        public int IdK { get; set; }
        public DateTime DatTest { get; set; }
        public int IdR { get; set; }

        public virtual Kupac IdKNavigation { get; set; }
        public virtual Radnik IdRNavigation { get; set; }
        public virtual Instrument SifraINavigation { get; set; }
    }
}
