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
            List<Instrument> retList = new List<Instrument>();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                retList = dBContext.Instrumenti.ToList();

                foreach(var item in retList)
                {
                    var queryCena = dBContext.Cene.Where(x => x.SifraI == item.SifraI);
                    item.Cene = queryCena.ToList();
                }

                return retList;
            }
        }
    }
}
