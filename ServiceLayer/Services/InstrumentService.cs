using Database.CRUD;
using Database.ModelDTOs;
using ServiceLayer.Interfaces;
using ServiceLayer.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class InstrumentService : IInstrument
    {
        public void AddInstrument(InstrumentModel instrument)
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            if (instrument.GetType().Name == "GitaraModel")
            {
                GitaraModel gitara = (GitaraModel)instrument;
                Instrument dbInstrument = new Instrument();
                dbInstrument.Naziv = gitara.Naziv;
                dbInstrument.Proizvodjac = gitara.Proizvodjac;
                dbInstrument.Opis = gitara.Opis;
                dbInstrument.Stat = false;
                dbInstrument.TipInstrumenta = gitara.TipInstrumenta;
                dbInstrument.IdK = null;
                dbInstrument.IdR = null;
                dbInstrument.DatKup = null;

                dbInstrument.MatGlaveGitare = gitara.MaterijalGlave;
                dbInstrument.MatTrupaGitare = gitara.MaterijalTrupa;
                dbInstrument.MatVrataGitare = gitara.MaterijalVrata;
                dbInstrument.BrPragovaGitare = gitara.BrojPragova;
                dbInstrument.VrsGitare = gitara.VrstaGitare;

                instrumentCRUD.CreateInstrument(dbInstrument);
            }
            else if (instrument.GetType().Name == "KlavirModel")
            {
                KlavirModel klavir = (KlavirModel)instrument;
            }
            else if (instrument.GetType().Name == "KlavijaturaModel")
            {
                KlavijaturaModel klavijatura = (KlavijaturaModel)instrument;
            }
            else if (instrument.GetType().Name == "BubanjModel")
            {
                BubanjModel bubanj = (BubanjModel)instrument;
            }
            else
            {
                return;
            }
        }

        public void DeleteInstrument(InstrumentModel instrument)
        {
            throw new NotImplementedException();
        }

        public InstrumentModel GetInstrument(InstrumentModel instrument)
        {
            throw new NotImplementedException();
        }

        public void UpdateInstrument(InstrumentModel instrument)
        {
            throw new NotImplementedException();
        }
    }
}
