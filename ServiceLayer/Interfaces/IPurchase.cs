using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IPurchase
    {
        void AddPurchase(PurchaseModel purchaseModel);
        PurchaseModel GetPurchase(PurchaseModel purchaseModel);
        void UpdatePurchase(PurchaseModel purchaseModel);
        void DeletePurchase(PurchaseModel purchaseModel);
        List<PurchaseModel> GetAllPurchases();
    }
}
