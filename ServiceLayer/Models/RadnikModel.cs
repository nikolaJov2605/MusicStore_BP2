using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class RadnikModel
    {
        private int id;
        private string brlk;
        private string ime;
        private string prezime;
        private string pozicija;
        private double plata;
        private int radniStaz;

        public RadnikModel()
        {
        }

        public RadnikModel(string brlk, string ime, string prezime, string pozicija, double plata, int radniStaz)
        {
            this.Brlk = brlk;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Pozicija = pozicija;
            this.Plata = plata;
            this.RadniStaz = radniStaz;
        }

        public int Id { get => id; set => id = value; }
        public string Brlk { get => brlk; set => brlk = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Pozicija { get => pozicija; set => pozicija = value; }
        public double Plata { get => plata; set => plata = value; }
        public int RadniStaz { get => radniStaz; set => radniStaz = value; }
    }
}
