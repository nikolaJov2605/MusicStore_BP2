using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models.Instruments
{
    public class GitaraModel : InstrumentModel
    {
        private string materijalGlave;
        private string materijalTrupa;
        private string materijalVrata;
        private int brojPragova;
        private string vrstaGitare;
        public GitaraModel(string naziv, string proizvodjac, string opis, string tipInstrumenta, double cena, string materijalGlave,
            string materijalTrupa, string materijalVrata, int brojPragova, string vrstaGitare) : base(naziv, proizvodjac, opis, tipInstrumenta, cena)
        {
            this.MaterijalGlave = materijalGlave;
            this.MaterijalTrupa = materijalTrupa;
            this.MaterijalVrata = materijalVrata;
            this.BrojPragova = brojPragova;
            this.VrstaGitare = vrstaGitare;
        }

        public string MaterijalGlave { get => materijalGlave; set => materijalGlave = value; }
        public string MaterijalTrupa { get => materijalTrupa; set => materijalTrupa = value; }
        public string MaterijalVrata { get => materijalVrata; set => materijalVrata = value; }
        public int BrojPragova { get => brojPragova; set => brojPragova = value; }
        public string VrstaGitare { get => vrstaGitare; set => vrstaGitare = value; }
    }
}
