using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Frontend.Views
{
    /// <summary>
    /// Interaction logic for PurchaseView.xaml
    /// </summary>
    public partial class PurchaseView : Window
    {
        private static PurchaseView purchaseViewInstance;
        private IPurchase purchaseService;

        public PurchaseView()
        {
            InitializeComponent();
            purchaseService = new PurchaseService();

            dgPurchases.ItemsSource = purchaseService.GetAllPurchases();
        }

        public static PurchaseView PurchaseViewInstance
        {
            get
            {
                if (purchaseViewInstance == null)
                    purchaseViewInstance = new PurchaseView();
                return purchaseViewInstance;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            purchaseViewInstance = null;
        }
    }
}
