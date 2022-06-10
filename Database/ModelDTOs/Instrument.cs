using System;
using System.Collections.Generic;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class Instrument
    {
        public Instrument()
        {
            Cene = new HashSet<Cena>();
            Testiranja = new HashSet<Testiranje>();
        }

        public int SifraI { get; set; }
        public string Naziv { get; set; }
        public string Proizvodjac { get; set; }
        public string Opis { get; set; }
        public bool? Stat { get; set; }
        public string TipInstrumenta { get; set; }
        public int? IdK { get; set; }
        public int? IdR { get; set; }
        public string DatKup { get; set; }
        public string MatGlaveGitare { get; set; }
        public string MatTrupaGitare { get; set; }
        public string MatVrataGitare { get; set; }
        public int? BrPragovaGitare { get; set; }
        public string VrsGitare { get; set; }
        public int? SirinaKlavira { get; set; }
        public int? VisinaKlavira { get; set; }
        public int? DubinaKlavira { get; set; }
        public int? MasaKlavira { get; set; }
        public int? BrTonovaKlavira { get; set; }
        public string VrsKlavira { get; set; }
        public int? DuzinaKlavijature { get; set; }
        public int? SirinaKlavijature { get; set; }
        public int? DubinaKlavijature { get; set; }
        public int? MasaKlavijature { get; set; }
        public int? BrTonovaKlavijature { get; set; }
        public string VrsKlavijature { get; set; }
        public string VrsBubnja { get; set; }

        public virtual Kupac IdKNavigation { get; set; }
        public virtual Radnik IdRNavigation { get; set; }
        public virtual ICollection<Cena> Cene { get; set; }
        public virtual ICollection<Testiranje> Testiranja { get; set; }
    }
}
