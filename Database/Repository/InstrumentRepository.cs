using Database.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class InstrumentRepository
    {
        public List<Instrument> GetAllInstruments()
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                return dBContext.Instrumenti.ToList();
            }
        }
    }
}
