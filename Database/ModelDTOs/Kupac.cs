using System;
using System.Collections.Generic;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class Kupac
    {
        public Kupac()
        {
            Instrumenti = new HashSet<Instrument>();
            Testiranja = new HashSet<Testiranje>();
        }

        public int IdK { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public virtual ICollection<Instrument> Instrumenti { get; set; }
        public virtual ICollection<Testiranje> Testiranja { get; set; }
    }
}
