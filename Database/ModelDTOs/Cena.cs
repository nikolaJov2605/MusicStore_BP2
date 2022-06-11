using System;
using System.Collections.Generic;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class Cena
    {
        public int SifraC { get; set; }
        public decimal? Iznos { get; set; }
        public string DatPocetka { get; set; }
        public string DatZavrsetka { get; set; }
        public int? SifraI { get; set; }

        public virtual Instrument SifraINavigation { get; set; }
    }
}
