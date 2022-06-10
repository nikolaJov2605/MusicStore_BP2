using Database.ModelDTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CRUD
{
    public class TestiranjeCRUD
    {
        #region CreateOperations
        public void CreateTestiranje(Testiranje testiranje)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();

            try
            {
                dBContext.Testiranja.Add(testiranje);
                dBContext.SaveChanges();
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region ReadOperations
        public Testiranje GetTestiranje(Kupac kupac, Instrument instrument)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Testiranje retVal = new Testiranje();
            try
            {
                var query = dBContext.Testiranja.Where(x => x.IdK == kupac.IdK && x.SifraI == instrument.SifraI).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }

        public Testiranje GetTestiranje(Testiranje testiranje)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Testiranje retVal = new Testiranje();
            try
            {
                var query = dBContext.Testiranja.Where(x => x == testiranje).FirstOrDefault();
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
        /*public void UpdateTestiranje(Testiranje testiranje)
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                var query = dBContext.Testiranja.Where(x => x.IdK == testiranje.IdK && x.SifraI == testiranje.SifraI).FirstOrDefault();


                dBContext.SaveChanges();
            }
        }*/
        #endregion

        #region DeleteCommands
        public bool DeleteTestiranje(Testiranje testiranje)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            try
            {
                var query = dBContext.Testiranja.Where(x => x == testiranje).FirstOrDefault();
                if (query != null)
                {
                    dBContext.Testiranja.Remove(testiranje);
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
