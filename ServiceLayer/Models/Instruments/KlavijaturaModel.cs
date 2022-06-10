using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models.Instruments
{
    public class KlavijaturaModel : InstrumentModel
    {
        private int sirina;
        private int duzina;
        private int dubina;
        private int masa;
        private int brojTonova;
        private string vrstaKlavira;

        public KlavijaturaModel(string naziv, string proizvodjac, string opis, string tipInstrumenta, double cena, int sirina,
            int duzina, int dubina, int masa, int brojTonova, string vrstaKlavira) : base(naziv, proizvodjac, opis, tipInstrumenta, cena)
        {
            this.Sirina = sirina;
            this.Duzina = duzina;
            this.Dubina = dubina;
            this.Masa = masa;
            this.BrojTonova = brojTonova;
            this.VrstaKlavira = vrstaKlavira;
        }

        public int Sirina { get => sirina; set => sirina = value; }
        public int Duzina { get => duzina; set => duzina = value; }
        public int Dubina { get => dubina; set => dubina = value; }
        public int Masa { get => masa; set => masa = value; }
        public int BrojTonova { get => brojTonova; set => brojTonova = value; }
        public string VrstaKlavira { get => vrstaKlavira; set => vrstaKlavira = value; }
    }
}
