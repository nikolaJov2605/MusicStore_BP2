using Database.ModelDTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CRUD
{
    public class PlataCRUD
    {
        #region CreateOperations
        public void CreatePlata(Plata plata)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();

            try
            {
                dBContext.Plate.Add(plata);
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
        public Plata GetPlata(int plataId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Plata retVal = new Plata();
            try
            {
                var query = dBContext.Plate.Where(x => x.SifraP == plataId).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }

        public Plata GetPlata(Plata plata)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Plata retVal = new Plata();
            try
            {
                var query = dBContext.Plate.Where(x => x == plata).FirstOrDefault();
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
        public void UpdatePlata(Plata plata)
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                var query = dBContext.Plate.Where(x => x.SifraP == plata.SifraP).FirstOrDefault();

                query.Iznos = plata.Iznos;

                dBContext.SaveChanges();
            }
        }
        #endregion

        #region DeleteCommands
        public bool DeletePlata(Plata plata)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            try
            {
                var query = dBContext.Plate.Where(x => x == plata).FirstOrDefault();
                if (query != null)
                {
                    dBContext.Plate.Remove(plata);
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
