using Database.CRUD;
using Database.ModelDTOs;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BuyerService : IBuyer
    {
        public void AddBuyer(KupacModel kupacModel)
        {
            KupacCRUD kupacCRUD = new KupacCRUD();
            Kupac dbKupac = new Kupac();

            dbKupac.Jmbg = kupacModel.Jmbg;
            dbKupac.Ime = kupacModel.Ime;
            dbKupac.Prezime = kupacModel.Prezime;

            kupacCRUD.CreateKupac(dbKupac);
        }

        public void DeleteBuyer(KupacModel kupacModel)
        {
            KupacCRUD kupacCRUD = new KupacCRUD();
            kupacCRUD.DeleteKupac(kupacModel.Id);
        }

        public List<KupacModel> GetAllBuyers()
        {
            KupacCRUD kupacCRUD = new KupacCRUD();
            List<KupacModel> retList = new List<KupacModel>();
            List<Kupac> dtoList = kupacCRUD.GetAllKupci();
            foreach (var kupac in dtoList)
            {
                KupacModel tempModel = new KupacModel();
                tempModel.Ime = kupac.Ime;
                tempModel.Prezime = kupac.Prezime;
                tempModel.Jmbg = kupac.Jmbg;
                tempModel.Id = kupac.IdK;

                retList.Add(tempModel);
            }


            return retList;
        }

        public KupacModel GetBuyer(KupacModel kupacModel)
        {
            KupacCRUD kupacCRUD = new KupacCRUD();
            KupacModel retVal = new KupacModel();
            Kupac dbKupac = kupacCRUD.GetKupac(kupacModel.Id);

            retVal.Ime = dbKupac.Ime;
            retVal.Prezime = dbKupac.Prezime;
            retVal.Jmbg = dbKupac.Jmbg;
            retVal.Id = dbKupac.IdK;

            return retVal;
        }

        public KupacModel GetBuyerByJMBG(KupacModel kupacModel)
        {
            KupacCRUD kupacCRUD = new KupacCRUD();
            KupacModel retVal = new KupacModel();
            Kupac dbKupac = kupacCRUD.GetKupac(kupacModel.Jmbg);

            retVal.Ime = dbKupac.Ime;
            retVal.Prezime = dbKupac.Prezime;
            retVal.Jmbg = dbKupac.Jmbg;
            retVal.Id = dbKupac.IdK;

            return retVal;
        }

        public void UpdateBuyer(KupacModel kupacModel)
        {
            KupacCRUD kupacCRUD = new KupacCRUD();
            Kupac dbKupac = kupacCRUD.GetKupac(kupacModel.Id);
            dbKupac.Ime = kupacModel.Ime;
            dbKupac.Prezime = kupacModel.Prezime;
            dbKupac.Jmbg = kupacModel.Jmbg;

            kupacCRUD.UpdateKupac(dbKupac);

        }
    }
}
