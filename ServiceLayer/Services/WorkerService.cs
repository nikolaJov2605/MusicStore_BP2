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
    public class WorkerService : IWorker
    {
        public void AddWorker(RadnikModel radnikModel)
        {
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            Radnik dbRadnik = new Radnik();

            PlataCRUD plataCRUD = new PlataCRUD();
            Plata dbPlata = new Plata();

            RadniStazCRUD radniStazCRUD = new RadniStazCRUD();
            RadniStaz dbRadniStaz = new RadniStaz();

            dbPlata.Iznos = (decimal?)radnikModel.Plata;
            dbRadniStaz.BrGod = radnikModel.RadniStaz;

            plataCRUD.CreatePlata(dbPlata);
            radniStazCRUD.CreateRadniStaz(dbRadniStaz);

            dbRadnik.BrLk = radnikModel.Brlk;
            dbRadnik.Ime = radnikModel.Ime;
            dbRadnik.Prezime = radnikModel.Prezime;
            dbRadnik.Pozicija = radnikModel.Pozicija;

            radnikCRUD.CreateRadnik(dbRadnik, dbPlata, dbRadniStaz);
        }

        public void DeleteWorker(RadnikModel radnikModel)
        {
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            radnikCRUD.DeleteRadnik(radnikModel.Id);
        }

        public List<RadnikModel> FilterWorkers(string position)
        {
            throw new NotImplementedException();
        }

        public List<RadnikModel> GetAllWorkers()
        {
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            PlataCRUD plataCRUD = new PlataCRUD();
            RadniStazCRUD radniStazCRUD = new RadniStazCRUD();
            List<RadnikModel> retList = new List<RadnikModel>();
            List<Radnik> dtoList = radnikCRUD.GetAllRadnici();
            foreach (var radnik in dtoList)
            {
                RadnikModel tempModel = new RadnikModel();
                tempModel.Ime = radnik.Ime;
                tempModel.Prezime = radnik.Prezime;
                tempModel.Brlk = radnik.BrLk;
                tempModel.Pozicija = radnik.Pozicija;
                tempModel.Id = radnik.IdR;
                Plata plata = plataCRUD.GetPlataForRadnik(tempModel.Id);
                tempModel.Plata = (double)plata.Iznos;
                RadniStaz radniStaz = radniStazCRUD.GetRadniStazForRadnik(tempModel.Id);
                tempModel.RadniStaz = (int)radniStaz.BrGod;

                retList.Add(tempModel);
            }


            return retList;
        }

        public List<RadnikModel> GetSellers()
        {
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            PlataCRUD plataCRUD = new PlataCRUD();
            RadniStazCRUD radniStazCRUD = new RadniStazCRUD();
            List<RadnikModel> retList = new List<RadnikModel>();
            List<Radnik> dtoList = radnikCRUD.GetAllSellers();
            foreach (var radnik in dtoList)
            {
                RadnikModel tempModel = new RadnikModel();
                tempModel.Ime = radnik.Ime;
                tempModel.Prezime = radnik.Prezime;
                tempModel.Brlk = radnik.BrLk;
                tempModel.Pozicija = radnik.Pozicija;
                tempModel.Id = radnik.IdR;
                Plata plata = plataCRUD.GetPlataForRadnik(tempModel.Id);
                tempModel.Plata = (double)plata.Iznos;
                RadniStaz radniStaz = radniStazCRUD.GetRadniStazForRadnik(tempModel.Id);
                tempModel.RadniStaz = (int)radniStaz.BrGod;

                retList.Add(tempModel);
            }


            return retList;
        }

        public List<RadnikModel> GetTechs()
        {
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            PlataCRUD plataCRUD = new PlataCRUD();
            RadniStazCRUD radniStazCRUD = new RadniStazCRUD();
            List<RadnikModel> retList = new List<RadnikModel>();
            List<Radnik> dtoList = radnikCRUD.GetAllTechs();
            foreach (var radnik in dtoList)
            {
                RadnikModel tempModel = new RadnikModel();
                tempModel.Ime = radnik.Ime;
                tempModel.Prezime = radnik.Prezime;
                tempModel.Brlk = radnik.BrLk;
                tempModel.Pozicija = radnik.Pozicija;
                tempModel.Id = radnik.IdR;
                Plata plata = plataCRUD.GetPlataForRadnik(tempModel.Id);
                tempModel.Plata = (double)plata.Iznos;
                RadniStaz radniStaz = radniStazCRUD.GetRadniStazForRadnik(tempModel.Id);
                tempModel.RadniStaz = (int)radniStaz.BrGod;

                retList.Add(tempModel);
            }


            return retList;
        }

        public RadnikModel GetWorker(RadnikModel radnikModel)
        {
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            PlataCRUD plataCRUD = new PlataCRUD();
            RadniStazCRUD radniStazCRUD = new RadniStazCRUD();
            RadnikModel retVal = new RadnikModel();
            Radnik dbRadnik = radnikCRUD.GetRadnik(radnikModel.Id);

            retVal.Ime = dbRadnik.Ime;
            retVal.Prezime = dbRadnik.Prezime;
            retVal.Brlk = dbRadnik.BrLk;
            retVal.Pozicija = dbRadnik.Pozicija;
            retVal.Id = dbRadnik.IdR;
            Plata plata = plataCRUD.GetPlataForRadnik(retVal.Id);
            retVal.Plata = (double)plata.Iznos;
            RadniStaz radniStaz = radniStazCRUD.GetRadniStazForRadnik(retVal.Id);
            retVal.RadniStaz = (int)radniStaz.BrGod;

            return retVal;
        }

        public void UpdateWorker(RadnikModel radnikModel)
        {
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            Radnik dbRadnik = radnikCRUD.GetRadnik(radnikModel.Id);
            dbRadnik.Ime = radnikModel.Ime;
            dbRadnik.Prezime = radnikModel.Prezime;
            dbRadnik.BrLk = radnikModel.Brlk;
            dbRadnik.Pozicija = radnikModel.Pozicija;
            PlataCRUD plataCRUD = new PlataCRUD();
            Plata dbPlata = plataCRUD.GetPlata(dbRadnik.SifraP);
            dbPlata.Iznos = (decimal?)radnikModel.Plata;
            plataCRUD.UpdatePlata(dbPlata);

            RadniStazCRUD radniStazCRUD = new RadniStazCRUD();
            RadniStaz dbRadniStaz = radniStazCRUD.GetRadniStaz(dbRadnik.SifraS);
            dbRadniStaz.BrGod = radnikModel.RadniStaz;
            radniStazCRUD.UpdateRadniStaz(dbRadniStaz);

            radnikCRUD.UpdateRadnik(dbRadnik);
            
            
        }
    }
}
