using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IBuyer
    {
        void AddBuyer(KupacModel kupacModel);
        KupacModel GetBuyer(KupacModel kupacModel);
        KupacModel GetBuyerByJMBG(KupacModel kupacModel);
        void UpdateBuyer(KupacModel kupacModel);
        void DeleteBuyer(KupacModel kupacModel);
        List<KupacModel> GetAllBuyers();
    }
}
