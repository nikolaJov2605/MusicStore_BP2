using Database.ModelDTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CRUD
{
    public class RadnikCRUD
    {
        #region CreateOperations
        public void CreateRadnik(Radnik radnik, Plata plata, RadniStaz radniStaz)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();

            try
            {
                var plataQuery = dBContext.Plate.FirstOrDefault(x => x == plata);
                radnik.SifraPNavigation = plataQuery;
                var stazQuery = dBContext.RadniStaz.FirstOrDefault(x => x == radniStaz);
                radnik.SifraSNavigation = stazQuery;
                dBContext.Radnici.Add(radnik);
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
        public Radnik GetRadnik(int radnikId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Radnik retVal = new Radnik();
            try
            {
                var query = dBContext.Radnici.Where(x => x.IdR == radnikId).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }

        public Radnik GetRadnik(Radnik radnik)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Radnik retVal = new Radnik();
            try
            {
                var query = dBContext.Radnici.Where(x => x == radnik).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }

       

        public List<Radnik> GetAllRadnici()
        {
            List<Radnik> retList = new List<Radnik>();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                retList = dBContext.Radnici.ToList();

                /*foreach (var radnik in retList)
                {
                    var plata = dBContext.Plate.FirstOrDefault(x => x.Radnici.Contains(radnik));
                    var staz = dBContext.RadniStaz.FirstOrDefault(x => x.Radnici.Contains(radnik));

                    radnik.
                }*/
            }
            return retList;
        }

        public List<Radnik> GetAllSellers()
        {
            List<Radnik> retList = new List<Radnik>();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                retList = dBContext.Radnici.Where(x => x.Pozicija == "Prodavac" || x.Pozicija == "Full").ToList();
            }
            return retList;
        }

        public List<Radnik> GetAllTechs()
        {
            List<Radnik> retList = new List<Radnik>();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                retList = dBContext.Radnici.Where(x => x.Pozicija == "Tehničar" || x.Pozicija == "Full").ToList();
            }
            return retList;
        }

        #endregion

        #region UpdateOperations
        public void UpdateRadnik(Radnik radnik)
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                var query = dBContext.Radnici.Where(x => x.IdR == radnik.IdR).FirstOrDefault();

                query.BrLk = radnik.BrLk;
                query.Ime = radnik.Ime;
                query.Prezime = radnik.Prezime;
                query.Pozicija = radnik.Pozicija;
                query.SifraP = radnik.SifraP;
                query.SifraS = radnik.SifraS;

                dBContext.SaveChanges();
            }
        }
        #endregion

        #region DeleteCommands
        public bool DeleteRadnik(Radnik radnik)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            try
            {
                var query = dBContext.Radnici.Where(x => x == radnik).FirstOrDefault();
                if (query != null)
                {
                    dBContext.Radnici.Remove(radnik);
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

        public bool DeleteRadnik(int radnikId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            try
            {
                var query = dBContext.Radnici.Where(x => x.IdR == radnikId).FirstOrDefault();
                if (query != null)
                {
                    dBContext.Radnici.Remove(query);

                    var salary = dBContext.Plate.FirstOrDefault(x => x.SifraP == query.SifraP);
                    dBContext.Plate.Remove(salary);
                    var years = dBContext.RadniStaz.FirstOrDefault(x => x.SifraS == query.SifraS);
                    dBContext.RadniStaz.Remove(years);

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
