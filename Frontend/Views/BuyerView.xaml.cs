using ServiceLayer.Interfaces;
using ServiceLayer.Models;
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
    /// Interaction logic for BuyerView.xaml
    /// </summary>
    public partial class BuyerView : Window
    {
        private static BuyerView buyerViewInstance;
        private IBuyer buyerService;
        public BuyerView()
        {
            InitializeComponent();
            buyerService = new BuyerService();
            dgBuyers.ItemsSource = buyerService.GetAllBuyers();
        }

        public static BuyerView BuyerViewInstance
        {
            get
            {
                if (buyerViewInstance == null)
                    buyerViewInstance = new BuyerView();
                return buyerViewInstance;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgBuyers.SelectedItem == null)
            {
                MessageBox.Show("Izaberite kupca za izmenu!");
                return;
            }

            KupacModel model = buyerService.GetBuyer((KupacModel)dgBuyers.SelectedItem);
            UpdateBuyer updateBuyerWindow = UpdateBuyer.UpdatBuyerkerInstance(model);
            updateBuyerWindow.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgBuyers.SelectedItem == null)
            {
                MessageBox.Show("Izaberite kupca za brisanje!");
                return;
            }

            KupacModel model = buyerService.GetBuyer((KupacModel)dgBuyers.SelectedItem);
            buyerService.DeleteBuyer(model);


            dgBuyers.ItemsSource = buyerService.GetAllBuyers();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddBuyer addBuyerWindow = AddBuyer.AddBuyerInstance;
            addBuyerWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            buyerViewInstance = null;
        }
    }
}
