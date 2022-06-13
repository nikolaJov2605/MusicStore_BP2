using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class CenaModel
    {
        private int id;
        private double iznos;
        private string datumPocetka;
        private string datumZavrsetka;

        public CenaModel(double iznos, string datumPocetka, string datumZavrsetka)
        {
            this.Iznos = iznos;
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
        }

        public CenaModel(int id, double iznos, string datumPocetka, string datumZavrsetka)
        {
            this.Id = id;
            this.Iznos = iznos;
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
        }

        public int Id { get => id; set => id = value; }
        public double Iznos { get => iznos; set => iznos = value; }
        public string DatumPocetka { get => datumPocetka; set => datumPocetka = value; }
        public string DatumZavrsetka { get => datumZavrsetka; set => datumZavrsetka = value; }
    }
}
