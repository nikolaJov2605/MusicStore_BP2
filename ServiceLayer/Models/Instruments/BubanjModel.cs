using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models.Instruments
{
    public class BubanjModel : InstrumentModel
    {
        private string vrstaBubnja;

        public BubanjModel() { }

        public BubanjModel(string naziv, string proizvodjac, string opis, string tipInstrumenta, double cena, string vrstaBubnja) : base(naziv, proizvodjac, opis, tipInstrumenta, cena)
        {
            this.VrstaBubnja = vrstaBubnja;
        }

        public string VrstaBubnja { get => vrstaBubnja; set => vrstaBubnja = value; }
    }
}
