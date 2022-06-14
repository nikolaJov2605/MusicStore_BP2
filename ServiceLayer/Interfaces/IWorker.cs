using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IWorker
    {
        void AddWorker(RadnikModel radnikModel);
        RadnikModel GetWorker(RadnikModel radnikModel);
        void UpdateWorker(RadnikModel radnikModel);
        void DeleteWorker(RadnikModel radnikModel);
        List<RadnikModel> GetAllWorkers();
        List<RadnikModel> GetSellers();
        List<RadnikModel> GetTechs();
        List<RadnikModel> FilterWorkers(string position);
    }
}
