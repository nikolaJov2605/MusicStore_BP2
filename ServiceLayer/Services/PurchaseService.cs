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
    public class PurchaseService : IPurchase
    {
        public void AddPurchase(PurchaseModel purchaseModel)
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            KupacCRUD kupacCRUD = new KupacCRUD();
            RadnikCRUD radnikCRUD = new RadnikCRUD();

            Instrument dbInstrument = instrumentCRUD.GetInstrument(purchaseModel.IdInstrumenta);
            Kupac dbKupac = kupacCRUD.GetKupac(purchaseModel.IdKupca);
            Radnik dbRadnik = radnikCRUD.GetRadnik(purchaseModel.IdRadnika);
            if (dbRadnik.Pozicija == "Tehničar")
                return;

            dbInstrument.IdKNavigation = dbKupac;
            dbInstrument.IdRNavigation = dbRadnik;
            dbInstrument.Stat = false;

            instrumentCRUD.UpdateInstrument(dbInstrument);
        }

        public void DeletePurchase(PurchaseModel purchaseModel)
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            KupacCRUD kupacCRUD = new KupacCRUD();
            RadnikCRUD radnikCRUD = new RadnikCRUD();

            Instrument dbInstrument = instrumentCRUD.GetInstrument(purchaseModel.IdInstrumenta);
            Kupac dbKupac = kupacCRUD.GetKupac(purchaseModel.IdKupca);
            Radnik dbRadnik = radnikCRUD.GetRadnik(purchaseModel.IdRadnika);

            if (dbRadnik.Pozicija == "Tehničar")
                return;

            dbInstrument.IdKNavigation = null;
            dbInstrument.IdRNavigation = null;
            dbInstrument.Stat = true;
        }

        public List<PurchaseModel> GetAllPurchases()
        {
            List<PurchaseModel> retList = new List<PurchaseModel>();

            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            KupacCRUD kupacCRUD = new KupacCRUD();
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            CenaCRUD cenaCRUD = new CenaCRUD();

            List<Instrument> dbInstrumentList = instrumentCRUD.GetPurchasedInstruments();

            foreach(var item in dbInstrumentList)
            {
                Kupac dbKupac = kupacCRUD.GetKupac((int)item.IdK);
                Radnik dbRadnik = radnikCRUD.GetRadnik((int)item.IdR);
                Cena dbCena = cenaCRUD.GetPriceForInstrument(item.SifraI);

                retList.Add(new PurchaseModel(dbKupac.IdK, dbKupac.Ime, dbKupac.Prezime, dbKupac.Jmbg,
                    dbRadnik.IdR, dbRadnik.Ime, dbRadnik.Prezime, item.SifraI, item.Naziv, (double)dbCena.Iznos));
            }
            

            return retList;
        }

        public PurchaseModel GetPurchase(PurchaseModel purchaseModel)
        {
            PurchaseModel retVal = new PurchaseModel();

            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            KupacCRUD kupacCRUD = new KupacCRUD();
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            CenaCRUD cenaCRUD = new CenaCRUD();

            Instrument dbInstrument = instrumentCRUD.GetPurchasedInstrument(purchaseModel.IdInstrumenta);
            if (dbInstrument == null)
                return null;

            Kupac dbKupac = kupacCRUD.GetKupac((int)dbInstrument.IdK);
            Radnik dbRadnik = radnikCRUD.GetRadnik((int)dbInstrument.IdR);
            Cena dbCena = cenaCRUD.GetPriceForInstrument(dbInstrument.SifraI);

            retVal.IdKupca = (int)dbInstrument.IdK;
            retVal.ImeKupca = dbKupac.Ime;
            retVal.PrezimeKupca = dbKupac.Prezime;
            retVal.JmbgKupca = dbKupac.Jmbg;

            retVal.IdRadnika = dbRadnik.IdR;
            retVal.ImeRadnika = dbRadnik.Ime;
            retVal.PrezimeRadnika = dbRadnik.Prezime;

            retVal.IdInstrumenta = dbInstrument.SifraI;
            retVal.NazivInstrumenta = dbInstrument.Naziv;
            retVal.Cena = (double)dbCena.Iznos;

            return retVal;
        }

        public void UpdatePurchase(PurchaseModel purchaseModel)
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            KupacCRUD kupacCRUD = new KupacCRUD();
            RadnikCRUD radnikCRUD = new RadnikCRUD();

            Instrument dbInstrument = instrumentCRUD.GetInstrument(purchaseModel.IdInstrumenta);
            Kupac dbKupac = kupacCRUD.GetKupac(purchaseModel.IdKupca);
            Radnik dbRadnik = radnikCRUD.GetRadnik(purchaseModel.IdRadnika);

            if (dbRadnik.Pozicija == "Tehničar")
                return;

            dbInstrument.IdKNavigation = dbKupac;
            dbInstrument.IdRNavigation = dbRadnik;
            dbInstrument.Stat = false;
        }
    }
}
