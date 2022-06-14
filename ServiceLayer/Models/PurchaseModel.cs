using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class PurchaseModel
    {
        private int idKupca;
        private string imeKupca;
        private string prezimeKupca;
        private string jmbgKupca;

        private int idRadnika;
        private string imeRadnika;
        private string prezimeRadnika;

        private int idInstrumenta;
        private string nazivInstrumenta;
        private double cena;

        public PurchaseModel()
        {
        }

        public PurchaseModel(int idKupca, string imeKupca, string prezimeKupca, string jmbgKupca, int idRadnika, string imeRadnika, string prezimeRadnika, int idInstrumenta, string nazivInstrumenta, double cena)
        {
            this.IdKupca = idKupca;
            this.ImeKupca = imeKupca;
            this.PrezimeKupca = prezimeKupca;
            this.JmbgKupca = jmbgKupca;
            this.IdRadnika = idRadnika;
            this.ImeRadnika = imeRadnika;
            this.PrezimeRadnika = prezimeRadnika;
            this.IdInstrumenta = idInstrumenta;
            this.NazivInstrumenta = nazivInstrumenta;
            this.Cena = cena;
        }

        public int IdKupca { get => idKupca; set => idKupca = value; }
        public string ImeKupca { get => imeKupca; set => imeKupca = value; }
        public string PrezimeKupca { get => prezimeKupca; set => prezimeKupca = value; }
        public string JmbgKupca { get => jmbgKupca; set => jmbgKupca = value; }
        public int IdRadnika { get => idRadnika; set => idRadnika = value; }
        public string ImeRadnika { get => imeRadnika; set => imeRadnika = value; }
        public string PrezimeRadnika { get => prezimeRadnika; set => prezimeRadnika = value; }
        public int IdInstrumenta { get => idInstrumenta; set => idInstrumenta = value; }
        public string NazivInstrumenta { get => nazivInstrumenta; set => nazivInstrumenta = value; }
        public double Cena { get => cena; set => cena = value; }
    }
}
