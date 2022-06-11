using Database.ModelDTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CRUD
{
    public class KupacCRUD
    {
        #region CreateOperations
        public void CreateKupac(Kupac kupac)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();

            try
            {
                dBContext.Kupci.Add(kupac);
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
        public Kupac GetKupac(int kupacId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Kupac retVal = new Kupac();
            try
            {
                var query = dBContext.Kupci.Where(x => x.IdK == kupacId).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }

        public Kupac GetKupac(Kupac kupac)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Kupac retVal = new Kupac();
            try
            {
                var query = dBContext.Kupci.Where(x => x == kupac).FirstOrDefault();
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
        public void UpdateKupac(Kupac kupac)
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                var query = dBContext.Kupci.Where(x => x.IdK == kupac.IdK).FirstOrDefault();

                query.Jmbg = kupac.Jmbg;
                query.Ime = kupac.Ime;
                query.Prezime = kupac.Prezime;

                dBContext.SaveChanges();
            }
        }
        #endregion

        #region DeleteCommands
        public bool DeleteKupac(Kupac kupac)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            try
            {
                var query = dBContext.Kupci.Where(x => x == kupac).FirstOrDefault();
                if (query != null)
                {
                    dBContext.Kupci.Remove(kupac);
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
