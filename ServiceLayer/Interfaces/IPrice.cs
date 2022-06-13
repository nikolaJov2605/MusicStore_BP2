using Database.ModelDTOs;
using ServiceLayer.Models;
using ServiceLayer.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IPrice
    {
        void AddNewPrice(CenaModel cenaModel, InstrumentModel instrument);
    }
}
