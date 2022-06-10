﻿using Database.ModelDTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CRUD
{
    public class CenaCRUD
    {
        #region CreateOperations
        public void CreateCena(Cena cena)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();

            try
            {
                dBContext.Cene.Add(cena);
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
        public Cena GetCena(int cenaId)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Cena retVal = new Cena();
            try
            {
                var query = dBContext.Cene.Where(x => x.SifraC == cenaId).FirstOrDefault();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }

        public Cena GetCena(Cena cena)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            Cena retVal = new Cena();
            try
            {
                var query = dBContext.Cene.Where(x => x == cena).FirstOrDefault();
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
        public void UpdateCena(Cena cena)
        {
            using (MusicStoreDBContext dBContext = new MusicStoreDBContext())
            {
                var query = dBContext.Cene.Where(x => x.SifraC == cena.SifraC).FirstOrDefault();

                query.Iznos = cena.Iznos;
                query.DatPocetka = cena.DatPocetka;
                query.DatZavrsetka = cena.DatZavrsetka;

                dBContext.SaveChanges();
            }
        }
        #endregion

        #region DeleteCommands
        public bool DeleteCena(Cena cena)
        {
            MusicStoreDBContext dBContext = new MusicStoreDBContext();
            try
            {
                var query = dBContext.Cene.Where(x => x == cena).FirstOrDefault();
                if (query != null)
                {
                    dBContext.Cene.Remove(cena);
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
