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
    /// Interaction logic for UpdateBuyer.xaml
    /// </summary>
    public partial class UpdateBuyer : Window
    {
        private static UpdateBuyer updateBuyerInstance;
        private IBuyer buyerService;
        public static KupacModel LoadedKupac;

        public UpdateBuyer()
        {
            InitializeComponent();
            buyerService = new BuyerService();
        }

        public UpdateBuyer(KupacModel kupac)
        {
            InitializeComponent();
            buyerService = new BuyerService();
            LoadedKupac = kupac;
            lblCaption.Content = kupac.Ime + " " + kupac.Prezime;


            tbName.Text = kupac.Ime;
            tbLastName.Text = kupac.Prezime;
            tbJmbg.Text = kupac.Jmbg;
        }

        public static UpdateBuyer UpdatBuyerkerInstance(KupacModel kupac)
        {
            if (updateBuyerInstance == null)
                updateBuyerInstance = new UpdateBuyer(kupac);
            return updateBuyerInstance;
        }

        public static UpdateBuyer UpdatBuyerkerInstanceProp
        {
            get
            {
                if (updateBuyerInstance == null)
                    updateBuyerInstance = new UpdateBuyer();
                return updateBuyerInstance;
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;

            KupacModel kupacModel = new KupacModel(tbJmbg.Text, tbName.Text, tbLastName.Text);
            kupacModel.Id = LoadedKupac.Id;
            buyerService.UpdateBuyer(kupacModel);

            BuyerView.BuyerViewInstance.dgBuyers.ItemsSource = buyerService.GetAllBuyers();

            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            updateBuyerInstance = null;
        }
    }
}
