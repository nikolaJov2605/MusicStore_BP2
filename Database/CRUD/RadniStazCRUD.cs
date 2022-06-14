using Database.ModelDTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CRUD
{
    public class RadniStazCRUD
    {
        #region CreateOperations
        public void CreateRadniStaz(RadniStaz radniStaz)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();

            try
            {
                dBContext.RadniStaz.Add(radniStaz);
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
        public RadniStaz GetRadniStaz(int radniStazId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            RadniStaz retVal = new RadniStaz();
            try
            {
                var query = dBContext.RadniStaz.Where(x => x.SifraS == radniStazId).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }

        public RadniStaz GetRadniStaz(RadniStaz radniStaz)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            RadniStaz retVal = new RadniStaz();
            try
            {
                var query = dBContext.RadniStaz.Where(x => x == radniStaz).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }
        public RadniStaz GetRadniStazForRadnik(int radnikId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            RadniStaz retVal = new RadniStaz();
            try
            {
                var query = dBContext.Radnici.Where(x => x.IdR == radnikId).FirstOrDefault();
                if (query != null)
                {
                    var workingYears = dBContext.RadniStaz.FirstOrDefault(x => x.SifraS == query.SifraS);
                    if(workingYears != null)
                        return query.SifraSNavigation;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion

        #region UpdateOperations
        public void UpdateRadniStaz(RadniStaz radniStaz)
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                var query = dBContext.RadniStaz.Where(x => x.SifraS == radniStaz.SifraS).FirstOrDefault();

                query.BrGod = radniStaz.BrGod;

                dBContext.SaveChanges();
            }
        }
        #endregion

        #region DeleteCommands
        public bool DeleteRadniStaz(RadniStaz radniStaz)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            try
            {
                var query = dBContext.RadniStaz.Where(x => x == radniStaz).FirstOrDefault();
                if (query != null)
                {
                    dBContext.RadniStaz.Remove(radniStaz);
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
