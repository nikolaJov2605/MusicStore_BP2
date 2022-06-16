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
    public class TestService : ITest
    {
        public void AddTest(TestModel testModel)
        {
            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            KupacCRUD kupacCRUD = new KupacCRUD();
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            TestiranjeCRUD testiranjeCRUD = new TestiranjeCRUD();

            Instrument dbInstrument = instrumentCRUD.GetInstrument(testModel.IdInstrumenta);
            Kupac dbKupac = kupacCRUD.GetKupac(testModel.IdKupca);
            Radnik dbRadnik = radnikCRUD.GetRadnik(testModel.IdRadnika);
            if (dbRadnik.Pozicija == "Prodavac")
                return;

            Testiranje dbTestiranje = new Testiranje();

            dbTestiranje.IdK = dbKupac.IdK;
            dbTestiranje.IdR = dbRadnik.IdR;
            dbTestiranje.SifraI = dbInstrument.SifraI;

            dbTestiranje.DatTest = DateTime.Now.ToString().Substring(0, 9);

            testiranjeCRUD.CreateTestiranje(dbTestiranje);
        }

        public void DeleteTest(TestModel testModel)
        {
            throw new NotImplementedException();
        }

        public List<TestModel> GetAllTests()
        {
            List<TestModel> retList = new List<TestModel>();

            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            KupacCRUD kupacCRUD = new KupacCRUD();
            RadnikCRUD radnikCRUD = new RadnikCRUD();
            TestiranjeCRUD testiranjeCRUD = new TestiranjeCRUD();

            List<Testiranje> dbTestList = testiranjeCRUD.GetAllTests();

            foreach (var item in dbTestList)
            {
                Kupac dbKupac = kupacCRUD.GetKupac((int)item.IdK);
                Radnik dbRadnik = radnikCRUD.GetRadnik((int)item.IdR);
                Instrument dbInstrument = instrumentCRUD.GetInstrument(item.SifraI);

                retList.Add(new TestModel(dbInstrument.SifraI, dbInstrument.Naziv, dbRadnik.IdR, dbRadnik.Ime, dbRadnik.Prezime, dbKupac.IdK, dbKupac.Ime, dbKupac.Prezime, dbKupac.Jmbg, item.DatTest));
            }


            return retList;
        }

        public TestModel GetTest(TestModel testModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateTest(TestModel testModel)
        {
            throw new NotImplementedException();
        }
    }
}
