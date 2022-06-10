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
                    return query;
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

        #endregion

        #region UpdateOperations
        public void UpdateInstrument(Instrument instrument)
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                var query = dBContext.Instrumenti.Where(x => x.SifraI == instrument.SifraI).FirstOrDefault();

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
        #endregion

    }
}
