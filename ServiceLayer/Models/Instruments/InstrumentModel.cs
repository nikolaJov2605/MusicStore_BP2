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

        /*private string matGlaveGitare;
        private string matTrupaGitare;
        private string matVrataGitare;
        private int brPragovaGitare;
        private string vrsGitare;
        private int sirinaKlavira;
        private int visinaKlavira;
        private int dubinaKlavira;
        private int masaKlavira;
        private int brTonovaKlavira;
        private string vrsKlavira;
        private int duzinaKlavijature;
        private int sirinaKlavijature;
        private int dubinaKlavijature;
        private int masaKlavijature;
        private int brTonovaKlavijature;
        private string vrsKlavijature;
        private string vrsBubnja;*/



        public InstrumentModel() { }

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
