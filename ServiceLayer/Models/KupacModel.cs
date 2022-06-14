using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class KupacModel
    {
        private int id;
        private string jmbg;
        private string ime;
        private string prezime;

        public KupacModel() { }

        public KupacModel(string jmbg, string ime, string prezime)
        {
            this.Jmbg = jmbg;
            this.Ime = ime;
            this.Prezime = prezime;
        }

        public KupacModel(int id, string jmbg, string ime, string prezime)
        {
            this.id = id;
            this.jmbg = jmbg;
            this.ime = ime;
            this.prezime = prezime;
        }

        public int Id { get => id; set => id = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
    }
}
