using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models.Instruments
{
    public class InstrumentModel
    {
        private string naziv;
        private string proizvodjac;
        private string opis;
        private string tipInstrumenta;
        private double cena;


        public InstrumentModel(string naziv, string proizvodjac, string opis, string tipInstrumenta, double cena)
        {
            this.Naziv = naziv;
            this.Proizvodjac = proizvodjac;
            this.Opis = opis;
            this.TipInstrumenta = tipInstrumenta;
            this.Cena = cena;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public string Proizvodjac { get => proizvodjac; set => proizvodjac = value; }
        public string Opis { get => opis; set => opis = value; }
        public string TipInstrumenta { get => tipInstrumenta; set => tipInstrumenta = value; }
        public double Cena { get => cena; set => cena = value; }
    }
}
