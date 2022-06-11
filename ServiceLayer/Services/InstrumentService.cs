using Database.CRUD;
using Database.ModelDTOs;
using Database.Repository;
using Newtonsoft.Json;
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
            Instrument dbInstrument = new Instrument();

            if (instrument.GetType().Name == "GitaraModel")
            {
                GitaraModel gitara = (GitaraModel)instrument;
                dbInstrument.Naziv = gitara.Naziv;
                dbInstrument.Proizvodjac = gitara.Proizvodjac;
                dbInstrument.Opis = gitara.Opis;
                dbInstrument.Stat = true;
                dbInstrument.TipInstrumenta = gitara.TipInstrumenta;
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
                dbInstrument.Naziv = klavir.Naziv;
                dbInstrument.Proizvodjac = klavir.Proizvodjac;
                dbInstrument.Opis = klavir.Opis;
                dbInstrument.Stat = true;
                dbInstrument.TipInstrumenta = klavir.TipInstrumenta;
                dbInstrument.DatKup = null;

                dbInstrument.DubinaKlavira = klavir.Dubina;
                dbInstrument.SirinaKlavira = klavir.Sirina;
                dbInstrument.VisinaKlavira = klavir.Visina;
                dbInstrument.MasaKlavira = klavir.Masa;
                dbInstrument.BrTonovaKlavira = klavir.BrojTonova;
                dbInstrument.VrsKlavira = klavir.VrstaKlavira;

                instrumentCRUD.CreateInstrument(dbInstrument);
            }
            else if (instrument.GetType().Name == "KlavijaturaModel")
            {
                KlavijaturaModel klavijatura = (KlavijaturaModel)instrument;
                dbInstrument.Naziv = klavijatura.Naziv;
                dbInstrument.Proizvodjac = klavijatura.Proizvodjac;
                dbInstrument.Opis = klavijatura.Opis;
                dbInstrument.Stat = true;
                dbInstrument.TipInstrumenta = klavijatura.TipInstrumenta;
                dbInstrument.DatKup = null;

                dbInstrument.DubinaKlavijature = klavijatura.Dubina;
                dbInstrument.SirinaKlavijature = klavijatura.Sirina;
                dbInstrument.DuzinaKlavijature = klavijatura.Duzina;
                dbInstrument.MasaKlavijature = klavijatura.Masa;
                dbInstrument.BrTonovaKlavijature = klavijatura.BrojTonova;
                dbInstrument.VrsKlavijature = klavijatura.VrstaKlavira;

                instrumentCRUD.CreateInstrument(dbInstrument);
            }
            else if (instrument.GetType().Name == "BubanjModel")
            {
                BubanjModel bubanj = (BubanjModel)instrument;
                dbInstrument.Naziv = bubanj.Naziv;
                dbInstrument.Proizvodjac = bubanj.Proizvodjac;
                dbInstrument.Opis = bubanj.Opis;
                dbInstrument.Stat = true;
                dbInstrument.TipInstrumenta = bubanj.TipInstrumenta;
                dbInstrument.DatKup = null;

                dbInstrument.VrsBubnja = bubanj.VrstaBubnja;

                instrumentCRUD.CreateInstrument(dbInstrument);
            }
            else
            {
                return;
            }

            CenaCRUD cenaCRUD = new CenaCRUD();
            Cena dbCena = new Cena();
            dbCena.DatPocetka = DateTime.Now.ToString().Substring(0, 9);
            dbCena.DatZavrsetka = DateTime.Now.AddDays(7).ToString().Substring(0, 9);
            dbCena.Iznos = (decimal?)instrument.Cena;
            cenaCRUD.CreateCena(dbCena, dbInstrument);

        }

        public void DeleteInstrument(InstrumentModel instrument)
        {
            throw new NotImplementedException();
        }

        public List<InstrumentModel> GetAllInstruments()
        {
            InstrumentRepository repository = new InstrumentRepository();
            List<InstrumentModel> retList = new List<InstrumentModel>();
            List<Instrument> dtoList = repository.GetAllInstruments();
            foreach(var instrument in dtoList)
            {
                if (instrument.Stat == false)
                    continue;
                InstrumentModel tempModel = new InstrumentModel();
                tempModel.Naziv = instrument.Naziv;
                tempModel.Proizvodjac = instrument.Proizvodjac;
                tempModel.Opis = instrument.Opis;
                tempModel.TipInstrumenta = instrument.TipInstrumenta;
                if (instrument.Cene.Count != 0)
                    tempModel.Cena = (double)instrument.Cene.OrderBy(x => x.DatPocetka).Last().Iznos;
                
                retList.Add(tempModel);
            }


            return retList;
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
