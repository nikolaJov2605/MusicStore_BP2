using Database.CRUD;
using Database.ModelDTOs;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
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
                dbInstrument.VrsKlavijature = klavijatura.VrstaKlavijature;

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
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            instrumentCRUD.DeleteInstrument(instrument.Id);
        }

        public List<InstrumentModel> FilterInstruments(string criteria)
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            List<InstrumentModel> retList = new List<InstrumentModel>();
            List<Instrument> dtoList = instrumentCRUD.FilterInstruments(criteria);
            foreach (var instrument in dtoList)
            {
                if (instrument.Stat == false)
                    continue;
                InstrumentModel tempModel = new InstrumentModel();
                tempModel.Naziv = instrument.Naziv;
                tempModel.Proizvodjac = instrument.Proizvodjac;
                tempModel.Opis = instrument.Opis;
                tempModel.TipInstrumenta = instrument.TipInstrumenta;
                tempModel.Id = instrument.SifraI;
                if (instrument.Cene.Count != 0)
                    tempModel.Cena = (double)instrument.Cene.FirstOrDefault(x => DateTime.Parse(x.DatPocetka) <= DateTime.Now && DateTime.Parse(x.DatZavrsetka) > DateTime.Now).Iznos;

                retList.Add(tempModel);
            }
            return retList;
        }

        public List<InstrumentModel> GetAllInstruments()
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            List<InstrumentModel> retList = new List<InstrumentModel>();
            List<Instrument> dtoList = instrumentCRUD.GetAllInstruments();
            foreach(var instrument in dtoList)
            {
                if (instrument.Stat == false)
                    continue;
                InstrumentModel tempModel = new InstrumentModel();
                tempModel.Naziv = instrument.Naziv;
                tempModel.Proizvodjac = instrument.Proizvodjac;
                tempModel.Opis = instrument.Opis;
                tempModel.TipInstrumenta = instrument.TipInstrumenta;
                tempModel.Id = instrument.SifraI;
                if (instrument.Cene.Count != 0)
                    tempModel.Cena = (double)instrument.Cene.FirstOrDefault(x => DateTime.Parse(x.DatPocetka) <= DateTime.Now && DateTime.Parse(x.DatZavrsetka) > DateTime.Now).Iznos;
                    //tempModel.Cena = (double)instrument.Cene.OrderBy(x => x.DatPocetka).Last().Iznos;
                
                retList.Add(tempModel);
            }


            return retList;
        }

        public InstrumentModel GetInstrument(InstrumentModel instrument)
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            InstrumentModel retInstrument = new InstrumentModel();

            Instrument dbInstrument = instrumentCRUD.GetInstrument(instrument.Id);
            double cena = (double)dbInstrument.Cene.OrderBy(x => x.DatPocetka).Last().Iznos;

            if (dbInstrument.TipInstrumenta == "Gitara")
            {
                InstrumentModel gitaraModel = new GitaraModel(dbInstrument.Naziv, dbInstrument.Proizvodjac, dbInstrument.Opis, dbInstrument.TipInstrumenta, cena, 
                    dbInstrument.MatGlaveGitare, dbInstrument.MatTrupaGitare, dbInstrument.MatVrataGitare, (int)dbInstrument.BrPragovaGitare, dbInstrument.VrsGitare);
                gitaraModel.Id = dbInstrument.SifraI;
                retInstrument = gitaraModel;
            }
            else if(dbInstrument.TipInstrumenta == "Klavir")
            {
                InstrumentModel klavirModel = new KlavirModel(dbInstrument.Naziv, dbInstrument.Proizvodjac, dbInstrument.Opis, dbInstrument.TipInstrumenta, cena,
                    (int)dbInstrument.SirinaKlavira, (int)dbInstrument.VisinaKlavira, (int)dbInstrument.DubinaKlavira, (int)dbInstrument.MasaKlavira, (int)dbInstrument.BrTonovaKlavira, dbInstrument.VrsKlavira);
                klavirModel.Id = dbInstrument.SifraI;
                retInstrument = klavirModel;
            }
            else if (dbInstrument.TipInstrumenta == "Klavir")
            {
                InstrumentModel klavijaturaModel = new KlavijaturaModel(dbInstrument.Naziv, dbInstrument.Proizvodjac, dbInstrument.Opis, dbInstrument.TipInstrumenta, cena,
                    (int)dbInstrument.SirinaKlavijature, (int)dbInstrument.DuzinaKlavijature, (int)dbInstrument.DubinaKlavijature, (int)dbInstrument.MasaKlavijature, (int)dbInstrument.BrTonovaKlavijature, dbInstrument.VrsKlavijature);
                klavijaturaModel.Id = dbInstrument.SifraI;
                retInstrument = klavijaturaModel;
            }
            else if (dbInstrument.TipInstrumenta == "Bubanj")
            {
                InstrumentModel bubanjModel = new BubanjModel(dbInstrument.Naziv, dbInstrument.Proizvodjac, dbInstrument.Opis, dbInstrument.TipInstrumenta, cena, dbInstrument.VrsBubnja);
                bubanjModel.Id = dbInstrument.SifraI;
                retInstrument = bubanjModel;
            }
            else
            {
                return null;
            }

            return retInstrument;

        }

        public List<CenaModel> GetPricesForInstrument(int instrumentId)
        {
            List<CenaModel> retList = new List<CenaModel>();
            CenaCRUD cenaCRUD = new CenaCRUD();

            List<Cena> list = cenaCRUD.GetPricesForInstrument(instrumentId);
            foreach(var cena in list)
            {
                retList.Add(new CenaModel(cena.SifraC, (double)cena.Iznos, cena.DatPocetka, cena.DatZavrsetka));
            }

            return retList;

        }

        public void UpdateInstrument(InstrumentModel instrument)
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            Instrument dbInstrument = new Instrument();

            if (instrument.GetType().Name == "GitaraModel")
            {
                GitaraModel gitara = (GitaraModel)instrument;
                dbInstrument.SifraI = gitara.Id;
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

                instrumentCRUD.UpdateInstrument(dbInstrument);
            }
            else if (instrument.GetType().Name == "KlavirModel")
            {
                KlavirModel klavir = (KlavirModel)instrument;
                dbInstrument.SifraI = klavir.Id;
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

                instrumentCRUD.UpdateInstrument(dbInstrument);
            }
            else if (instrument.GetType().Name == "KlavijaturaModel")
            {
                KlavijaturaModel klavijatura = (KlavijaturaModel)instrument;
                dbInstrument.SifraI = klavijatura.Id;
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
                dbInstrument.VrsKlavijature = klavijatura.VrstaKlavijature;

                instrumentCRUD.UpdateInstrument(dbInstrument);
            }
            else if (instrument.GetType().Name == "BubanjModel")
            {
                BubanjModel bubanj = (BubanjModel)instrument;
                dbInstrument.SifraI = bubanj.Id;
                dbInstrument.Naziv = bubanj.Naziv;
                dbInstrument.Proizvodjac = bubanj.Proizvodjac;
                dbInstrument.Opis = bubanj.Opis;
                dbInstrument.Stat = true;
                dbInstrument.TipInstrumenta = bubanj.TipInstrumenta;
                dbInstrument.DatKup = null;

                dbInstrument.VrsBubnja = bubanj.VrstaBubnja;

                instrumentCRUD.UpdateInstrument(dbInstrument);
            }
            else
            {
                return;
            }
        }
    }
}
