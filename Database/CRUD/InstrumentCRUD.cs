using Database.ModelDTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CRUD
{
    public class InstrumentCRUD
    {
        #region
        public void CreateInstrument(Instrument instrument)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();

            try
            {
                dBContext.Instrumenti.Add(instrument);
                dBContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region ReadOperations
        public Instrument GetInstrument(int instrumentId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Instrument retVal = new Instrument();
            try
            {
                var query = dBContext.Instrumenti.Where(x => x.SifraI == instrumentId).FirstOrDefault();
                if (query != null)
                {
                    var queryCena = dBContext.Cene.Where(x => x.SifraI == query.SifraI);
                    query.Cene = queryCena.ToList();
                    return query;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public Instrument GetInstrument(Instrument instrument)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Instrument retVal = new Instrument();
            try
            {
                var query = dBContext.Instrumenti.Where(x => x == instrument).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }

        public List<Instrument> GetAllInstruments()
        {
            List<Instrument> retList = new List<Instrument>();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                retList = dBContext.Instrumenti.ToList();

                foreach (var item in retList)
                {
                    var queryCena = dBContext.Cene.Where(x => x.SifraI == item.SifraI);
                    item.Cene = queryCena.ToList();
                }

            }
            return retList;
        }

        public List<Instrument> GetPurchasedInstruments()
        {
            List<Instrument> retList = new List<Instrument>();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                retList = dBContext.Instrumenti.Where(x => x.Stat == false).ToList();

                foreach (var item in retList)
                {
                    var queryCena = dBContext.Cene.Where(x => x.SifraI == item.SifraI);
                    item.Cene = queryCena.ToList();

                    var queryWorker = dBContext.Radnici.FirstOrDefault(x => x.IdR == item.IdR);
                    item.IdRNavigation = queryWorker;

                    var queryBuyer = dBContext.Kupci.FirstOrDefault(x => x.IdK == item.IdK);
                    item.IdKNavigation = queryBuyer;
                }

            }
            return retList;
        }

        public Instrument GetPurchasedInstrument(int instrumentId)
        {
            Instrument retVal = new Instrument();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                retVal = dBContext.Instrumenti.FirstOrDefault(x => x.Stat == false && x.SifraI == instrumentId);

                if (retVal == null)
                    return null;

                var queryCena = dBContext.Cene.Where(x => x.SifraI == retVal.SifraI);
                retVal.Cene = queryCena.ToList();

                var queryWorker = dBContext.Radnici.FirstOrDefault(x => x.IdR == retVal.IdR);
                retVal.IdRNavigation = queryWorker;

                var queryBuyer = dBContext.Kupci.FirstOrDefault(x => x.IdK == retVal.IdK);
                retVal.IdKNavigation = queryBuyer;

            }
            return retVal;
        }

        public List<Instrument> FilterInstruments(string criteria)
        {
            List<Instrument> instruments = new List<Instrument>();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                switch(criteria)
                {
                    case "Svi instrumenti":
                        instruments = dBContext.Instrumenti.ToList();
                        break;
                    case "Gitare":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Gitara").ToList();
                        break;
                    case "\tKlasične gitare":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Gitara" && x.VrsGitare == "Klasicna").ToList();
                        break;
                    case "\tAkustične gitare":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Gitara" && x.VrsGitare == "Akusticna").ToList();
                        break;
                    case "\tElektrične gitare":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Gitara" && x.VrsGitare == "Elektricna").ToList();
                        break;
                    case "\tBas gitare":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Gitara" && x.VrsGitare == "Bas").ToList();
                        break;
                    case "Klaviri":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Klavir").ToList();
                        break;
                    case "\tElektrični klaviri":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Klavir" && x.VrsKlavira == "Elektricni").ToList();
                        break;
                    case "\tPianino":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Klavir" && x.VrsKlavira == "Pianino").ToList();
                        break;
                    case "\tKoncertni klaviri":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Klavir" && x.VrsKlavira == "Koncertni").ToList();
                        break;
                    case "Klavijature":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Klavijatura").ToList();
                        break;
                    case "\tŠkolske klavijature":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Klavijatura" && x.VrsKlavijature == "Školska").ToList();
                        break;
                    case "\tAranžerske klavijature":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Klavijatura" && x.VrsKlavijature == "Aranžerska").ToList();
                        break;
                    case "Bubnjevi":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Bubanj").ToList();
                        break;
                    case "\tAkustični bubnjevi":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Bubanj" && x.VrsBubnja == "Akusticni").ToList();
                        break;
                    case "\tElektronski bubnjevi":
                        instruments = dBContext.Instrumenti.Where(x => x.TipInstrumenta == "Bubanj" && x.VrsBubnja == "Elektronski").ToList();
                        break;
                    default:
                        instruments = dBContext.Instrumenti.ToList();
                        break;
                }
                foreach (var item in instruments)
                {
                    var queryCena = dBContext.Cene.Where(x => x.SifraI == item.SifraI);
                    item.Cene = queryCena.ToList();
                }
            }
            return instruments;
        }

        #endregion

        #region UpdateOperations
        public void UpdateInstrument(Instrument instrument)
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                var query = dBContext.Instrumenti.Where(x => x.SifraI == instrument.SifraI).FirstOrDefault<Instrument>();
                if (query == null)
                    return;
                query.Naziv = instrument.Naziv;
                query.Proizvodjac = instrument.Proizvodjac;
                query.Opis = instrument.Opis;
                query.Stat = instrument.Stat;
                query.TipInstrumenta = instrument.TipInstrumenta;
                query.IdK = instrument.IdK;
                query.IdR = instrument.IdR;
                query.DatKup = instrument.DatKup;
                query.MatGlaveGitare = instrument.MatGlaveGitare;
                query.MatTrupaGitare = instrument.MatTrupaGitare;
                query.MatVrataGitare = instrument.MatVrataGitare;
                query.BrPragovaGitare = instrument.BrPragovaGitare;
                query.VrsGitare = instrument.VrsGitare;
                query.SirinaKlavira = instrument.SirinaKlavira;
                query.VisinaKlavira = instrument.VisinaKlavira;
                query.DubinaKlavira = instrument.DubinaKlavira;
                query.MasaKlavira = instrument.MasaKlavira;
                query.BrTonovaKlavira = instrument.BrTonovaKlavira;
                query.VrsKlavira = instrument.VrsKlavira;
                query.DuzinaKlavijature = instrument.DuzinaKlavijature;
                query.SirinaKlavijature = instrument.SirinaKlavijature;
                query.DubinaKlavijature = instrument.DubinaKlavijature;
                query.MasaKlavijature = instrument.MasaKlavijature;
                query.BrTonovaKlavijature = instrument.BrTonovaKlavijature;
                query.VrsKlavijature = instrument.VrsKlavijature;
                query.VrsBubnja = instrument.VrsBubnja;
                query.IdKNavigation = instrument.IdKNavigation;
                query.IdRNavigation = instrument.IdRNavigation;

                dBContext.SaveChanges();
            }
        }
        #endregion

        #region DeleteCommands
        public bool DeleteInstrument(Instrument instrument)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            try
            {
                var query = dBContext.Instrumenti.Where(x => x == instrument).FirstOrDefault();
                if (query != null)
                {
                    dBContext.Instrumenti.Remove(instrument);
                    dBContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInstrument(int instrumentId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            List<Testiranje> testList;
            try
            {
                var query = dBContext.Instrumenti.Where(x => x.SifraI == instrumentId).FirstOrDefault();
                if (query != null)
                {
                    testList = dBContext.Testiranja.Where(x => x.SifraI == query.SifraI).ToList();
                    if(testList != null)
                    {
                        foreach(var test in testList)
                            dBContext.Testiranja.Remove(test);
                    }
                    List<Cena> prices = dBContext.Cene.Where(x => x.SifraI == instrumentId).ToList();
                    foreach(var price in prices)
                    {
                        dBContext.Cene.Remove(price);
                    }
                    dBContext.Instrumenti.Remove(query);
                    dBContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

    }
}
