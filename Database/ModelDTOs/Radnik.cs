using System;
using System.Collections.Generic;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class Radnik
    {
        public Radnik()
        {
            Instruments = new HashSet<Instrument>();
            Testiranjes = new HashSet<Testiranje>();
        }

        public int IdR { get; set; }
        public string BrLk { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pozicija { get; set; }
        public int SifraP { get; set; }
        public int SifraS { get; set; }

        public virtual Plata SifraPNavigation { get; set; }
        public virtual RadniStaz SifraSNavigation { get; set; }
        public virtual ICollection<Instrument> Instruments { get; set; }
        public virtual ICollection<Testiranje> Testiranjes { get; set; }
    }
}
