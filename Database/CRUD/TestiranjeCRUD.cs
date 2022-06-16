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
                var instrumentQuery = dBContext.Instrumenti.FirstOrDefault(x => x.SifraI == testiranje.SifraI);
                var buyerQuery = dBContext.Kupci.FirstOrDefault(x => x.IdK == testiranje.IdK);
                var workerQuery = dBContext.Radnici.FirstOrDefault(x => x.IdR == testiranje.IdR);
                testiranje.IdKNavigation = buyerQuery;
                testiranje.IdRNavigation = workerQuery;
                testiranje.SifraINavigation = instrumentQuery;
                dBContext.Testiranja.Add(testiranje);
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

        public List<Testiranje> GetAllTests()
        {
            List<Testiranje> retList = new List<Testiranje>();
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                retList = dBContext.Testiranja.ToList();

                foreach (var item in retList)
                {
                    var queryKupac = dBContext.Kupci.Where(x => x.IdK == item.IdK);
                    var queryInstrument = dBContext.Instrumenti.Where(x => x.SifraI == item.SifraI);
                    var queryRadnik = dBContext.Radnici.Where(x => x.IdR == item.IdR);
                }

            }
            return retList;
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
