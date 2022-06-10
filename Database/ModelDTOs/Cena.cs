using System;
using System.Collections.Generic;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class Cena
    {
        public int SifraC { get; set; }
        public decimal? Iznos { get; set; }
        public DateTime DatPocetka { get; set; }
        public DateTime DatZavrsetka { get; set; }
        public int? SifraI { get; set; }

        public virtual Instrument SifraINavigation { get; set; }
    }
}
