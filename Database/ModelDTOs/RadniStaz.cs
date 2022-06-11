using System;
using System.Collections.Generic;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class RadniStaz
    {
        public RadniStaz()
        {
            Radnici = new HashSet<Radnik>();
        }

        public int SifraS { get; set; }
        public int? BrGod { get; set; }

        public virtual ICollection<Radnik> Radnici { get; set; }
    }
}
