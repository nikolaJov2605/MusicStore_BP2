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
    /// Interaction logic for AddBuyer.xaml
    /// </summary>
    public partial class AddBuyer : Window
    {
        private static AddBuyer addBuyerInstance;
        private IBuyer buyerService;

        public AddBuyer()
        {
            InitializeComponent();
            buyerService = new BuyerService();
        }

        public static AddBuyer AddBuyerInstance
        {
            get
            {
                if (addBuyerInstance == null)
                    addBuyerInstance = new AddBuyer();
                return addBuyerInstance;
            }
        }

        private bool Validate()
        {
            bool valid = true;

            if (tbName.Text == String.Empty)
            {
                valid = false;
                tbName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbName.Text == String.Empty)
            {
                valid = false;
                tbName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbLastName.Text == String.Empty)
            {
                valid = false;
                tbLastName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (tbJmbg.Text == String.Empty)
            {
                valid = false;
                tbJmbg.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            return valid;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;

            KupacModel kupacModel = new KupacModel(tbJmbg.Text, tbName.Text, tbLastName.Text);
            buyerService.AddBuyer(kupacModel);

            BuyerView.BuyerViewInstance.dgBuyers.ItemsSource = buyerService.GetAllBuyers();

            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            addBuyerInstance = null;
        }
    }
}
