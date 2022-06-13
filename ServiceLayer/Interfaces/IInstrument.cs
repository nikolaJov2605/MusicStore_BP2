using ServiceLayer.Models;
using ServiceLayer.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IInstrument
    {
        void AddInstrument(InstrumentModel instrument);
        InstrumentModel GetInstrument(InstrumentModel instrument);
        void UpdateInstrument(InstrumentModel instrument);
        void DeleteInstrument(InstrumentModel instrument);
        List<InstrumentModel> GetAllInstruments();
        List<CenaModel> GetPricesForInstrument(int instrumentId);
        List<InstrumentModel> FilterInstruments(string criteria);
    }
}
