using System;
using System.Collections.Generic;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class Plata
    {
        public Plata()
        {
            Radniks = new HashSet<Radnik>();
        }

        public int SifraP { get; set; }
        public decimal? Iznos { get; set; }

        public virtual ICollection<Radnik> Radniks { get; set; }
    }
}
