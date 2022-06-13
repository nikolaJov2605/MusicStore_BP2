using Database.CRUD;
using Database.ModelDTOs;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using ServiceLayer.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class PriceService : IPrice
    {
        public void AddNewPrice(CenaModel cenaModel, InstrumentModel instrument)
        {
            CenaCRUD cenaCRUD = new CenaCRUD();
            Cena dbCena = new Cena();
            dbCena.DatPocetka = cenaModel.DatumPocetka;
            dbCena.DatZavrsetka = cenaModel.DatumZavrsetka;
            dbCena.Iznos = (decimal?)cenaModel.Iznos;

            InstrumentCRUD instrumentCRUD = new InstrumentCRUD();
            Instrument dbInstrument = instrumentCRUD.GetInstrument(instrument.Id);

            cenaCRUD.CreateCena(dbCena, dbInstrument);
        }
    }
}
